namespace OSV.Models;

public sealed record Credit
{
    /// <summary>
    /// The name to give credit to.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    /// <summary>
    /// Contact methods (URLs).
    /// </summary>
    [JsonPropertyName("contact")]
    public IEnumerable<string> Contact { get; init; } = null!;
}
