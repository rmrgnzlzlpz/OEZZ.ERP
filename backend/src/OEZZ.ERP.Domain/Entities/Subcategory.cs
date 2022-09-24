namespace OEZZ.ERP.Domain.Entities;

public class Subcategory : CompanyEntity<Guid>
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}