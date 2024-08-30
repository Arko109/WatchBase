using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WatchBase.Models;

public record Watch
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    [JsonPropertyName("refnr")]
    public required string Reference { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("brand")]
    public required Brand Brand { get; init; }

    [JsonPropertyName("family")]
    public required Family Family { get; init; }

    [JsonPropertyName("thumb")]
    public required string Thumbnail { get; init; }

    [JsonPropertyName("updated")]
    public required DateOnly UpdatedOn { get; init; }
}
