using OEZZ.ERP.Domain.Entities;

namespace OEZZ.ERP.Domain.Ports.Repositories;

public interface IProductRepository : IRepository<Product, Guid>
{
}