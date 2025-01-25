using System.Text.Json;
using System.Text.Json.Serialization;
namespace WeatherApp;


class ShowWeatherInfo
{
    private ApiHelper api = new ApiHelper();

    public ShowWeatherInfo()
    {
        WeatherMenu().GetAwaiter().GetResult();
    }

    private async Task WeatherMenu()
    {
        try
        {
            string positionData = await api.GetPositionDataAsync();
            string weaterData = await api.GettWeatherDataAsync();

            var location = JsonSerializer.Deserialize<LocationData>(positionData);
            var weather = JsonSerializer.Deserialize<WeatherData>(weaterData);

            if (location != null && weather != null)
            {
                Console.WriteLine($"Temp: {weather.main.temp}C");
                Console.WriteLine($"Humidity: {weather.main.humidity}%");
                Console.WriteLine($"Presure: {weather.main.pressure} hpa");
                Console.WriteLine($"City: {location.city}");
                Console.WriteLine($"Country: {location.country}");
            }
        }
        catch (Exception exeption)
        {
            Console.WriteLine($"An error occurred: {exeption.Message}");
        }
    }
}
