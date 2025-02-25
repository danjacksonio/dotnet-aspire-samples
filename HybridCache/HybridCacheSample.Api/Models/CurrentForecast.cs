using System.Text.Json.Serialization;

namespace HybridCacheSample.Api.Models
{
    public class CurrentForecast
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("interval")]
        public int Interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public decimal Temperature { get; set; }
        public decimal TemperatureF => 32 + (int)(Temperature / 0.5556M);
        [JsonPropertyName("relative_humidity_2m")]
        public decimal RelativeHumidity { get; set; }
        [JsonPropertyName("apparent_temperature")]
        public decimal ApparentTemperature { get; set; }
        public decimal ApparentTemperatureF => 32 + (int)(ApparentTemperature / 0.5556M);
        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }
        [JsonPropertyName("precipitation")]
        public decimal Precipitation { get; set; }
        [JsonPropertyName("rain")]
        public decimal Rain { get; set; }
        [JsonPropertyName("showers")]
        public decimal Showers { get; set; }
        [JsonPropertyName("snowfall")]
        public decimal Snowfall { get; set; }
        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }
        [JsonPropertyName("cloud_cover")]
        public decimal CloudCover { get; set; }
        [JsonPropertyName("wind_speed_10m")]
        public decimal WindSpeed { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public decimal WindDirection { get; set; }
        [JsonPropertyName("wind_gusts_10m")]
        public decimal WindGusts { get; set; }
    }
}
