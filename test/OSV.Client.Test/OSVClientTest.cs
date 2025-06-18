namespace OSV.Client.Test;

public class OSVClientTest
{
    public OSVClientTest() => this.Client = new OSVClient();

    private OSVClient Client { get; }

    [Theory]
    [InlineData(Ecosystem.PyPI, "jinja2", "2.4.1")]
    public async Task Should_QueryAffectedAsync(Ecosystem ecosystem, string packageName, string version)
    {
        var query = new Query
        {
            Package = new Package { Name = packageName, Ecosystem = ecosystem },
            Version = version,
        };

        var response = await this.Client.QueryAffectedAsync(query, TestContext.Current.CancellationToken).ConfigureAwait(true);
        response.ShouldNotBeNull();
    }

    [Theory]
    [InlineData(Ecosystem.PyPI, "jinja2", "2.4.1")]
    public async Task Should_QueryAffectedBatchAsync(Ecosystem ecosystem, string packageName, string version)
    {
        var batchQuery = new BatchQuery
        {
            Queries =
            [
                new Query
                {
                    Package = new Package { Name = packageName, Ecosystem = ecosystem },
                    Version = version,
                },
            ],
        };

        var response = await this.Client.QueryAffectedBatchAsync(batchQuery, TestContext.Current.CancellationToken).ConfigureAwait(true);
        response.ShouldNotBeNull();
    }

    [Theory]
    [InlineData("OSV-2020-111")]
    public async Task Should_GetVulnerabilityAsync(string id)
    {
        var response = await this.Client.GetVulnerabilityAsync(id, TestContext.Current.CancellationToken).ConfigureAwait(true);
        response.ShouldNotBeNull();
    }
}
