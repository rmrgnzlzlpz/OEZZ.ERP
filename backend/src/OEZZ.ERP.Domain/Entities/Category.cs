using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Entities;

public class Category : CompanyEntity<Guid>
{
    public string Name { get; set; }
    public ICollection<Subcategory> Subcategories { get; set; }
}