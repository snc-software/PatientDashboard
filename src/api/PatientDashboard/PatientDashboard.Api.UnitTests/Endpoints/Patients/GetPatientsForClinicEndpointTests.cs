using PatientDashboard.Api.Endpoints.Patients;
using PatientDashboard.ServiceInterface.Contracts;
using PatientDashboard.ServiceInterface.Requests.Patients;
using PatientDashboard.ServiceInterface.Responses.Patients;

namespace PatientDashboard.Api.UnitTests.Endpoints.Patients;

[TestClass]
public class GetPatientsForClinicEndpointTests
{
    GetPatientsForClinicEndpoint _endpoint;
    GetPatientsForClinicRequest _request;
    IList<PatientModel> _patientsForClinic;

    Mock<IPatientRetriever> _mockPatientRetriever;
    const int ClinicId = 1;

    [TestMethod]
    public async Task HandleAsyncShouldGetThePatientsFromTheDataSource()
    {
        await _endpoint.HandleAsync(_request, default);
        
        _mockPatientRetriever
            .Verify(m => m.GetForClinic(ClinicId),
                Times.Once);
    }
    
    [TestMethod]
    public async Task HandleAsyncShouldRespondOkWithTheResponseBuiltFromTheData()
    {
        var expectedResponse = new GetPatientsForClinicResponse
        {
            Patients = _patientsForClinic.Select(x =>
                new Patient
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth
                })
        };
        
        await _endpoint.HandleAsync(_request, default);
        
        _endpoint.Response.Should().BeEquivalentTo(expectedResponse);
        _endpoint.HttpContext.Response.StatusCode.Should().Be((int)HttpStatusCode.OK);
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
        _patientsForClinic = new List<PatientModel>
        {
            new() { ClinicId = ClinicId, FirstName = "Sean", LastName = "Connery", DateOfBirth = new(1980, 1, 4) },
            new() { ClinicId = ClinicId, FirstName = "Daniel", LastName = "Craig", DateOfBirth = new(1985, 4, 9) },
            new() { ClinicId = ClinicId, FirstName = "Pierce", LastName = "Brosnan", DateOfBirth = new(1975, 3, 17) },
        };

        _request = new() { ClinicId = ClinicId };
    }

    void SetupMocks()
    {
        _mockPatientRetriever = new();
    }

    void SetupExpectations()
    {
        _mockPatientRetriever
            .Setup(m => m.GetForClinic(ClinicId))
            .Returns(_patientsForClinic);
    }

    void SetupServiceUnderTest()
    {
        _endpoint = Factory.Create<GetPatientsForClinicEndpoint>(
            _mockPatientRetriever.Object);
    }
    
    #endregion
}