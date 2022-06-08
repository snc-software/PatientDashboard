using FastEndpoints.Swagger;
using NSwag;
using PatientDashboard.Domain.Configuration;

namespace PatientDashboard.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services,
        SwaggerContact swaggerContact)
    {
        services.AddSwaggerDoc(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = swaggerContact.Name,
                        Email = swaggerContact.Email,
                        Url = swaggerContact.Url
                    };
                };
            },tagIndex: 0,shortSchemaNames: true,
            addJWTBearerAuth: false);   
        return services;
    }

    public static IApplicationBuilder AddSwagger(this IApplicationBuilder app)
    {
        app.UseOpenApi()
            .UseSwaggerUi3(s =>
            {
                s.ConfigureDefaults();
            });

        return app;
    }
}