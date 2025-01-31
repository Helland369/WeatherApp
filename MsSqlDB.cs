using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherApp;

public class MsSqlDB
{
    private string connectionString = "Server=localhost,1433;Database=WeatherApp;User Id=sa;Password=//PASSWORD;Encrypt=False;";

    ApiHelper api = new ApiHelper();

    public MsSqlDB()
    {
    }
    
    public async Task WriteDataToDB()
    {

        string weaterData = await api.GettWeatherDataAsync();
        WeatherData wd = JsonSerializer.Deserialize<WeatherData>(weaterData);

        string query = "INSERT INTO WeatherData (longitude, latitude, temp, feels_like, min_temp, max_temp, pressure, humidity, sea_level, grnd_level) VALUES (@longitude, @latitude, @temp, @feels_like, @min_temp, @max_temp, @pressure, @humidity, @sea_level, @grnd_level)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            // add parameters to avoid sql injection.
            command.Parameters.AddWithValue("@longitude", wd.coord.lon);
            command.Parameters.AddWithValue("@latitude", wd.coord.lat);
            command.Parameters.AddWithValue("@temp", wd.main.temp);
            command.Parameters.AddWithValue("@feels_like", wd.main.feels_like);
            command.Parameters.AddWithValue("@min_temp", wd.main.temp_min);
            command.Parameters.AddWithValue("@max_temp", wd.main.temp_max);
            command.Parameters.AddWithValue("@pressure", wd.main.pressure);
            command.Parameters.AddWithValue("@humidity", wd.main.humidity);
            command.Parameters.AddWithValue("@sea_level", wd.main.sea_level);
            command.Parameters.AddWithValue("@grnd_level", wd.main.grnd_level);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} rows inserted.");
        }
    }
}
