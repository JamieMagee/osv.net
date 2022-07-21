namespace OSV.Models;

/// <summary>
/// Batch query format.
/// </summary>
public sealed record BatchQuery
{
    /// <summary>
    /// The queries that form this batch query.
    /// </summary>
    [JsonPropertyName("queries")]
    public IEnumerable<Query> Queries { get; set; } = null!;
}
