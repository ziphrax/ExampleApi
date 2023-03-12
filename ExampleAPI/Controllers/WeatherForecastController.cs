using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _context.Forecasts.ToList();
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public IActionResult Post([FromBody] WeatherForecast forecast)
    {
        _context.Forecasts.Add(forecast);
        _context.SaveChanges();

        return CreatedAtRoute("GetWeatherForecast", new { id = forecast.Id }, forecast);
    }
}
