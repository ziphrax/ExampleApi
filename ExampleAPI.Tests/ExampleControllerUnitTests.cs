using ExampleAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace ExampleAPI.Tests;

[TestClass]
public class ExampleControllerUnitTests
{
    [TestMethod]
    public void WeatherForecast_Get_Returns_Success()
    {
        var loggerMock = new Mock<ILogger<WeatherForecastController>>();

        var data = new List<WeatherForecast>
        {
            new WeatherForecast
            {
                Date = new DateOnly(2023, 1, 1),
                TemperatureC = 1,
                Summary = "Test"
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<WeatherForecast>>();
        mockSet.As<IQueryable<WeatherForecast>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<WeatherForecast>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<WeatherForecast>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<WeatherForecast>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var contextMock = new Mock<WeatherContext>();
        contextMock.Setup(x => x.Forecasts).Returns(mockSet.Object);

        var controller = new WeatherForecastController(loggerMock.Object, contextMock.Object);

        var forecasts = controller.Get();

        Assert.AreEqual(1, forecasts.Count());
        
    }
}