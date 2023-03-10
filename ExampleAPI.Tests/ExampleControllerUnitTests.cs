using ExampleAPI.Controllers;
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
        var contextMock = new Mock<WeatherContext>();
        var controller = new WeatherForecastController(loggerMock.Object, contextMock.Object);

        var result = controller.Get();

        Assert.IsNotNull(result);
        
    }
}