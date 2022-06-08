using Microsoft.AspNetCore.Http;
using PatientDashboard.Api.Middleware;

namespace PatientDashboard.Api.UnitTests.Middleware;

[TestClass]
public class ExceptionMiddlewareTests
{
    HttpContext _httpContext;

    [TestMethod]
    public async Task AnExceptionShouldResponseWithInternalServerErrorCode()
    {
        var middleware = SetupExceptionMiddlewareToThrow(new Exception("Oops"));

        await middleware.InvokeAsync(_httpContext);

        _httpContext.Response.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
    }
    
    #region Supporting Code
    
    [TestInitialize]
    public void Setup()
    {
        _httpContext = new DefaultHttpContext();
    }
    
    static ExceptionMiddleware SetupExceptionMiddlewareToThrow(Exception exception)
    {
        var middleware = new ExceptionMiddleware(
            delegate { throw exception; });
        return middleware;
    }
    
    #endregion
}