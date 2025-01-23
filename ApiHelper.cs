namespace WeatherApp;

public class ApiHelper
{
    private string _apiUrl = "https://api.openweathermap.org/data/2.5/weather?q=Fredrikstad&appid=//APIKEY";

    private HttpClient _httpClient;

    public ApiHelper()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_apiUrl);
    }

    public string GettWeatherData()
    {
        return _httpClient.GetStringAsync(_apiUrl).GetAwaiter().GetResult();
    }
}
