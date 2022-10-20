using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using OEZZ.ERP.Domain.Base;
using OEZZ.ERP.Domain.Entities;
using OEZZ.ERP.Domain.Enums;
using OEZZ.ERP.Infrastructure.Data.Configurations;

namespace OEZZ.ERP.Infrastructure.Data;

public class SqlContext : DbContext
{
    private readonly IConfiguration _configuration;
    public Guid TenantId { get; }

    public SqlContext(DbContextOptions options, IConfiguration configuration, ITenantGetter tenantGetter) : base(options)
    {
        _configuration = configuration;
        TenantId = tenantGetter.Tenant;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var schema = _configuration.GetValue<string>("Persistence:Schema");
        modelBuilder.HasDefaultSchema(schema);

        modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<Company>());
        modelBuilder.ApplyConfiguration(new TenantEntityConfiguration<Product, Guid>(this));
        modelBuilder.ApplyConfiguration(new TenantEntityConfiguration<Category, Guid>(this));
        modelBuilder.ApplyConfiguration(new TenantEntityConfiguration<Subcategory, Guid>(this));

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var utcNow = DateTime.UtcNow;
        foreach (var entry in ChangeTracker.Entries<TenantEntity<Guid>>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                {
                    entry.Entity.TenantId = TenantId;
                    entry.Entity.CreatedAt = utcNow;
                    break;
                }
                case EntityState.Modified:
                {
                    entry.Entity.UpdatedAt = utcNow;
                    break;
                }
                case EntityState.Deleted:
                {
                    entry.Entity.UpdatedAt = utcNow;
                    entry.Entity.Status = Status.Deleted;
                    break;
                }
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                default:
                    throw new InvalidCastException();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
}