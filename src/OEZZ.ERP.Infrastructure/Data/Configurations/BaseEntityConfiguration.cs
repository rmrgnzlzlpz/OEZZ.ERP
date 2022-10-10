using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Enums;

namespace OEZZ.ERP.Infrastructure.Data.Configurations;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasQueryFilter(entity => entity.Status != Status.Deleted);
    }
}