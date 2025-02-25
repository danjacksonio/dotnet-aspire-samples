using System.Text.Json.Serialization;

namespace HybridCacheSample.Api.Models;

public class City
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
    [JsonPropertyName("longitude")]
    public decimal Longitude { get; set; }
    [JsonPropertyName("latitude")]
    public decimal Latitude { get; set; }
    [JsonPropertyName("elevation")]
    public decimal Elevation { get; set; }
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; } = default!;
}
