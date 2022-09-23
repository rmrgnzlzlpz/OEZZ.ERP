using OEZZ.ERP.Domain.Base;

namespace OEZZ.ERP.Domain.Ports;

public interface IRepository<in T, TId> where T : IEntity<TId>
{
    Task Add(T entity);
}