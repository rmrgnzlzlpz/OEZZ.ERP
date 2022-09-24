using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OEZZ.ERP.Domain.Entities;

namespace OEZZ.ERP.Infrastructure.Contexts;

public class SqlContext : DbContext
{
    private readonly IConfiguration _configuration;

    public SqlContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public async Task Commit(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var schema = _configuration.GetValue<string>("ERP.Persistence:Schema");
        modelBuilder.HasDefaultSchema(schema);
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Product> Products { get; set; }
}