using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Entities;

public class Product : Entity<Guid>
{
    // Multi-tenant
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
    public string Name { get; set; }
    public Guid SubcategoryId { get; set; }
    public Subcategory Subcategory { get; set; }
}