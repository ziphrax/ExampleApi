using ExampleAPI;
using Microsoft.EntityFrameworkCore;

public class WeatherContext : DbContext, IWeatherContext
{
    public virtual DbSet<WeatherForecast> Forecasts { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySQL(
            Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING") 
            ?? ""
        );

    public void MarkAsModified(WeatherForecast item)
    {
        Entry(item).State = EntityState.Modified;
    }
}