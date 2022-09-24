using System.Linq.Expressions;
using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Enums;

namespace OEZZ.ERP.Domain.Specifications;

public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Query { get; protected set; }
}