using OEZZ.ERP.Infrastructure.Data;

namespace OEZZ.ERP.API.Middlewares;

public class MultiTenantServiceMiddleware : IMiddleware
{
    private readonly ITenantSetter _setter;

    public MultiTenantServiceMiddleware(ITenantSetter setter)
    {
        _setter = setter;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var tenantFromClaim = context.User.Claims.FirstOrDefault(x => x.Type == Constants.TenantClaimName);
        if (tenantFromClaim is not null && Guid.TryParse(tenantFromClaim.Value, out var result))
        {
            _setter.SetTenant(result);
        }

        await next(context);
    }
}