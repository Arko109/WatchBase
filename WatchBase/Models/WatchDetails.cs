using System.Text.Json.Serialization;

namespace WatchBase.Models;
public record WatchDetails
{
    [JsonPropertyName("wb")]
    public required WatchBaseMetadata Metadata { get; init; }

    [JsonPropertyName("reference_number")]
    public required string Reference { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("gender")]
    public required string Gender { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("brand")]
    public required Brand Brand { get; init; }

    [JsonPropertyName("family")]
    public required Family Family { get; init; }

    [JsonPropertyName("images")]
    public required IEnumerable<string> ImageUrls { get; init; }
}

public record WatchBaseMetadata
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    [JsonPropertyName("added")]
    public required DateOnly AddedOn { get; init; }

    [JsonPropertyName("modified")]
    public required DateOnly ModifiedOn { get; init; }

    [JsonPropertyName("published")]
    public required DateOnly PublishedOn { get; init; }
}