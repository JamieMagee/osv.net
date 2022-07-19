namespace OSV;

using System.Reflection;

public sealed partial class OSVClient : IOSVClient, IDisposable
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
