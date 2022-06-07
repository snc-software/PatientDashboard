using Microsoft.AspNetCore.Mvc.Testing;

namespace PatientDashboard.Api.IntegrationTests.BaseClasses;

public abstract class IntegrationTestBase
{
    protected HttpClient Client { get; private set; }
    
    [TestInitialize]
    public void Setup()
    {
        SetupData();
        SetupHttpClient();
    }

    protected virtual void SetupData(){}
    
    void SetupHttpClient()
    {
        var factory = new WebApplicationFactory<Program>();
        Client = factory.CreateDefaultClient();
    }
}