namespace OSV.Models;

/// <summary>
/// Affected versions and commits.
/// </summary>
public sealed record Affected
{
    /// <summary>
    /// Required.
    /// Package information.
    /// </summary>
    [JsonPropertyName("package")]
    public Package Package { get; set; } = null!;

    /// <summary>
    /// Required.
    /// Range information.
    /// </summary>
    [JsonPropertyName("ranges")]
    public IEnumerable<Range> Ranges { get; set; } = null!;

    /// <summary>
    /// Optional.
    /// List of affected versions.
    /// </summary>
    [JsonPropertyName("versions")]
    public IEnumerable<string>? Versions { get; set; }

    /// <summary>
    /// Optional.
    /// JSON object holding additional information about the vulnerability as defined by the ecosystem for which the record applies.
    /// </summary>
    [JsonPropertyName("ecosystemSpecific")]
    public Dictionary<string, object>? EcosystemSpecific { get; set; }

    /// <summary>
    /// Optional.
    /// JSON object holding additional information about the\nvulnerability as defined by the database for which the record applies.
    /// </summary>
    [JsonPropertyName("databaseSpecific")]
    public Dictionary<string, object>? DatabaseSpecific { get; set; }
}
