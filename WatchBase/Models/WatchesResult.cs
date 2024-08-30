using System.Text.Json.Serialization;

namespace WatchBase.Models;

public record WatchesResult
{
    [JsonPropertyName("num_results")]
    public required int Count { get; init; }

    [JsonPropertyName("watches")]
    public required IEnumerable<Watch> Watches { get; init; }
}
