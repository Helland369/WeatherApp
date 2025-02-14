using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class WeatherDbContext(DbContextOptions<WeatherDbContext> options) : DbContext(options)
{
    public DbSet<WeatherData> WeatherData => Set<WeatherData>();
}
