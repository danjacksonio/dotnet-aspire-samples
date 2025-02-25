using System.Text.Json.Serialization;

namespace HybridCacheSample.Api.Models;

public class WeatherForecast
{
    public City City { get; set; } = new();
    public decimal UtcOffsetSeconds { get; set; }
    [JsonPropertyName("timezone")]
    public string Timezone { get; set; } = default!;
    [JsonPropertyName("timezone_abbreviation")]
    public string TimezoneAbbreviation { get; set; } = default!;
    [JsonPropertyName("current_units")]
    public CurrentUnits CurrentUnits { get; set; } = new();
    [JsonPropertyName("current")]
    public CurrentForecast Current { get; set; } = new();    
}
