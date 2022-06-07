using PatientDashboard.Data;
using PatientDashboard.Data.Interfaces;
using PatientDashboard.Data.Wrapper;
using PatientDashboard.Data.Wrapper.Interfaces;

namespace PatientDashboard.Api.DependencyInjection;

public static class DataDependencyInjection
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<ICsvReaderWrapper, CsvReaderWrapper>();
        services.AddScoped<IFileWrapper, FileWrapper>();
        services.AddScoped<IPatientRetriever, PatientRetriever>();
        services.AddScoped<IClinicRetriever, ClinicRetriever>();
        return services;
    }
}