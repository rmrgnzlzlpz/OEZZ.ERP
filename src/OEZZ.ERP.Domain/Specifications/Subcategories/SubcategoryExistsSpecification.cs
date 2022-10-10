using OEZZ.ERP.Domain.Entities;

namespace OEZZ.ERP.Domain.Specifications.Subcategories;

public class SubcategoryExistsSpecification : EntityExistsSpecification<Subcategory>
{
    public SubcategoryExistsSpecification(Guid id) : base(id)
    {
    }
}