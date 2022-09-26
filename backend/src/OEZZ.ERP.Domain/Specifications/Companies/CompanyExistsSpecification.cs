using System.Linq.Expressions;
using OEZZ.ERP.Domain.Entities;

namespace OEZZ.ERP.Domain.Specifications.Companies;

public class CompanyExistsSpecification : BaseSpecification<Company>
{
    public CompanyExistsSpecification(Guid id)
    {
        Query = company => company.Id == id;
    }
}