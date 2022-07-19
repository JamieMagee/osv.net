namespace OSV;

using OSV.Models;

public sealed partial class OSVClient
{
    public Task<Vulnerability> GetVulnerabilityAsync(string id, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("vulns/{id}").AddUrlSegment("id", id);
        return this.ExecuteAsync<Vulnerability>(request, cancellationToken);
    }
}
