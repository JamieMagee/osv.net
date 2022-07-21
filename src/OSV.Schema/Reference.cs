namespace OSV.Schema;

/// <summary>
/// Reference URL.
/// </summary>
public sealed record Reference
{
    /// <summary>
    /// Required.
    /// The type of the reference.
    /// </summary>
    [JsonPropertyName("type")]
    public ReferenceType Type { get; set; }

    /// <summary>
    /// Required.
    /// The URL.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
}
