using System.Text.Json;
using System.Text.Json.Serialization;
namespace WeatherApp;


public class ShowWeatherInfo
{
    private ApiHelper api = new ApiHelper();

    public ShowWeatherInfo()
    {
        WeatherMenu().GetAwaiter().GetResult();
    }

    public async Task<WeatherData> FetchWeatherData()
    {
        string weaterData = await api.GettWeatherDataAsync();
        return JsonSerializer.Deserialize<WeatherData>(weaterData);
    }

    private async Task WeatherMenu()
    {
        try
        {
            string weaterData = await api.GettWeatherDataAsync();

            var weather = JsonSerializer.Deserialize<WeatherData>(weaterData);

            Console.Clear();
            Console.WriteLine($"Place: {weather.name}");
            Console.WriteLine($"Timezone: {weather.timezone}");
            Console.WriteLine($"Latitude: {weather.coord.lat}");
            Console.WriteLine($"Longditude: {weather.coord.lon}");
            Console.WriteLine($"Temp: {weather.main.temp}C");
            Console.WriteLine($"Feels like: {weather.main.feels_like}C");
            Console.WriteLine($"Max temp: {weather.main.temp_min}C");
            Console.WriteLine($"Min temp: {weather.main.temp_min}C");
            Console.WriteLine($"Pressure: {weather.main.pressure}");
            Console.WriteLine($"Humidity: {weather.main.humidity}");
            Console.WriteLine($"Sea level: {weather.main.sea_level}");
        }
        catch (Exception exeption)
        {
            Console.WriteLine($"An error occurred: {exeption.Message}");
        }

    }
}
