using System.Linq.Expressions;
using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Specifications;

public abstract class PaginationSpecification<T> : ReadSpecification<T>, IPaginationSpecification<T> where T : BaseEntity
{
    public int Top { get; }
    public int Skip { get; }
    public bool Ascending { get; }
    public string OrderBy { get; }

    protected PaginationSpecification(int top, int skip, bool ascending, string orderBy, string includeProperties = "", params Expression<Func<T, object>>[] includes)
    : base(includeProperties, includes)
    {
        Top = top;
        Skip = skip;
        Ascending = ascending;
        OrderBy = orderBy;
    }

    public virtual Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderBy()
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