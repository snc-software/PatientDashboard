using System.Globalization;
using System.Reflection;
using CsvHelper;
using PatientDashboard.Data.Interfaces;
using PatientDashboard.Data.Mappings;
using PatientDashboard.Data.Wrapper.Interfaces;
using PatientDashboard.Domain;

namespace PatientDashboard.Data;

public class ClinicRetriever : IClinicRetriever
{
    readonly ICsvReaderWrapper _csvReaderWrapper;
    public ClinicRetriever(ICsvReaderWrapper csvReaderWrapper)
    {
        _csvReaderWrapper = csvReaderWrapper;
    }
    
    public IEnumerable<ClinicModel> GetAll()
    {
        var basePath = 
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = basePath + "/Data/clinics.csv";
        using var reader = new StreamReader(path);
        return _csvReaderWrapper
            .GetRecords<ClinicModel, ClinicDataMapper>(reader);
    }
}