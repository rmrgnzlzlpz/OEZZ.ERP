using OEZZ.ERP.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlRepositories();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();