using System.Reflection;

namespace PatientDashboard.Data.BaseClasses;

public abstract class RetrieverBase
{
    protected string BasePath => 
        Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location)
        + "/Data/";
}