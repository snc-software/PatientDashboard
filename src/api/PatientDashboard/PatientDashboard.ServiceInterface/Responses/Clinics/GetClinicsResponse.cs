namespace PatientDashboard.ServiceInterface.Responses.Clinics;

public class GetClinicsResponse
{
    public IEnumerable<Clinic> Clinics { get; set; }
}