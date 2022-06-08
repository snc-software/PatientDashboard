using PatientDashboard.Data.Wrapper.Interfaces;

namespace PatientDashboard.Data.Wrapper;

public class FileWrapper : IFileWrapper
{
    public bool Exists(string filePath)
    {
        return File.Exists(filePath);
    }
}