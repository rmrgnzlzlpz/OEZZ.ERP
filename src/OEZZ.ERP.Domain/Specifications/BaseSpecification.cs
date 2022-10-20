using System.Linq.Expressions;
using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Enums;

namespace OEZZ.ERP.Domain.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Query { get; protected init; }
}

public abstract class ReadSpecification<T> : BaseSpecification<T> , IReadSpecification<T> where T : BaseEntity
{
    public string[] IncludeProperties { get; }
    public Expression<Func<T, object>>[] Includes { get; }
    protected ReadSpecification(string includeProperties, Expression<Func<T, object>>[] includes)
    {
        IncludeProperties = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        Includes = includes;
    }
}