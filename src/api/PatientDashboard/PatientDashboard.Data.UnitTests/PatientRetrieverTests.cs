using System.Data;
using FluentAssertions;
using Moq;
using PatientDashboard.Data.Interfaces;
using PatientDashboard.Data.Mappings;
using PatientDashboard.Data.Wrapper.Interfaces;
using PatientDashboard.Domain;

namespace PatientDashboard.Data.UnitTests;

[TestClass]
public class PatientRetrieverTests
{
    IPatientRetriever _retriever;
    Mock<ICsvReaderWrapper> _mockCsvReaderWrapper;
    Mock<IFileWrapper> _mockFileWrapper;

    IEnumerable<PatientModel> _patients;
    const int ClinicId = 1;

    [TestMethod]
    public void GetForClinicShouldThrowExceptionWhenFileDoesntExist()
    {
        SetupForFileToNotExist();
        
        Action action = () => _retriever.GetForClinic(99);

        action.Should().Throw<DataException>()
            .WithMessage("No patient data for clinic 99");
    }
    
    [TestMethod]
    public void GetForClinicReadsAllTheRecordsFromTheCsv()
    {
        _ = _retriever.GetForClinic(ClinicId);
        
        _mockCsvReaderWrapper
            .Verify(m => m.GetRecords<PatientModel, PatientDataMapper>(
                It.IsAny<StreamReader>()),Times.Once);
    }

    [TestMethod] 
    public void GetForClinicReturnsAllThePatientsForTheClinic()
    {
        var actual = _retriever.GetForClinic(ClinicId);

        actual.Should().BeEquivalentTo(_patients);
    }
    
    #region Supporting Code

    [TestInitialize]
    public void Setup()
    {
        SetupData();
        SetupMocks();
        SetupExpectations();
        SetupServiceUnderTest();
    }

    void SetupData()
    {
        _patients = new List<PatientModel>
        {
            new() { ClinicId = ClinicId, FirstName = "Sean", LastName = "Connery", DateOfBirth = new(1980, 1, 4) },
            new() { ClinicId = ClinicId, FirstName = "Daniel", LastName = "Craig", DateOfBirth = new(1985, 4, 9) },
            new() { ClinicId = ClinicId, FirstName = "Pierce", LastName = "Brosnan", DateOfBirth = new(1975, 3, 17) },
        };
    }

    void SetupMocks()
    {
        _mockFileWrapper = new();
        _mockCsvReaderWrapper = new();
    }

    void SetupExpectations()
    {
        _mockFileWrapper
            .Setup(m => m.Exists(It.IsAny<string>()))
            .Returns(true);

        _mockCsvReaderWrapper
            .Setup(m => m.GetRecords<PatientModel, PatientDataMapper>(
                It.IsAny<StreamReader>()))
            .Returns(_patients);
    }

    void SetupServiceUnderTest()
    {
        _retriever = new PatientRetriever(
            _mockCsvReaderWrapper.Object,
            _mockFileWrapper.Object);
    }

    void SetupForFileToNotExist()
    {
        _mockFileWrapper
            .Setup(m => m.Exists(It.IsAny<string>()))
            .Returns(false);
    }
    
    #endregion
}