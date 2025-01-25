namespace WeatherApp;

public class ApiHelper
{
    private readonly HttpClient _httpClient;
    private string _cachedPositionData;
    
    public ApiHelper()
    {
        _httpClient = new HttpClient();
    }

    public string GettWeatherData()
    {
        string weatherApiUrl = "https://api.openweathermap.org/data/2.5/weather?q=Fredrikstad&appid=//APIKEY&units=metric";
        HttpResponseMessage response = _httpClient.GetAsync(weatherApiUrl).GetAwaiter().GetResult();

        if (response.IsSuccessStatusCode)
        {
            return _httpClient.GetStringAsync(weatherApiUrl).GetAwaiter().GetResult();
        }
        else
        {
            throw new Exception($"Getting weather data failed: {response.ReasonPhrase}");
        }
    }

    public string GetPositionData() 
    {
        if (_cachedPositionData == null)
        {
            string positonApiUrl = "https://ipapi.co/json/";
            HttpResponseMessage response = _httpClient.GetAsync(positonApiUrl).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                _cachedPositionData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            else
            {
                throw new Exception($"Error when fetching data: {response.ReasonPhrase}");
            }
            
        }
        return _cachedPositionData;       
    }
}
