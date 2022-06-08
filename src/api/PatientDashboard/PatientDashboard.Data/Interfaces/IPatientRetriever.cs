using PatientDashboard.Domain;

namespace PatientDashboard.Data.Interfaces;

public interface IPatientRetriever
{
    IEnumerable<PatientModel> GetForClinic(int clinicId);
}