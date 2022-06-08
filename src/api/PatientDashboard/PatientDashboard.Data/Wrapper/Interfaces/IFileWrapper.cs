namespace PatientDashboard.Data.Wrapper.Interfaces;

public interface IFileWrapper
{
    bool Exists(string filePath);
}