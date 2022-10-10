using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Specifications;

namespace OEZZ.ERP.Domain.Ports;

public interface IRepository<T, in TId> where T : BaseEntity, IEntity<TId>
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task<T?> FindAsync(TId id, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetByAsync(IPaginationSpecification<T> specification, CancellationToken cancellationToken);
    Task<T?> GetByAsync(ISpecification<T> specification, CancellationToken cancellationToken);
    Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken);
    Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken);
}