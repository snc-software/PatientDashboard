using PatientDashboard.Domain;

namespace PatientDashboard.Data.Interfaces;

public interface IClinicRetriever
{
    IEnumerable<ClinicModel> GetAll();
}