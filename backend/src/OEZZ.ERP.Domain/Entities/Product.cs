using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Entities;

public class Product : CompanyEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public Guid SubcategoryId { get; set; } = Guid.Empty;
    public Subcategory Subcategory { get; set; }

    protected Product()
    {
    }

    public Product(Guid companyId, string name, Guid subcategoryId)
    {
        CompanyId = companyId;
        Name = name;
        SubcategoryId = subcategoryId;
    }
}