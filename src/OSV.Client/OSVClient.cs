namespace OSV.Client;

using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;

public sealed class OSVClient : IOSVClient, IDisposable
{
    private readonly HttpClient httpClient;
    private readonly bool ownsHttpClient;
    private readonly JsonSerializerOptions jsonOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="OSVClient"/> class with a custom HttpClient.
    /// This constructor is typically used with dependency injection.
    /// </summary>
    /// <param name="httpClient">The HttpClient to use for requests.</param>
    public OSVClient(HttpClient httpClient)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        this.ownsHttpClient = false;
        this.jsonOptions = CreateJsonOptions();

        // Configure default settings if not already configured
        if (this.httpClient.BaseAddress == null)
        {
            this.httpClient.BaseAddress = new Uri("https://api.osv.dev/v1/");
        }

        if (this.httpClient.DefaultRequestHeaders.UserAgent.Count == 0)
        {
            var version = typeof(OSVClient).GetTypeInfo().Assembly.GetName().Version;
            this.httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"osv.net/{version}");
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OSVClient"/> class with a base URI.
    /// This constructor creates its own HttpClient instance.
    /// </summary>
    /// <param name="baseUri">The base URI for the OSV API.</param>
    public OSVClient(string baseUri)
    {
        var version = typeof(OSVClient).GetTypeInfo().Assembly.GetName().Version;

        this.httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUri),
        };
        this.httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"osv.net/{version}");

        this.ownsHttpClient = true;
        this.jsonOptions = CreateJsonOptions();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OSVClient"/> class with the default OSV API endpoint.
    /// This constructor creates its own HttpClient instance.
    /// </summary>
    public OSVClient()
        : this("https://api.osv.dev/v1/")
    {
    }

    /// <inheritdoc/>
    public async Task<VulnerabilityList> QueryAffectedAsync(Query query, CancellationToken cancellationToken = default)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return await this.PostAsync<Query, VulnerabilityList>("query", query, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BatchVulnerabilityList> QueryAffectedBatchAsync(BatchQuery batchQuery, CancellationToken cancellationToken = default)
    {
        if (batchQuery == null)
        {
            throw new ArgumentNullException(nameof(batchQuery));
        }

        return await this.PostAsync<BatchQuery, BatchVulnerabilityList>("querybatch", batchQuery, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Vulnerability> GetVulnerabilityAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Vulnerability ID cannot be null or empty.", nameof(id));
        }

        return await this.GetAsync<Vulnerability>($"vulns/{id}", cancellationToken).ConfigureAwait(false);
    }

    public void Dispose()
    {
        if (this.ownsHttpClient)
        {
            this.httpClient.Dispose();
        }
    }

    private static JsonSerializerOptions CreateJsonOptions() => new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true,
    };

    private async Task<TResponse> GetAsync<TResponse>(string requestUri, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        try
        {
            using var response = await this.httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await this.ProcessResponseAsync<TResponse>(response).ConfigureAwait(false);
        }
        catch (HttpRequestException ex)
        {
            throw new OSVException($"HTTP request failed: {ex.Message}", ex);
        }
        catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
        {
            throw new OSVException("Request timed out.", ex);
        }
        catch (TaskCanceledException ex) when (cancellationToken.IsCancellationRequested)
        {
            throw new OSVException("Request was cancelled.", ex);
        }
        catch (Exception ex)
        {
            throw new OSVException($"An unexpected error occurred: {ex.Message}", ex);
        }
    }

    private async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest content, CancellationToken cancellationToken = default)
        where TRequest : class
        where TResponse : class
    {
        try
        {
            var json = JsonSerializer.Serialize(content, this.jsonOptions);
            using var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await this.httpClient.PostAsync(requestUri, httpContent, cancellationToken).ConfigureAwait(false);
            return await this.ProcessResponseAsync<TResponse>(response).ConfigureAwait(false);
        }
        catch (HttpRequestException ex)
        {
            throw new OSVException($"HTTP request failed: {ex.Message}", ex);
        }
        catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
        {
            throw new OSVException("Request timed out.", ex);
        }
        catch (TaskCanceledException ex) when (cancellationToken.IsCancellationRequested)
        {
            throw new OSVException("Request was cancelled.", ex);
        }
        catch (Exception ex)
        {
            throw new OSVException($"An unexpected error occurred: {ex.Message}", ex);
        }
    }

    private async Task<TResponse> ProcessResponseAsync<TResponse>(HttpResponseMessage response)
        where TResponse : class
    {
        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new OSVException(response.StatusCode, content);
        }

        if (string.IsNullOrEmpty(content))
        {
            throw new OSVException("Response content was empty.");
        }

        try
        {
            var result = JsonSerializer.Deserialize<TResponse>(content, this.jsonOptions);
            return result ?? throw new OSVException("Failed to deserialize response content.");
        }
        catch (JsonException ex)
        {
            throw new OSVException(HttpStatusCode.OK, content, ex, "Failed to deserialize response content.");
        }
    }
}
