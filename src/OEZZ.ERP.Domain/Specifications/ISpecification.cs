using System.Linq.Expressions;
using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Specifications;

public interface ISpecification<TEntity> where TEntity : BaseEntity
{
    Expression<Func<TEntity, bool>>? Query { get; }
}

public interface IPaginationSpecification<T> : ISpecification<T> where T : BaseEntity
{
    int Top { get; }
    int Skip { get; }
    bool Ascending { get; }
    string OrderBy { get; }
    Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderBy();
}