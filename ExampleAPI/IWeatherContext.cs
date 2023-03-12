
using ExampleAPI;
using Microsoft.EntityFrameworkCore;

public interface IWeatherContext : IDisposable
{
    DbSet<WeatherForecast> Forecasts { get; set; }
    
    int SaveChanges();
    
    void MarkAsModified(WeatherForecast item);    
}