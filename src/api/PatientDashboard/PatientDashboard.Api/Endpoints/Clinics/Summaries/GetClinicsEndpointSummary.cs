using PatientDashboard.ServiceInterface.Responses.Clinics;

namespace PatientDashboard.Api.Endpoints.Clinics.Summaries;

public class GetClinicsEndpointSummary : Summary<GetClinicsEndpoint>
{
    public GetClinicsEndpointSummary()
    {
        Summary = "Gets all the clinics in the system.";
        Description = "Gets all the clinics in the system.";
        Response<GetClinicsResponse>(200, "All clinics have been successfully retrieved.");
    }
}