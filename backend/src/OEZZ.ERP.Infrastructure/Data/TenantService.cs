namespace OEZZ.ERP.Infrastructure.Data;

public class TenantService : ITenantGetter, ITenantSetter
{
    public Guid Tenant { get; private set; }

    public TenantService()
    {
        Tenant = Tenants.Default;
    }
    public void SetTenant(Guid tenant)
    {
        Tenant = tenant;
    }
}
public interface ITenantGetter 
{
    Guid Tenant { get; }
}
public interface ITenantSetter
{
    void SetTenant(Guid tenant);
}