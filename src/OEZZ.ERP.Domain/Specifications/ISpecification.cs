using System.Linq.Expressions;
using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Specifications;

public interface ISpecification<T> where T : BaseEntity
{
    Expression<Func<T, bool>>? Query { get; }
}

public interface IReadSpecification<T> : ISpecification<T> where T : BaseEntity
{
    string[] IncludeProperties { get; }
    Expression<Func<T, object>>[] Includes { get; }
}

public interface IPaginationSpecification<T> : IReadSpecification<T> where T : BaseEntity
{
    int Top { get; }
    int Skip { get; }
    bool Ascending { get; }
    string OrderBy { get; }
    Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderBy();
}