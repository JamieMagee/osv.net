namespace OSV.Client.Test;

using OSV.Client.Test.TestData;

public class OSVClientTest
{
    public OSVClientTest() => this.Client = new OSVClient();

    private IOSVClient Client { get; }

    [Theory]
    [ClassData(typeof(QueryAffectedTestData))]
    public async Task Should_QueryAffectedAsync(Query query)
    {
        var response = await this.Client.QueryAffectedAsync(query).ConfigureAwait(true);
        response.Should().NotBeNull();
    }

    [Theory]
    [ClassData(typeof(QueryAffectedBatchTestData))]
    public async Task Should_QueryAffectedBatchAsync(BatchQuery batchQuery)
    {
        var response = await this.Client.QueryAffectedBatchAsync(batchQuery).ConfigureAwait(true);
        response.Should().NotBeNull();
    }

    [Theory]
    [ClassData(typeof(GetVulnerabilityTestData))]
    public async Task Should_GetVulnerabilityAsync(string id)
    {
        var response = await this.Client.GetVulnerabilityAsync(id).ConfigureAwait(true);
        response.Should().NotBeNull();
    }
}
