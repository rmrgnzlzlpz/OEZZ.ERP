using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Entities;

public abstract class CompanyEntity<TId> : BaseEntity, IEntity<TId>
{
    public virtual TId Id { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}