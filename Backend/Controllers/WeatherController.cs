using Backend.Data;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[Route("api/weather")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly WeatherDbContext _context;
    private readonly WeatherServices _weatherServices;

    public WeatherController(WeatherDbContext context, WeatherServices services)
    {
        _context = context;
        _weatherServices = services;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherData>>> GetWeatherData()
    {
        var data = await _context.WeatherData.ToListAsync();
        Console.WriteLine($"Weather Data {data}");
        return data;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherData>> GetWeatherDataById(int id)
    {
        WeatherData? weatherData = await _context.WeatherData.FindAsync(id);
        return weatherData == null ? (ActionResult<WeatherData>)NotFound() : (ActionResult<WeatherData>)weatherData;
    }

    [HttpGet("live")]
    public async Task<IActionResult> GetLiveWeather()
    {
        try
        {
            var weatherData = await _weatherServices.GetWeatherDataAsync();
            return Ok(weatherData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error while fetching weather data: {ex.Message}");
        }
    }
}
