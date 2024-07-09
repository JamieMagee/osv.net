namespace OSV.Client.Test.TestData;

public class QueryAffectedBatchTestData : TheoryData<BatchQuery>
{
    public QueryAffectedBatchTestData() => this.Add(new()
    {
        Queries =
        [
            new Query
            {
                Package = new Package
                {
                    Name = "jinja2",
                    Ecosystem = Ecosystem.PyPI,
                },
                Version = "2.4.1",
            },
        ],
    });
}
