using Microsoft.Extensions.DependencyInjection;
using OEZZ.ERP.Domain.Ports;
using OEZZ.ERP.Infrastructure.Adapters;

namespace OEZZ.ERP.Infrastructure.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddSqlRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<,>), typeof(SqlRepository<,>));
        return services;
    }
}