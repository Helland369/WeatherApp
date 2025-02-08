namespace WeatherApi;


public class WeatherData
{
    public int ID { get; set; }
    public double longitude { get; set; }
    public double latitude { get; set; }
    public double temp { get; set; }
    public double feels_like { get; set; }
    public double min_temp { get; set; }
    public double max_temp { get; set; }
    public double pressure { get; set; }
    public double humidity { get; set; }
    public double sea_level { get; set; }
    public double grnd_level { get; set; }
    public string? name { get; set; }
}
