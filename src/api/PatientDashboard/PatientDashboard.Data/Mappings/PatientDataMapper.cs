using CsvHelper.Configuration;
using PatientDashboard.Domain;

namespace PatientDashboard.Data.Mappings;

public sealed class PatientDataMapper : ClassMap<PatientModel>
{
    public PatientDataMapper()
    {
        Map(m => m.Id).Name("id");
        Map(m => m.ClinicId).Name("clinic_id");
        Map(m => m.FirstName).Name("first_name");
        Map(m => m.LastName).Name("last_name");
        Map(m => m.DateOfBirth).Name("date_of_birth");
        
    }
}