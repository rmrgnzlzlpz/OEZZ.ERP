using System.Linq.Expressions;
using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Specifications;

public interface ISpecification<TEntity> where TEntity : BaseEntity
{
    Expression<Func<TEntity, bool>> Query { get; }
}