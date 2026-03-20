using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
    { }

    public DbSet<Watch> Watches => Set<Watch>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Watch>().Property(w => w.Price).HasPrecision(18, 2);

        // Dados semente (Seed) para teste inicial
        modelBuilder.Entity<Watch>().HasData(
            new Watch { Id = Guid.NewGuid(), Brand = "Rolex", Model = "Submariner", Price = 12000.00m, Stock = 5 },
            new Watch { Id = Guid.NewGuid(), Brand = "Omega", Model = "Speedmaster", Price = 7500.00m, Stock = 10 }
        );
    }
}
