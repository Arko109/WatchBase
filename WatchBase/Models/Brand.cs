using System.Text.Json.Serialization;

namespace WatchBase.Models;
public record class Brand
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("logo")]
    public string? LogoUrl { get; init; }

    [JsonPropertyName("website")]
    public string? WebsiteUrl { get; init; }
}
