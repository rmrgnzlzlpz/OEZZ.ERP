using System.Linq.Expressions;
using OEZZ.ERP.Domain.Entities;

namespace OEZZ.ERP.Domain.Specifications.Products;

public class ListProductsSpecification : PaginationSpecification<Product>
{
    public ListProductsSpecification(int top, int skip, string search, bool ascending, string orderBy, string includeProperties = "", params Expression<Func<Product, object>>[] includes)
        : base(top, skip, ascending, orderBy, includeProperties, includes)
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