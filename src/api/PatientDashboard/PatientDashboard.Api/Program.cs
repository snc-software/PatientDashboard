using PatientDashboard.Api.DependencyInjection;
using PatientDashboard.Api.Extensions;
using PatientDashboard.Api.Middleware;
using PatientDashboard.Domain.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddFastEndpoints();

var swaggerContact = new SwaggerContact();
configuration.GetSection("Swagger:Contact").Bind(swaggerContact);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(p => p.AddPolicy("react", config =>
    {
        config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));
}

builder.Services
    .ConfigureSwagger(swaggerContact)
    .AddDataServices()
    .AddHealthChecks();

var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    app.UseCors("react");
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseFastEndpoints()
    .AddSwagger()
    .UseHttpsRedirection()
    .UseHealthChecks("/health");

app.Run();