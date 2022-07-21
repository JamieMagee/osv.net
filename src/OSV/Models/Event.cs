namespace OSV.Models;

/// <summary>
/// Version events.
/// </summary>
public sealed record Event
{
    /// <summary>
    /// The earliest version/commit where this vulnerability was introduced in.
    /// </summary>
    [JsonPropertyName("introduced")]
    public string Introduced { get; set; } = null!;

    /// <summary>
    /// The version/commit that this vulnerability was fixed in.
    /// </summary>
    [JsonPropertyName("fixed")]
    public string Fixed { get; set; } = null!;

    /// <summary>
    /// The limit to apply to the range.
    /// </summary>
    [JsonPropertyName("limit")]
    public string Limit { get; set; } = null!;
}
