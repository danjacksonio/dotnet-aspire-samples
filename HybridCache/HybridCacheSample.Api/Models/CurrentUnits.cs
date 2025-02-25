using System.Text.Json.Serialization;

namespace HybridCacheSample.Api.Models;

public class CurrentUnits
{
    [JsonPropertyName("time")]
    public string Time { get; set; } = default!;
    [JsonPropertyName("interval")]
    public string Interval { get; set; } = default!;

    [JsonPropertyName("temperature_2m")]
    public string Temperature { get; set; } = default!;
    [JsonPropertyName("relative_humidity_2m")]
    public string RelativeHumidity { get; set; } = default!;
    [JsonPropertyName("apparent_temperature")]
    public string ApparentTemperature { get; set; } = default!;
    [JsonPropertyName("is_day")]
    public string IsDay { get; set; } = default!;
    [JsonPropertyName("precipitation")]
    public string Precipitation { get; set; } = default!;
    [JsonPropertyName("rain")]
    public string Rain { get; set; } = default!;
    [JsonPropertyName("showers")]
    public string Showers { get; set; } = default!;
    [JsonPropertyName("snowfall")]
    public string Snowfall { get; set; } = default!;
    [JsonPropertyName("weather_code")]
    public string WeatherCode { get; set; } = default!;
    [JsonPropertyName("cloud_cover")]
    public string CloudCover { get; set; } = default!;
    [JsonPropertyName("wind_speed_10m")]
    public string WindSpeed { get; set; } = default!;
    [JsonPropertyName("wind_direction_10m")]
    public string WindDirection { get; set; } = default!;
    [JsonPropertyName("wind_gusts_10m")]
    public string WindGusts { get; set; } = default!;
}
