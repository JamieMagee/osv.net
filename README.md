# OSV.NET

[![GitHub Workflow Status][1]][2]
[![OSV.NET NuGet Package Version][3]][4]
[![OSSF-Scorecard Score][5]][6]

.NET libraries for Open Source Vulnerabilities (OSV) schema and API client.
Currently support version 1.7.0 of the OSV schema.

## Usage

There are two ways to use the OSV.NET library:

- Manual instantiation
- Dependency injection (DI)

### Manual Instantiation

```C#
using OSV.Client;

using var client = new OSVClient();

try
{
    var query = new Query
    {
        Package = new Package
        {
            Name = "lodash",
            Ecosystem = "npm"
        },
        Version = "4.17.20"
    };

    var response = await client.QueryAffectedAsync(query);
    Console.WriteLine($"Found {response.Vulnerabilities.Count()} vulnerabilities for lodash@4.17.20");
}
catch (OSVException ex)
{
    // Handle OSV-specific exceptions
}
```

### Dependency Injection

Register the OSV client in your application's service collection, typically in `Program.cs`:

```C#
// Register OSV client
builder.Services.AddOSVClient(client =>
{
    // Add any additional HttpClient configuration
    client.Timeout = TimeSpan.FromSeconds(30);
});
```

## License

All packages in this repository are licensed under [the MIT license][7].

[1]: https://img.shields.io/github/actions/workflow/status/JamieMagee/osv.net/build.yml?branch=main&style=for-the-badge
[2]: https://github.com/JamieMagee/osv.net/actions/workflows/build.yml?query=branch%3Amain
[3]: https://img.shields.io/nuget/v/OSV.Schema?style=for-the-badge
[4]: https://www.nuget.org/packages/OSV.Schema/
[5]: https://img.shields.io/ossf-scorecard/github.com/JamieMagee/osv.net?style=for-the-badge
[6]: https://scorecard.dev/viewer/?uri=github.com/JamieMagee/osv.net
[7]: https://opensource.org/licenses/MIT
