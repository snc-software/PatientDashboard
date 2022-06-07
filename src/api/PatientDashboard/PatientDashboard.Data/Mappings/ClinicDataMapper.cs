using CsvHelper.Configuration;
using PatientDashboard.Domain;

namespace PatientDashboard.Data.Mappings;

public sealed class ClinicDataMapper : ClassMap<ClinicModel>
{
    public ClinicDataMapper()
    {
        Map(m => m.Id).Name("id");
        Map(m => m.Name).Name("name");
    }
}