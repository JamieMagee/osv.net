namespace OSV.Client;

public interface IOSVClient
{
    Task<VulnerabilityList> QueryAffectedAsync(Query query, CancellationToken cancellationToken = default);

    Task<BatchVulnerabilityList> QueryAffectedBatchAsync(BatchQuery batchQuery, CancellationToken cancellationToken = default);

    Task<Vulnerability> GetVulnerabilityAsync(string id, CancellationToken cancellationToken = default);
}
