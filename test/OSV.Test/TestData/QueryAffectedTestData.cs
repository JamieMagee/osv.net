namespace OSV.Test.TestData;

using OSV.Models;

public class QueryAffectedTestData : TheoryData<Query>
{
    public QueryAffectedTestData() => this.Add(new()
    {
        Package = new Package { Name = "jinja2", Ecosystem = Ecosystem.PyPI },
        Version = "2.4.1",
    });
}
