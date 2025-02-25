using HybridCacheSample.Api.Models;
using HybridCacheSample.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Hybrid;
using System.Net;

namespace HybridCacheSample.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
    ILogger<WeatherForecastController> logger,
    HybridCache hybridCache,
    IOpenMeteoService openMeteoService)
    : ControllerBase
{
    private readonly IOpenMeteoService _openMeteoService = openMeteoService;
    private readonly ILogger<WeatherForecastController> _logger = logger;
    private readonly HybridCache _hybridCache = hybridCache;

    /// <summary>
    /// Get weather forecast for a city
    /// </summary>
    /// <param name="city">City to search for (e.g. "Paris" or "Paris, France")</param>
    /// <returns><see cref="WeatherForecast"/></returns>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(typeof(WeatherForecast), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Get(string city)
    {
        City? geocoding = null;
        WeatherForecast? weatherForecast = null;

        var cityCacheKey = $"geocoding:{city}";
        geocoding = await _hybridCache.GetOrCreateAsync<City?>(cityCacheKey, async _ =>
            await _openMeteoService.GetGeocodingAsync(city), tags: ["geocoding"]);

        // Geocoding null check
        if (geocoding is null)
            return BadRequest("City not found");

        // Geocoding longitude and latitude check
        if (geocoding.Longitude == 0 && geocoding.Latitude == 0)
            return BadRequest("City not found");
        
        var weatherCacheKey = $"weather:{city}";
        weatherForecast = await _hybridCache.GetOrCreateAsync<WeatherForecast?>(weatherCacheKey, async _ =>
            await _openMeteoService.GetWeatherForecastAsync(geocoding), tags: ["weather"]);

        // WeatherForecast null check
        if (weatherForecast is null)
            return BadRequest("Weather forecast not found");

        return Ok(weatherForecast);
    }

    /// <summary>
    /// Clear cached results
    /// </summary>
    /// <param name="tag">Cache tag to clear (either "weather" or "geocoding")</param>
    [HttpGet("clear/{tag}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Clear(string tag)
    {
        await _hybridCache.RemoveByTagAsync(tag);
        return Ok();
    }
}
