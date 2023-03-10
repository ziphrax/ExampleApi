using ExampleAPI;
using Microsoft.EntityFrameworkCore;

public class WeatherContext : DbContext
{
    public DbSet<WeatherForecast> Forecasts { get; set; } = null!;

    public WeatherContext(){
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySQL(
            Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING") 
            ?? ""
        );
}