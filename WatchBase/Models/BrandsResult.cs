using System.Text.Json.Serialization;

namespace WatchBase.Models;
public record BrandsResult
{
    [JsonPropertyName("num_results")]
    public required int Count { get; init; }

    [JsonPropertyName("brands")]
    public required IEnumerable<Brand> Brands { get; init; }
}
