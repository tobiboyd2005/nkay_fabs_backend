using Microsoft.EntityFrameworkCore;
using nkay_fabs_backend.Models.Dtos;
using nkay_fabs_backend.Models.Entities;

public class FabricsDbContext : DbContext
{
    public FabricsDbContext(DbContextOptions<FabricsDbContext> options)
        : base(options){}
    public DbSet<Fabric> Fabrics { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Color> Colors { get; set; } 

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