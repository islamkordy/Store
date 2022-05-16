using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);

        var AccessoriesId = Guid.NewGuid();
        var PhonesId = Guid.NewGuid();
        var LabtopsId = Guid.NewGuid();

        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = AccessoriesId,
            Name = "Accessories"
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = PhonesId,
            Name = "Phones"
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = LabtopsId,
            Name = "Labtops"
        });

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastUpdatedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}
