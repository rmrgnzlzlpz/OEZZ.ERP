namespace OEZZ.ERP.Domain.Base;

public abstract class TenantEntity<TId> : Entity<TId>
{
    public Guid TenantId { get; set; }
}