using System.Net.Http;

namespace WeatherApp;

public class ApiHelper
{
    private readonly HttpClient _httpClient;
    private string _cachedPositionData;
    
    public ApiHelper()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GettWeatherDataAsync()
    {
        try
        {
            string weatherApiUrl = "https://api.openweathermap.org/data/2.5/weather?q=//CITY&appid=//APIKEI&units=metric";
            var response = await _httpClient.GetAsync(weatherApiUrl);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception exeption)
        {
            throw new Exception($"Error while fetching weather data: {exeption.Message}");
        }
    }

    public async Task<string> GetPositionDataAsync() 
    {
        if (_cachedPositionData == null)
        {
            try
            {
                string positonApiUrl = "https://ipapi.co/json/";
                var response = await _httpClient.GetAsync(positonApiUrl);

                response.EnsureSuccessStatusCode();
                _cachedPositionData = await response.Content.ReadAsStringAsync();
            }
            catch (Exception exeption)
            {
                throw new Exception($"Error while fetching position data: {exeption.Message}");
            }
            
        }
        return _cachedPositionData;       
    }
}
