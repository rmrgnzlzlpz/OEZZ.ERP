using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OEZZ.ERP.Domain.Ports;
using OEZZ.ERP.Infrastructure.Adapters;
using OEZZ.ERP.Infrastructure.Data;

namespace OEZZ.ERP.Infrastructure.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SqlContext>(optionsAction =>
        {
            optionsAction.UseNpgsql(configuration.GetConnectionString(Constants.PostgresConnectionName), options =>
            {
                options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
        });
        return services;
    }
    public static IServiceCollection AddSqlRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<,>), typeof(SqlRepository<,>));
        return services;
    }

    public static IServiceCollection AddTenantService(this IServiceCollection services)
    {
        services.AddScoped<TenantService>();
        services.AddScoped<ITenantGetter>(x => x.GetRequiredService<TenantService>());
        services.AddScoped<ITenantSetter>(x => x.GetRequiredService<TenantService>());
        return services;
    }
}