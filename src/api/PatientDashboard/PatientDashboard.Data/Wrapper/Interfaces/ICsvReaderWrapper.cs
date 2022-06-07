using CsvHelper.Configuration;

namespace PatientDashboard.Data.Wrapper.Interfaces;

public interface ICsvReaderWrapper
{
    IEnumerable<TData> GetRecords<TData, TDataMapper>(
        StreamReader content)
        where TDataMapper : ClassMap;
}