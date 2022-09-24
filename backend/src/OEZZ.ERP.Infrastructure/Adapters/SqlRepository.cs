using Microsoft.EntityFrameworkCore;
using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Ports;
using OEZZ.ERP.Domain.Specifications;
using OEZZ.ERP.Infrastructure.Contexts;

namespace OEZZ.ERP.Infrastructure.Adapters;

public class SqlRepository<T, TId> : IRepository<T, TId>, IDisposable where T : BaseEntity, IEntity<TId>
{
    private readonly SqlContext _context;
    private readonly DbSet<T> _dbSet;

    public SqlRepository(SqlContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task Add(T? entity, CancellationToken cancellationToken)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity));
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task<T?> Get(TId id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
    }

    public async Task<bool> Any(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(specification.Query, cancellationToken);
    }

    public async Task<int> Count(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        return await _dbSet.CountAsync(specification.Query, cancellationToken);
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.Commit(cancellationToken).ConfigureAwait(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        _context.Dispose();
    }
}