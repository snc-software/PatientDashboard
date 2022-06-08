using PatientDashboard.Api.Endpoints.Clinics.Summaries;

namespace PatientDashboard.Api.UnitTests.Endpoints.Clinics.Summaries;

[TestClass]
public class GetClinicsEndpointSummaryTests
{
    [TestMethod]
    public void GetClinicsEndpointSummaryIsGeneratedCorrectly()
    {
        var expectedResponses = new Dictionary<int, string>
        {
            { 200, "All clinics have been successfully retrieved." }
        };
        
        var summary = new GetClinicsEndpointSummary();

        summary.Summary.Should().Be("Gets all the clinics in the system.");
        summary.Description.Should().Be("Gets all the clinics in the system.");
        summary.Responses.Should().BeEquivalentTo(expectedResponses);
    }
}