using PatientDashboard.Api.Endpoints.Patients.Summaries;

namespace PatientDashboard.Api.UnitTests.Endpoints.Patients.Summaries;

[TestClass]
public class GetPatientsForClinicEndpointSummaryTests
{
    [TestMethod]
    public void GetPatientsForClinicEndpointSummaryIsGeneratedCorrectly()
    {
        var expectedParams = new Dictionary<string, string>
        {
            { "ClinicId", "The identifier of the clinic to get patients for." }
        };

        var expectedResponses = new Dictionary<int, string>
        {
            { 200, "All patients for the clinic are retrieved successfully." }
        };
        
        var summary = new GetPatientsForClinicEndpointSummary();

        summary.Summary.Should().Be("Get all the patients for the specified clinic.");
        summary.Description.Should().Be("Get all the patients for the specified clinic.");
        summary.Params.Should().BeEquivalentTo(expectedParams);
        summary.Responses.Should().BeEquivalentTo(expectedResponses);
    }
}