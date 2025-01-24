namespace WeatherApp;

public class ApiHelper
{
    private HttpClient _httpClient;

    public ApiHelper()
    {
        _httpClient = new HttpClient();
    }

    public string GettWeatherData()
    {
        string weatherApiUrl = "https://api.openweathermap.org/data/2.5/weather?q=Fredrikstad&appid=//APIKEY&units=metri";
        return _httpClient.GetStringAsync(weatherApiUrl).GetAwaiter().GetResult();
    }

    public string GetPositionData()
    {
        string postionApiUrl = "https://ipapi.co/json";
        return _httpClient.GetStringAsync(postionApiUrl).GetAwaiter().GetResult();
    }
}
