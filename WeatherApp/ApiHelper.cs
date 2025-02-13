using System.Net.Http;
using IPinfo;
using IPinfo.Models;

namespace WeatherApp;

public class ApiHelper
{
    // referance Httpclient
    private readonly HttpClient _httpClient;
    // longitude and latitude for weather api
    private double _lon, _lat;

    public ApiHelper()
    {
        // make Httpclient
        _httpClient = new HttpClient();
    }

    public async Task<string> GettWeatherDataAsync()
    {
        await GetLoacationData();

        try
        {
            // weather api
            string weatherApiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={_lat}&lon={_lon}&appid=//APIKEY&units=metric";
            // weather response
            var response = await _httpClient.GetAsync(weatherApiUrl);
            // Ensure successfull response
            response.EnsureSuccessStatusCode();
            // return response
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception exeption)
        {
            // if error
            throw new Exception($"Error while fetching weather data: {exeption.Message}");
        }
    }

    private async Task GetLoacationData()
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
                // get response
                IPResponse response = await clinet.IPApi.GetDetailsAsync();
                // set longitude and latitude
                _lon = Convert.ToDouble(response.Longitude);
                _lat = Convert.ToDouble(response.Latitude);
            }
            catch (Exception ex)
            {
                // if error
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        else
        {
            // if no response
            Console.WriteLine("Set your access token as IPINFO_TOKEN in environment variables in order to run this sample code. You can also set your token string in the code manually.");
        }
    }
}
