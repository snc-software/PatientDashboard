using PatientDashboard.Api.Endpoints.Clinics;
using PatientDashboard.ServiceInterface.Contracts;
using PatientDashboard.ServiceInterface.Responses.Clinics;

namespace PatientDashboard.Api.UnitTests.Endpoints.Clinics;

[TestClass]
public class GetClinicsEndpointTests
{
    GetClinicsEndpoint _endpoint;
    IList<ClinicModel> _clinics;
    
    Mock<IClinicRetriever> _mockClinicRetriever;

    [TestMethod]
    public async Task HandleAsyncShouldGetTheClinicsFromTheDataSource()
    {
        await _endpoint.HandleAsync(default);
        
        _mockClinicRetriever
            .Verify(m => m.GetAll(),
                Times.Once);
    }

    [TestMethod]
    public async Task HandleAsyncShouldRespondOkWithTheResponseBuiltFromTheData()
    {
        var expectedResponse = new GetClinicsResponse
        {
            Clinics = _clinics.Select(x =>
                new Clinic
                {
                    Id = x.Id,
                    Name = x.Name
                })
        };
        
        await _endpoint.HandleAsync(default);
        
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
        _clinics = new List<ClinicModel> 
        {
            new() { Id = 1, Name = "Clinic1" },
            new() { Id = 2, Name = "Clinic2" },
            new() { Id = 3, Name = "Clinic3" },
        };
    }

    void SetupMocks()
    {
        _mockClinicRetriever = new();
    }

    void SetupExpectations()
    {
        _mockClinicRetriever
            .Setup(m => m.GetAll())
            .Returns(_clinics);
    }

    void SetupServiceUnderTest()
    {
        _endpoint = Factory.Create<GetClinicsEndpoint>(
            _mockClinicRetriever.Object);
    }
    
    #endregion
}