using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Entities;
using OEZZ.ERP.Infrastructure.Data.Configurations;

namespace OEZZ.ERP.Infrastructure.Data;

public class SqlContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly Guid _tenantId;

    public SqlContext(DbContextOptions options, IConfiguration configuration, ITenantGetter tenantGetter) : base(options)
    {
        _configuration = configuration;
        _tenantId = tenantGetter.Tenant;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var schema = _configuration.GetValue<string>("ERP.Persistence:Schema");
        modelBuilder.HasDefaultSchema(schema);

        modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<Company>());
        modelBuilder.ApplyConfiguration(new TenantEntityConfiguration<Product, Guid>(_tenantId));
        modelBuilder.ApplyConfiguration(new TenantEntityConfiguration<Category, Guid>(_tenantId));
        modelBuilder.ApplyConfiguration(new TenantEntityConfiguration<Subcategory, Guid>(_tenantId));
        
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<TenantEntity<Guid>>().ToList())
        {
            if (entry.State is EntityState.Added or EntityState.Modified)
            {
                var utcNow = DateTime.UtcNow;
                entry.Entity.TenantId = _tenantId;
                entry.Entity.CreatedAt = utcNow;
                entry.Entity.UpdatedAt = utcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public async Task Commit(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
}