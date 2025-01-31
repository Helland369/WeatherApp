

using WeatherApp;

class Program
{
    static async Task Main(string[] args)
    {
        ShowWeatherInfo swi = new ShowWeatherInfo();
        MsSqlDB sql = new MsSqlDB();
        await sql.WriteDataToDB();
    }
}
