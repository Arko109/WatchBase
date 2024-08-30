using System.Text.Json.Serialization;

namespace WatchBase.Models;

public record FamiliesResult
{
    [JsonPropertyName("num_results")]
    public required int Count { get; init; }

    [JsonPropertyName("families")]
    public required IEnumerable<Family> Families { get; init; }
}
