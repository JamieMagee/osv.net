namespace OSV.Client;

public interface IOSVClient
{
    public Task<VulnerabilityList> QueryAffectedAsync(Query query, CancellationToken cancellationToken = default);

    public Task<BatchVulnerabilityList> QueryAffectedBatchAsync(BatchQuery batchQuery, CancellationToken cancellationToken = default);

    public Task<Vulnerability> GetVulnerabilityAsync(string id, CancellationToken cancellationToken = default);
}
