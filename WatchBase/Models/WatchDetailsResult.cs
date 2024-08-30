using System.Text.Json.Serialization;

namespace WatchBase.Models;
public record WatchDetailsResult
{
    [JsonPropertyName("watch")]
    public required WatchDetails Watch { get; set; }
}
