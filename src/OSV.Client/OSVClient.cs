namespace OSV.Client;

using System.Reflection;

public sealed class OSVClient : IOSVClient, IDisposable
{
    private readonly RestClient client;

    public OSVClient(string baseUri)
    {
        var version = typeof(OSVClient).GetTypeInfo().Assembly.GetName().Version;

        var clientOptions = new RestClientOptions(baseUri)
        {
            UserAgent = "osv.net/" + version,
        };

        this.client = new RestClient(clientOptions);
    }

    public OSVClient()
        : this("https://api.osv.dev/v1/")
    {
    }

    /// <summary>
    /// Query vulnerabilities for a particular project at a given commit or version.
    /// </summary>
    /// <param name="query">The query to use.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    /// <returns>The vulnerabilities.</returns>
    public Task<VulnerabilityList> QueryAffectedAsync(Query query, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("query", Method.Post)
        {
            RequestFormat = DataFormat.Json,
        }.AddBody(query);
        return this.ExecuteAsync<VulnerabilityList>(request, cancellationToken);
    }

    /// <summary>
    /// Query vulnerabilities (batched) for given package versions and commits.
    /// This currently allows a maximum of 1000 package versions to be included in a single query.
    /// </summary>
    /// <param name="batchQuery">The query to use.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    /// <returns>The vulnerabilities.</returns>
    public Task<BatchVulnerabilityList> QueryAffectedBatchAsync(BatchQuery batchQuery, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("querybatch", Method.Post)
        {
            RequestFormat = DataFormat.Json,
        }.AddBody(batchQuery);
        return this.ExecuteAsync<BatchVulnerabilityList>(request, cancellationToken);
    }

    /// <summary>
    /// Return a <see cref="Vulnerability"/> object for a given OSV ID.
    /// </summary>
    /// <param name="id">The ID of the vulnerability.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    /// <returns>The vulnerability.</returns>
    public Task<Vulnerability> GetVulnerabilityAsync(string id, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("vulns/{id}").AddUrlSegment("id", id);
        return this.ExecuteAsync<Vulnerability>(request, cancellationToken);
    }

    public void Dispose() => this.client.Dispose();

    private async Task<T> ExecuteAsync<T>(RestRequest request, CancellationToken cancellationToken = default)
        where T : new()
    {
        T data;

        try
        {
            var response = await this.client.ExecuteAsync<T>(request, cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                throw new OSVException(null);
            }

            data = response.ThrowIfError().Data!;
        }
        catch (Exception ex)
        {
            throw new OSVException(null, ex);
        }

        return data;
    }
}
