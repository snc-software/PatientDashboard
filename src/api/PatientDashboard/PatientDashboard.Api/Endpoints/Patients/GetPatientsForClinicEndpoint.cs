using Mapster;
using PatientDashboard.Data.Interfaces;
using PatientDashboard.ServiceInterface.Contracts;
using PatientDashboard.ServiceInterface.Requests.Patients;
using PatientDashboard.ServiceInterface.Responses.Patients;

namespace PatientDashboard.Api.Endpoints.Patients;

public class GetPatientsForClinicEndpoint : Endpoint<GetPatientsForClinicRequest, GetPatientsForClinicResponse>
{
    readonly IPatientRetriever _patientRetriever;

    public GetPatientsForClinicEndpoint(IPatientRetriever patientRetriever)
    {
        _patientRetriever = patientRetriever;
    }

    public override void Configure()
    {
        Get("clinics/{clinicId}/patients");
        Description(x => x.WithTags(SwaggerTags.Patients));
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPatientsForClinicRequest req, CancellationToken ct)
    {
        var patients = _patientRetriever.GetForClinic(req.ClinicId);

        var response = new GetPatientsForClinicResponse
        {
            Patients = patients.Select(x => x.Adapt<Patient>())
        };

        await SendOkAsync(response, ct);
    }
}