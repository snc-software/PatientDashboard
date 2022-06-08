using Mapster;
using PatientDashboard.Data.Interfaces;
using PatientDashboard.ServiceInterface.Contracts;
using PatientDashboard.ServiceInterface.Responses.Clinics;

namespace PatientDashboard.Api.Endpoints.Clinics;

public class GetClinicsEndpoint : EndpointWithoutRequest<GetClinicsResponse>
{
    readonly IClinicRetriever _clinicRetriever;
    public GetClinicsEndpoint(IClinicRetriever clinicRetriever)
    {
        _clinicRetriever = clinicRetriever;
    }
    
    public override void Configure()
    {
        Get("clinics");
        Description(x => x.WithTags(SwaggerTags.Clinics));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var clinics = _clinicRetriever.GetAll();

        var response = new GetClinicsResponse
        {
            Clinics = clinics.Select(x => x.Adapt<Clinic>())
        };

        await SendOkAsync(response, ct);
    }
}