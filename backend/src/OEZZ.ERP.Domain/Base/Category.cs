namespace OEZZ.ERP.Domain.Base;

public class Category : Entity<Guid>
{
    public string Name { get; set; }
    public ICollection<Subcategory> Subcategories { get; set; }
}

public class Subcategory : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}