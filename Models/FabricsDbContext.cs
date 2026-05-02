using Microsoft.EntityFrameworkCore;

public class FabricsDbContext : DbContext
{
    public FabricsDbContext(DbContextOptions<FabricsDbContext> options)
        : base(options)
    {
    }
}