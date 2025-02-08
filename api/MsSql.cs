using Microsoft.Data.SqlClient;
using Dapper;

namespace WeatherApi;

public class MsSql
{
    private SqlConnection _connection;

    public MsSql(SqlConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<WeatherData>> ReadWeatherData()
    {
        var sql = "SELECT * FROM WeatherData";
        return await _connection.QueryAsync<WeatherData>(sql);
    }
}
