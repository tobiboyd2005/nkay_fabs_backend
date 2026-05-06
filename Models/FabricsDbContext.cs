using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Entities;
using nkay_fabs_backend.Helpers;
using nkay_fabs_backend.Models.Dtos;

public class FabricsDbContext : DbContext
{
    public FabricsDbContext(DbContextOptions<FabricsDbContext> options)
        : base(options){}
    public DbSet<Fabric> Fabrics { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Color> Colors { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Property("CreatedAt").CurrentValue = TimeHelper.NowWAT();

            entry.Property("UpdatedAt").CurrentValue = TimeHelper.NowWAT();
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fabric>()
            .Property(f => f.PricePerYard)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Fabric>()
            .Property(f => f.StockYards)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Fabric>()
            .HasOne(f => f.Category)
            .WithMany(c => c.Fabrics)
            .HasForeignKey(f => f.CategoryId);

        modelBuilder.Entity<Fabric>()
            .HasOne(f => f.Color)
            .WithMany(c => c.Fabrics)
            .HasForeignKey(f => f.ColorId);
    }
}