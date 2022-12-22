# OSV.NET

[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/JamieMagee/osv.net/build.yml?branch=main&style=for-the-badge)](https://github.com/JamieMagee/osv.net/actions/workflows/build.yml?query=branch%3Amain)
[![OSV.NET NuGet Package Version](https://img.shields.io/nuget/v/OSV.Schema?style=for-the-badge)](https://www.nuget.org/packages/OSV.Schema/)

.NET libraries for Open Source Vulnerabilities (OSV) schema and API client.

## Usage

1. `dotnet add package OSV.Client`
2. Create an instance of the `OSVClient`

    ```C#
    using var client = new OSVClient();
    // or
    using var client = new OSVClient("https://api.osv.dev/v1/");
    ```

3. Use the client to make API calls

    ```C#
    var query = new Query
    {
        Package = new Package {
            Name = "jinja2",
            Ecosystem = Ecosystem.PyPI
        },
        Version = "2.4.1",
    }
    var vulnerabilityList = await client.QueryAffectedAsync(query)
    ```

## License

All packages in this repository are licensed under [the MIT license](https://opensource.org/licenses/MIT).
