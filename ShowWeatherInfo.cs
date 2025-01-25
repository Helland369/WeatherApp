using System.Text.Json;
using System.Text.Json.Serialization;
namespace WeatherApp;


class ShowWeatherInfo
{
    static ApiHelper api = new ApiHelper();

    private static readonly string _positonData = api.GetPositionData();
    private static readonly string _weatherData = api.GettWeatherData();

    LocationData ld = JsonSerializer.Deserialize<LocationData>(_positonData);
    WeatherData wd = JsonSerializer.Deserialize<WeatherData>(_weatherData);

    public ShowWeatherInfo()
    {
        WeatherMenu();
    }

    private void WeatherMenu() {
        Console.WriteLine($"Temp: {wd.main.temp}");
        Console.WriteLine($"Humidity: {wd.main.humidity}");
        Console.WriteLine($"Pressure: {wd.main.pressure}");
        Console.WriteLine($"City {ld.ip}");
        Console.WriteLine($"Country {ld.country}");
    }
}
