using Microsoft.AspNetCore.Mvc.Testing;

namespace ExampleAPI.Tests;

[TestClass]
public class ExampleAppIntegrationTests
{
    private HttpClient _client;

    public ExampleAppIntegrationTests()
    {
        var appFactory = new WebApplicationFactory<Program>();
        _client = appFactory.CreateClient();
    }

    [TestMethod]
    public async Task WeatherForecast_GetAsync_ReturnsSuccess()
    {
        var response = await _client.GetAsync("/WeatherForecast");
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        Assert.IsNotNull(responseString);
    }
}