namespace PatientDashboard.Api.IntegrationTests.Health;

[TestClass]
public class HealthIntegrationTests : IntegrationTestBase
{
    [TestMethod]
    public async Task TheHealthEndpointCanBeCalledAndReturnsHealthy()
    {
        var response = await Client.GetAsync("/health");
        var stringResponse = await response.Content.ReadAsStringAsync();

        stringResponse.Should().Be("Healthy");
    }
}