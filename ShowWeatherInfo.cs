using System.Text.Json;
using System.Text.Json.Serialization;
namespace WeatherApp;


public class ShowWeatherInfo
{
    private ApiHelper api = new ApiHelper();
    private MsSqlDB sql = new MsSqlDB();

    public ShowWeatherInfo()
    {
        // WeatherMenu().GetAwaiter().GetResult();
        WeatherMenu().GetAwaiter().GetResult();
    }

    public async Task<WeatherData> FetchWeatherData()
    {
        string weaterData = await api.GettWeatherDataAsync();
        return JsonSerializer.Deserialize<WeatherData>(weaterData);
    }

    private async Task DisplayWeatherInfo()
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

    public async Task WeatherMenu()
    {
        short choice = -1;
        Console.Clear();
        while (true)
        {
            Console.WriteLine("[1] Show current Weather" +
                              "[2] Search in the data base" +
                              "[0] EXIT");
            choice = Convert.ToInt16(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    await DisplayWeatherInfo();
                    break;
                case 2:
                    Console.WriteLine("Write the mane of a city you want to search for");
                    string city = Console.ReadLine();
                    city = char.ToUpper(city[0]) + city.Substring(1).ToLower();
                    await sql.ReadWeatherDataFromDB(city);
                    break;
                default:
                    break;
            }
        }
    }
}
