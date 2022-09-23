using OEZZ.ERP.Domain.Entities;
using OEZZ.ERP.Domain.Ports.Repositories;
using OEZZ.ERP.Infrastructure.Contexts;

namespace OEZZ.ERP.Infrastructure.Adapters.Repositories;

public class ProductSqlRepository : SqlRepository<Product, Guid>, IProductRepository
{
    public ProductSqlRepository(SqlContext context) : base(context)
    {
    }
}