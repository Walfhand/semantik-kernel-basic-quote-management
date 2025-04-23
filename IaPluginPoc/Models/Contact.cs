using System.Text.Json.Serialization;

namespace IaPluginPoc.Models;

public record Contact
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("first_name")]
    public string Firstname { get; set; } = null!;

    [JsonPropertyName("last_name")] public string Lastname { get; set; } = null!;
}