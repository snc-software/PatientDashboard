namespace PatientDashboard.ServiceInterface.Responses.Patients;

public class GetPatientsForClinicResponse
{
    public IEnumerable<Patient> Patients { get; set; }
}