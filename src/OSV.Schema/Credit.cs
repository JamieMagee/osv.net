namespace OSV.Schema;

public sealed record Credit
{
    /// <summary>
    /// The name to give credit to.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Contact methods (URLs).
    /// </summary>
    [JsonPropertyName("contact")]
    public IEnumerable<string> Contact { get; set; } = null!;
}
