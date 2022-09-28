using Microsoft.OpenApi.Models;

namespace OEZZ.ERP.API.Extensions;

public static class OpenApiExtensions
{
    public static void AddOpenApiDocument(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "ToDo API",
                Description = "An ASP.NET Core Web API for managing ToDo items",
                TermsOfService = new Uri(configuration.GetValue<string>("ERP.OpenApi:TermsUrl")),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri(configuration.GetValue<string>("ERP.OpenApi:ContactUrl"))
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri(configuration.GetValue<string>("ERP.OpenApi:LicenseUrl"))
                }
            });
            
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter into field the word 'Bearer' following by space and JWT",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
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