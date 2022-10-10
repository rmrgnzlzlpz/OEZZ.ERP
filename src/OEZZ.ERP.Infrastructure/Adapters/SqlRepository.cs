using Microsoft.EntityFrameworkCore;
using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Ports;
using OEZZ.ERP.Domain.Specifications;
using OEZZ.ERP.Infrastructure.Data;

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

    public async Task AddAsync(T? entity, CancellationToken cancellationToken)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity));
        await _dbSet.AddAsync(entity, cancellationToken);
        await _context.CommitAsync(cancellationToken);
    }

    public async Task<T?> FindAsync(TId id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        _ = _dbSet.Remove(entity);
        await _context.CommitAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetByAsync(IPaginationSpecification<T> specification, CancellationToken cancellationToken)
    {
        IQueryable<T> query = _dbSet;
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = specification.GetOrderBy();
        if (specification.Query is not null)
        {
            query = _dbSet.Where(specification.Query);
        }
        return await orderBy(query).Skip(specification.Skip).Take(specification.Top).ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        IQueryable<T> query = _dbSet;
        if (specification.Query is not null)
        {
            query = _dbSet.Where(specification.Query);
        }

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        if (specification.Query is not null)
        {
            return await _dbSet.AnyAsync(specification.Query, cancellationToken);
        }
        return await _dbSet.AnyAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        if (specification.Query is not null)
        {
            return await _dbSet.CountAsync(specification.Query, cancellationToken);
        }
        return await _dbSet.CountAsync(cancellationToken);
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.CommitAsync(cancellationToken).ConfigureAwait(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}