using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Infrastructure.Data.Configurations;

public class TenantEntityConfiguration<T, TId> : BaseEntityConfiguration<T> where T : TenantEntity<TId>
{
    private readonly SqlContext _context;

    public TenantEntityConfiguration(SqlContext context)
    {
        _context = context;
    }

    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);
        builder.HasQueryFilter(entity => entity.TenantId == _context.TenantId);
    }
}