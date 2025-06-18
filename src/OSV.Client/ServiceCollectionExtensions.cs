namespace OSV.Client;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds OSV client services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="configureClient">An optional delegate that is used to configure the <see cref="HttpClient"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddOSVClient(this IServiceCollection services, Action<HttpClient>? configureClient = null)
    {
        var httpClientBuilder = services.AddHttpClient<IOSVClient, OSVClient>();

        if (configureClient != null)
        {
            httpClientBuilder.ConfigureHttpClient(configureClient);
        }
        else
        {
            httpClientBuilder.ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://api.osv.dev/v1/");
                var version = typeof(OSVClient).Assembly.GetName().Version;
                client.DefaultRequestHeaders.UserAgent.ParseAdd($"osv.net/{version}");
            });
        }

        return services;
    }

    /// <summary>
    /// Adds OSV client services to the specified <see cref="IServiceCollection"/> with a named client.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="name">The logical name of the HttpClient to configure.</param>
    /// <param name="configureClient">An optional delegate that is used to configure the <see cref="HttpClient"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddOSVClient(this IServiceCollection services, string name, Action<HttpClient>? configureClient = null)
    {
        var httpClientBuilder = services.AddHttpClient<IOSVClient, OSVClient>(name);

        if (configureClient != null)
        {
            httpClientBuilder.ConfigureHttpClient(configureClient);
        }
        else
        {
            httpClientBuilder.ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://api.osv.dev/v1/");
                var version = typeof(OSVClient).Assembly.GetName().Version;
                client.DefaultRequestHeaders.UserAgent.ParseAdd($"osv.net/{version}");
            });
        }

        return services;
    }
}
