using Microsoft.Data.SqlClient;

namespace WeatherApp;

public class MsSqlDB
{
    private string connectionString = "Server=localhost;Database=WeatherData;User Id=sa;Password=;Encrypt=False;";

    public MsSqlDB()
    {
        MsSqlConnect();
    }
    
    public void MsSqlConnect()
    {
        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            Console.WriteLine("MS-SQL connection success!");

        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error: {exception}");
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
            //}
    }
}
