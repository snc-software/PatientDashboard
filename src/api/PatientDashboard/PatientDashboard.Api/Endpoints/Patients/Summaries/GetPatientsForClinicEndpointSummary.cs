using PatientDashboard.ServiceInterface.Responses.Patients;

namespace PatientDashboard.Api.Endpoints.Patients.Summaries;

public class GetPatientsForClinicEndpointSummary : Summary<GetPatientsForClinicEndpoint>
{
    public GetPatientsForClinicEndpointSummary()
    {
        Summary = "Get all the patients for the specified clinic.";
        Description = "Get all the patients for the specified clinic.";
        Params = new Dictionary<string, string>
        {
            { "ClinicId", "The identifier of the clinic to get patients for." }
        };
        Response<GetPatientsForClinicResponse>(200, "All patients for the clinic are retrieved successfully.");
    }
}