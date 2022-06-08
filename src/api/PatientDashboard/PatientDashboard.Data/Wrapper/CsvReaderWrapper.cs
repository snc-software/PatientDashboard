using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using PatientDashboard.Data.Wrapper.Interfaces;

namespace PatientDashboard.Data.Wrapper;

public class CsvReaderWrapper : ICsvReaderWrapper
{
    // This is just a wrapper, we expect the CsvReader to work so no tests required
    // This is so we can keep the exact same config everytime
    public IEnumerable<TData> GetRecords<TData, TDataMapper>(StreamReader content)
     where TDataMapper : ClassMap
    {
        using var csv = new CsvReader(content, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<TDataMapper>();
        return csv.GetRecords<TData>().ToList();
    }
}