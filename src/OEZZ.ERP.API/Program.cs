using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Net.Http.Headers;
using OEZZ.ERP.API;
using OEZZ.ERP.API.Extensions;
using OEZZ.ERP.API.Middlewares;
using OEZZ.ERP.Application.Common;
using OEZZ.ERP.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors()
    .AddControllers();

builder.Services.AddValidatorsFromAssembly(Assembly.Load(Constants.ApplicationName));

builder.Services
    .AddTenantService()
    .AddSqlContext(builder.Configuration)
    .AddSqlRepositories()
    .AddScoped<MultiTenantServiceMiddleware>()
    .AddMediatR(Assembly.Load(Constants.ApplicationName), typeof(Program).Assembly);

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddOpenApiDocument(builder.Configuration);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(policy => policy.WithOrigins("https://localhost:7166", "http://localhost:5038")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);
app.UseRouting();
app.UseStaticFiles();
app.UseWebSockets();
app.UseAuthentication();
app.UseAuthorization();
app.UseOpenApiDocument();
app.UseMiddleware<MultiTenantServiceMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();