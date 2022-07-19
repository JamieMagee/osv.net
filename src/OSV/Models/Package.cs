namespace OSV.Models;

/// <summary>
/// Package information and version.
/// </summary>
public sealed record Package
{
    /// <summary>
    /// Required.
    /// Name of the package.
    /// Should match the name used in the package ecosystem (e.g. the npm package name).
    /// For C/C++ projects integrated in OSS-Fuzz, this is the name used for the integration.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    /// <summary>
    /// Required.
    /// The ecosystem for this package.
    /// For the complete list of valid ecosystem names, see https://ossf.github.io/osv-schema/#affectedpackage-field.
    /// </summary>
    [JsonPropertyName("ecosystem")]
    public Ecosystem Ecosystem { get; init; }

    /// <summary>
    /// Optional.
    /// The package URL for this package.
    /// </summary>
    [JsonPropertyName("purl")]
    public string? Purl { get; init; }
}
