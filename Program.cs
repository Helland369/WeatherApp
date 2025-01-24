

using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherApp;

class Program
{
    static void Main(string[] args)
    {
        ApiHelper api = new ApiHelper();

        string positonData = api.GetPositionData();
        string json = api.GettWeatherData();
        
        LocationData ld = JsonSerializer.Deserialize<LocationData>(positonData);
        WeatherData wd = JsonSerializer.Deserialize<WeatherData>(json);
        
        Console.WriteLine($"Temp: {wd.main.temp}");
        Console.WriteLine($"Humidity: {wd.main.humidity}");
        Console.WriteLine($"Pressure: {wd.main.pressure}");
        Console.WriteLine($"City {ld.city}");
        Console.WriteLine($"Country {ld.country}");
    }
}