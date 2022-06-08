using System.Net;
using PatientDashboard.Api.IntegrationTests.Extensions;
using PatientDashboard.ServiceInterface.Responses;
using PatientDashboard.ServiceInterface.Responses.Patients;

namespace PatientDashboard.Api.IntegrationTests.Patients;

[TestClass]
public class GetPatientsForClinicIntegrationTests : IntegrationTestBase
{
    const string Path = "/clinics/1/patients";
    const string ErrorPath = "/clinics/99/patients";
    
    [TestMethod]
    public async Task GetPatientsForClinicCanBeCalledAndReturnsOkWithResults()
    {
        var response = await Client.GetAsync(Path);
        
        var stringResponse = await response.Content.ReadAsStringAsync();
        var responseFromJson = stringResponse.FromJson<GetPatientsForClinicResponse>();
        responseFromJson.Should().NotBeNull();
        responseFromJson.Patients.Should().NotBeNullOrEmpty();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [TestMethod]
    public async Task GetPatientsForClinicReturnsExceptionResponseWhenInvalid()
    {
        var response = await Client.GetAsync(ErrorPath);
        
        var stringResponse = await response.Content.ReadAsStringAsync();
        var responseFromJson = stringResponse.FromJson<ExceptionResponse>();
        responseFromJson.Should().NotBeNull();
        responseFromJson.Message.Should().Be("No patient data for clinic 99");
    }
    
}