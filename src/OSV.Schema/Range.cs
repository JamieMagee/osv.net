namespace OSV.Schema;

/// <summary>
/// Affected ranges.
/// </summary>
public sealed record Range
{
    /// <summary>
    /// Required.
    /// The type of version information.
    /// </summary>
    [JsonPropertyName("type")]
    public RangeType Type { get; set; }

    /// <summary>
    /// Required if type is GIT.
    /// The publicly accessible URL of the repo that can be directly passed to clone commands.
    /// </summary>
    [JsonPropertyName("repo")]
    public string? Repo { get; set; }

    /// <summary>
    /// Required.
    /// Version event information.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<Event> Events { get; set; } = null!;

    /// <summary>
    /// Optional.
    /// JSON object holding additional information about the range as defined by the database for which the record applies.
    /// </summary>
    [JsonPropertyName("database_specific")]
    public Dictionary<string, object>? DatabaseSpecific { get; set; }
}
