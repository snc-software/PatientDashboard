using System.Net;
using PatientDashboard.Api.IntegrationTests.Extensions;
using PatientDashboard.ServiceInterface.Responses.Clinics;

namespace PatientDashboard.Api.IntegrationTests.Clinics;

[TestClass]
public class GetClinicsIntegrationTests : IntegrationTestBase
{
    const string Path = "/clinics";
    
    [TestMethod]
    public async Task GetClinicsCanBeCalledAndReturnsOkWithResults()
    {
        var response = await Client.GetAsync(Path);
        
        var stringResponse = await response.Content.ReadAsStringAsync();
        var responseFromJson = stringResponse.FromJson<GetClinicsResponse>();
        responseFromJson.Should().NotBeNull();
        responseFromJson.Clinics.Should().NotBeNullOrEmpty();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}