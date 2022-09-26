using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Entities;

public class Subcategory : TenantEntity<Guid>
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}