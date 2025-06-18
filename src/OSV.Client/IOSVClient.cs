namespace OSV.Client;

public interface IOSVClient
{
    /// <summary>
    /// Query vulnerabilities for a particular project at a given commit or version.
    /// </summary>
    /// <param name="query">The query to use.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    /// <returns>The vulnerabilities.</returns>
    public Task<VulnerabilityList> QueryAffectedAsync(Query query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Query vulnerabilities (batched) for given package versions and commits.
    /// This currently allows a maximum of 1000 package versions to be included in a single query.
    /// </summary>
    /// <param name="batchQuery">The query to use.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    /// <returns>The vulnerabilities.</returns>
    public Task<BatchVulnerabilityList> QueryAffectedBatchAsync(BatchQuery batchQuery, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a <see cref="Vulnerability"/> object for a given OSV ID.
    /// </summary>
    /// <param name="id">The ID of the vulnerability.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    /// <returns>The vulnerability.</returns>
    public Task<Vulnerability> GetVulnerabilityAsync(string id, CancellationToken cancellationToken = default);
}
