using System.Net.Http;
using IPinfo;
using IPinfo.Models;

namespace WeatherApp;

public class ApiHelper
{
    private readonly HttpClient _httpClient;
    private double lon, lat;
    
    public ApiHelper()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GettWeatherDataAsync()
    {
        await GetLoacationData();

        try
        {
            string weatherApiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=//APIKEY&units=metric";
            var response = await _httpClient.GetAsync(weatherApiUrl);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception exeption)
        {
            throw new Exception($"Error while fetching weather data: {exeption.Message}");
        }
    }

    public async Task GetLoacationData()
    {
        // api token
        string? token = "//APIKEY";

        // request time out
        TimeSpan timeOut = TimeSpan.FromSeconds(5);

        if (!token.Equals(null))
        {
            // initialize ipinfo client
            IPinfoClient clinet = new IPinfoClient.Builder()
                .AccessToken(token)
                .HttpClientConfig(config => config
                                  .Timeout(timeOut)
                                  .HttpClientInstance(_httpClient))
                                  .Build();

            try
            {
                IPResponse response = await clinet.IPApi.GetDetailsAsync();
                lon = Convert.ToDouble(response.Longitude);
                lat = Convert.ToDouble(response.Latitude);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Set your access token as IPINFO_TOKEN in environment variables in order to run this sample code. You can also set your token string in the code manually.");
        }
    }
}
