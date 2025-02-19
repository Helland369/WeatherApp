using System.Text.Json;
using Backend.Data;
using Backend.Models;
using IPinfo;
using IPinfo.Models;

namespace Backend.Services;


public class WeatherServices
{
    private readonly HttpClient _httpClient;
    private readonly WeatherDbContext _context;
    private decimal _lon, _lat;

    public WeatherServices(HttpClient httpClient, WeatherDbContext context)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(HttpClient));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    private async Task GetLocationData()
    {
        string token = Environment.GetEnvironmentVariable("IPKEY");

        TimeSpan timeout = TimeSpan.FromSeconds(5);

        if (!string.IsNullOrEmpty(token))
        {
            IPinfoClient client = new IPinfoClient.Builder()
                .AccessToken(token)
                .HttpClientConfig(config => config
                        .Timeout(timeout)
                        .HttpClientInstance(_httpClient))
                        .Build();

            try
            {
                IPResponse response = await client.IPApi.GetDetailsAsync();
                _lon = Convert.ToDecimal(response.Longitude);
                _lat = Convert.ToDecimal(response.Latitude);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching data: {ex}");
            }
        }
        else
        {
            Console.WriteLine("Set you IP_INFO token as an environment variable!");
        }
    }

    public async Task<string> GetWeatherDataAsync()
    {
        await GetLocationData();

        try
        {
            string weatherApiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={_lat}&lon={_lon}&appid={Environment.GetEnvironmentVariable("WEATHERKEY")}&units=metric";
            var response = await _httpClient.GetAsync(weatherApiUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var weatherResponse = JsonDocument.Parse(json);

            var weatherData = new WeatherData
            {
                name = weatherResponse.RootElement.GetProperty("name").GetString() ?? "unknown",
                temp = weatherResponse.RootElement.GetProperty("main").GetProperty("temp").GetDecimal(),
                max_temp = weatherResponse.RootElement.GetProperty("main").GetProperty("temp_max").GetDecimal(),
                min_temp = weatherResponse.RootElement.GetProperty("main").GetProperty("temp_min").GetDecimal(),
                feels_like = weatherResponse.RootElement.GetProperty("main").GetProperty("feels_like").GetDecimal(),
                pressure = weatherResponse.RootElement.GetProperty("main").GetProperty("pressure").GetInt32(),
                latitude = _lat,
                longitude = _lon,
                humidity = weatherResponse.RootElement.GetProperty("main").GetProperty("humidity").GetInt32(),
                sea_level = weatherResponse.RootElement.GetProperty("main").TryGetProperty("sea_level", out var sea) ? (int)sea.GetDecimal() : 0,
                grnd_level = weatherResponse.RootElement.GetProperty("main").TryGetProperty("grnd_level", out var grnd) ? (int)grnd.GetDecimal() : 0
            };

            _context.WeatherData.Add(weatherData);
            await _context.SaveChangesAsync();

            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while fetching weather data: {ex}");
        }
    }

    public async Task<string> GetWeatherDataByCityAsync(string city)
    {
        if (string.IsNullOrEmpty(city))
            throw new ArgumentException("City name is required!");

        try
        {
            string weatherApiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={Environment.GetEnvironmentVariable("WEATHERKEY")}&units=metric";
            var response = await _httpClient.GetAsync(weatherApiUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var weatherResponse = JsonDocument.Parse(json);

            var weatherData = new WeatherData
            {
                name = weatherResponse.RootElement.GetProperty("name").GetString() ?? "unknown",
                temp = weatherResponse.RootElement.GetProperty("main").GetProperty("temp").GetDecimal(),
                max_temp = weatherResponse.RootElement.GetProperty("main").GetProperty("temp_max").GetDecimal(),
                min_temp = weatherResponse.RootElement.GetProperty("main").GetProperty("temp_min").GetDecimal(),
                feels_like = weatherResponse.RootElement.GetProperty("main").GetProperty("feels_like").GetDecimal(),
                pressure = weatherResponse.RootElement.GetProperty("main").GetProperty("pressure").GetInt32(),
                latitude = _lat,
                longitude = _lon,
                humidity = weatherResponse.RootElement.GetProperty("main").GetProperty("humidity").GetInt32(),
                sea_level = weatherResponse.RootElement.GetProperty("main").TryGetProperty("sea_level", out var sea) ? (int)sea.GetDecimal() : 0,
                grnd_level = weatherResponse.RootElement.GetProperty("main").TryGetProperty("grnd_level", out var grnd) ? (int)grnd.GetDecimal() : 0
            };

            _context.WeatherData.Add(weatherData);
            await _context.SaveChangesAsync();

            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while fetching weather data for city {city}: {ex}");
        }
    }
}
