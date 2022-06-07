using FluentAssertions;
using Moq;
using PatientDashboard.Data.Interfaces;
using PatientDashboard.Data.Mappings;
using PatientDashboard.Data.Wrapper.Interfaces;
using PatientDashboard.Domain;

namespace PatientDashboard.Data.UnitTests;

[TestClass]
public class ClinicRetrieverTests
{
    IClinicRetriever _retriever;
    Mock<ICsvReaderWrapper> _mockCsvReaderWrapper;

    IEnumerable<ClinicModel> _clinics;

    [TestMethod]
    public void GetAsyncRetrievesAllTheClinics()
    {
        var actualClinics = _retriever.GetAll();

        actualClinics.Should().BeEquivalentTo(_clinics);
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
        _clinics = new List<ClinicModel>()
        {
            new() { Id = 1, Name = "Clinic1" },
            new() { Id = 2, Name = "Clinic2" },
            new() { Id = 3, Name = "Clinic3" },
        };
    }
    
    void SetupMocks()
    {
        _mockCsvReaderWrapper = new();
    }

    void SetupExpectations()
    {
        _mockCsvReaderWrapper
            .Setup(m => m
                .GetRecords<ClinicModel, ClinicDataMapper>(
                    It.IsAny<StreamReader>()))
            .Returns(_clinics);
    }

    void SetupServiceUnderTest()
    {
        _retriever = new ClinicRetriever(
            _mockCsvReaderWrapper.Object);
    }

    #endregion
}