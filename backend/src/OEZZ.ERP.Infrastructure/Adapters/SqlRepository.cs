using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Ports;
using OEZZ.ERP.Infrastructure.Contexts;

namespace OEZZ.ERP.Infrastructure.Adapters;

public class SqlRepository<T, TId> : IRepository<T, TId> where T : IEntity<TId>
{
    private readonly SqlContext _context;

    public SqlRepository(SqlContext context)
    {
        _context = context;
    }

    public Task Add(T entity)
    {
        throw new NotImplementedException();
    }
}