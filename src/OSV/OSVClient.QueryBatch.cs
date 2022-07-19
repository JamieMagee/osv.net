namespace OSV;

using OSV.Models;

public sealed partial class OSVClient
{
    public Task<BatchVulnerabilityList> QueryAffectedBatchAsync(BatchQuery batchQuery, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("querybatch", Method.Post)
        {
            RequestFormat = DataFormat.Json,
        }.AddBody(batchQuery);
        return this.ExecuteAsync<BatchVulnerabilityList>(request, cancellationToken);
    }
}
