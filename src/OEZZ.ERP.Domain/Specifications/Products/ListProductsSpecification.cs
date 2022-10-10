using OEZZ.ERP.Domain.Entities;

namespace OEZZ.ERP.Domain.Specifications.Products;

public class ListProductsSpecification : PaginationSpecification<Product>
{
    public ListProductsSpecification(int top, int skip, string search, bool ascending, string orderBy) : base(top, skip, ascending, orderBy)
    {
        Query = product => product.Name.ToUpper().Contains(search.ToUpper());
    }

    public override Func<IQueryable<Product>, IOrderedQueryable<Product>> GetOrderBy()
    {
        return OrderBy.Trim().ToUpper() switch
        {
            _ => query =>
                Ascending
                    ? query.OrderByDescending(x => x.UpdatedAt)
                    : query.OrderBy(x => x.UpdatedAt)
        };
    }
}