namespace OSV;

using OSV.Models;

public sealed partial class OSVClient
{
    public Task<VulnerabilityList> QueryAffectedAsync(Query query, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("query", Method.Post)
        {
            RequestFormat = DataFormat.Json,
        }.AddBody(query);
        return this.ExecuteAsync<VulnerabilityList>(request, cancellationToken);
    }
}
