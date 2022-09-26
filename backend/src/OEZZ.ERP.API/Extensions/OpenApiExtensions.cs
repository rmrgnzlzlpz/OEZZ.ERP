using Microsoft.OpenApi.Models;

namespace OEZZ.ERP.API.Extensions;

public static class OpenApiExtensions
{
    private const string Uri = "url_example";
    public static void AddOpenApiDocument(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "ToDo API",
                Description = "An ASP.NET Core Web API for managing ToDo items",
                TermsOfService = new Uri(Uri),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri(Uri)
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri(Uri)
                }
            });
        });
    }

    public static void UseOpenApiDocument(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            }
        );
    }
}