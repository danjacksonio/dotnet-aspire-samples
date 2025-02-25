using HybridCacheSample.Api.Models;
using System.Text;
using System.Text.Json;
using System.Web;

namespace HybridCacheSample.Api.Services
{
    public class OpenMeteoService : IOpenMeteoService
    {
        public async Task<City?> GetGeocodingAsync(string city)
        {
            // Fetch from OpenMeteo Geocoding API
            var client = new HttpClient();
            var encodedCity = HttpUtility.UrlEncode(city);
            var url = $"https://geocoding-api.open-meteo.com/v1/search?name={encodedCity}&count=1&language=en&format=json";
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            // Deserialize JSON response by skipping the first node ("results")
            var cityData = JsonDocument.Parse(content).RootElement.GetProperty("results")[0].ToString();
            var model = JsonSerializer.Deserialize<City>(cityData);

            return model;
        }


        public async Task<WeatherForecast?> GetWeatherForecastAsync(City city)
        {
            // Fetch from OpenMeteo Weather API
            var client = new HttpClient();
            var url = new StringBuilder("https://api.open-meteo.com/v1/forecast?");
            url.Append($"latitude={city.Latitude}&longitude={city.Longitude}");
            url.Append($"&current=temperature_2m,relative_humidity_2m,apparent_temperature,is_day,precipitation,rain,showers,snowfall,weather_code,cloud_cover,wind_speed_10m,wind_direction_10m,wind_gusts_10m");
            var response = await client.GetAsync(url.ToString());
            var content = await response.Content.ReadAsStringAsync();

            // Deserialize JSON response
            var model = JsonSerializer.Deserialize<WeatherForecast>(content);

            // Add city
            if (model != null) model.City = city;

            return model;
        }
    }
}
