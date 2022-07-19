namespace OSV.Models;

/// <summary>
/// Query format.
/// </summary>
public sealed record Query
{
    /// <summary>
    /// The commit hash to query for.
    /// If specified, `version` should not be set.
    /// </summary>
    [JsonPropertyName("commit")]
    public string? Commit { get; init; }

    /// <summary>
    /// The version string to query for.
    /// A fuzzy match is done against upstream versions.
    /// If specified, `commit` should not be set.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>
    /// The package to query against.
    /// When a `commit` hash is given, this is optional.
    /// </summary>
    [JsonPropertyName("package")]
    public Package Package { get; init; } = null!;
}
