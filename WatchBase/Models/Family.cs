using System.Text.Json.Serialization;

namespace WatchBase.Models;
public record Family
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
