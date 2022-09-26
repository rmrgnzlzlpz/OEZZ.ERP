using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Specifications;

namespace OEZZ.ERP.Domain.Ports;

public interface IRepository<T, in TId> where T : BaseEntity, IEntity<TId>
{
    Task Add(T entity, CancellationToken cancellationToken);
    Task<T?> Get(TId id, CancellationToken cancellationToken);
    Task<bool> Any(ISpecification<T> specification, CancellationToken cancellationToken);
    Task<int> Count(ISpecification<T> specification, CancellationToken cancellationToken);
}