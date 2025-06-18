# OSV.NET

[![GitHub Workflow Status][1]][2]
[![OSV.NET NuGet Package Version][3]][4]
[![OSSF-Scorecard Score][5]][6]

.NET libraries for Open Source Vulnerabilities (OSV) schema and API client.
Currently support version 1.7.0 of the OSV schema.

## Usage

There are two ways to use the OSV.NET library:

- Manual instantiation of the `OSVClient` class
- Dependency Injection (DI) for better integration in ASP.NET Core applications

### Manual Instantiation

```C#
using OSV.Client;

var client = new OSVClient();

try
{
    // Query for vulnerabilities
    var query = new Query
    {
        Package = new Package
        {
            Name = "lodash",
            Ecosystem = "npm"
        },
        Version = "4.17.20"
    };

    var vulnerabilities = await client.QueryAffectedAsync(query);
    Console.WriteLine($"Found {vulnerabilities.Vulns.Count} vulnerabilities for lodash@4.17.20");

    // Get a specific vulnerability
    if (vulnerabilities.Vulns.Count > 0)
    {
        var vulnId = vulnerabilities.Vulns[0].Id;
        var vulnerability = await client.GetVulnerabilityAsync(vulnId);
        Console.WriteLine($"Vulnerability {vulnerability.Id}: {vulnerability.Summary}");
    }
}
catch (OSVException ex)
{
    Console.WriteLine($"OSV API Error: {ex.Message}");
    if (ex.StatusCode.HasValue)
    {
        Console.WriteLine($"HTTP Status: {ex.StatusCode}");
    }
}
finally
{
    client.Dispose();
}
```

### Dependency Injection

```C#
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Register OSV client
builder.Services.AddOSVClient(client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
    // Add any additional HttpClient configuration
});

var app = builder.Build();

// Use the client through dependency injection
var osvClient = app.Services.GetRequiredService<IOSVClient>();

// Use the client
var query = new Query
{
    Package = new Package
    {
        Name = "lodash",
        Ecosystem = "npm"
    },
    Version = "4.17.20"
};

var vulnerabilities = await osvClient.QueryAffectedAsync(query);
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
