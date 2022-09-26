using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Entities;

namespace OEZZ.ERP.Infrastructure.Data.Configurations;

public class TenantEntityConfiguration<T, TId> : BaseEntityConfiguration<T> where T : TenantEntity<TId>
{
    private readonly Guid _tenantId;

    public TenantEntityConfiguration(Guid tenantId)
    {
        _tenantId = tenantId;
    }

    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);
        builder.HasQueryFilter(entity => entity.TenantId == _tenantId);
    }
}