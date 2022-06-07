using System.Data;
using PatientDashboard.Data.BaseClasses;
using PatientDashboard.Data.Interfaces;
using PatientDashboard.Data.Mappings;
using PatientDashboard.Data.Wrapper.Interfaces;
using PatientDashboard.Domain;

namespace PatientDashboard.Data;

public class PatientRetriever : RetrieverBase, IPatientRetriever
{
    readonly ICsvReaderWrapper _csvReaderWrapper;
    readonly IFileWrapper _fileWrapper;

    public PatientRetriever(ICsvReaderWrapper csvReaderWrapper, IFileWrapper fileWrapper)
    {
        _csvReaderWrapper = csvReaderWrapper;
        _fileWrapper = fileWrapper;
    }
    
    public IEnumerable<PatientModel> GetForClinic(int clinicId)
    {
        var fileName = $"patients-{clinicId}.csv";
        var path = BasePath + fileName;
        if (!_fileWrapper.Exists(path))
        {
            throw new DataException($"No patient data for clinic {clinicId}");
        }
        using var reader = new StreamReader(path);
        return _csvReaderWrapper
            .GetRecords<PatientModel, PatientDataMapper>(reader);
    }
}