﻿namespace OSV.Schema;

/// <summary>
/// Version events.
/// </summary>
public sealed record Event
{
    /// <summary>
    /// The earliest version/commit where this vulnerability was introduced in.
    /// </summary>
    [JsonPropertyName("introduced")]
    public string? Introduced { get; set; }

    /// <summary>
    /// The version/commit that this vulnerability was fixed in.
    /// </summary>
    [JsonPropertyName("fixed")]
    public string? Fixed { get; set; }

    /// <summary>
    /// The last known affected version.
    /// </summary>
    [JsonPropertyName("last_affected")]
    public string? LastAffected { get; set; }

    /// <summary>
    /// The limit to apply to the range.
    /// </summary>
    [JsonPropertyName("limit")]
    public string? Limit { get; set; }
}
