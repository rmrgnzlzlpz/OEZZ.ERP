using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Entities;

public class Product : TenantEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public Guid SubcategoryId { get; set; } = Guid.Empty;
    public Subcategory Subcategory { get; set; }

    protected Product()
    {
    }

    public Product(string name, Guid subcategoryId)
    {
        Name = name;
        SubcategoryId = subcategoryId;
    }
}