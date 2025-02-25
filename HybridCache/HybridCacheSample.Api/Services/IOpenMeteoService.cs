using HybridCacheSample.Api.Models;

namespace HybridCacheSample.Api.Services
{
    public interface IOpenMeteoService
    {
        Task<City?> GetGeocodingAsync(string city);
        Task<WeatherForecast?> GetWeatherForecastAsync(City city);
    }
}
