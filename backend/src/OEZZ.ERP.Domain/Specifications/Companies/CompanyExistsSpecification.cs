using OEZZ.ERP.Domain.Entities;

namespace OEZZ.ERP.Domain.Specifications.Companies;

public class CompanyExistsSpecification : EntityExistsSpecification<Company>
{
    public CompanyExistsSpecification(Guid id) : base(id)
    {
    }
}