using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

[Table("WeatherData")]
public class WeatherData
{
    [Key]
    public int ID { get; set; }
    public int humidity { get; set; }
    public int sea_level { get; set; }
    public int grnd_level { get; set; }
    public int pressure { get; set; }
    public string name { get; set; } = string.Empty;
    public decimal temp { get; set; }
    public decimal max_temp { get; set; }
    public decimal min_temp { get; set; }
    public decimal feels_like { get; set; }
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
}
