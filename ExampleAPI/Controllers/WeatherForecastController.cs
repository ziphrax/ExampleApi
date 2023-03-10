using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await _context.Forecasts.ToListAsync();
    }
}
