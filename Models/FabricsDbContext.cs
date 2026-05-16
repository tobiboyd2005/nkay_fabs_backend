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
    public DbSet<User> Users { get; set; }
    public DbSet<EmailVerification> EmailVerifications { get; set; }
    public DbSet<OtpVerification> OtpVerifications { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<Message> Messages { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Property("CreatedAt").CurrentValue = TimeHelper.NowWAT();

            //entry.Property("UpdatedAt").CurrentValue = TimeHelper.NowWAT();
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

        modelBuilder.Entity<Conversation>()
            .HasOne(c => c.User)
            .WithMany(u => u.Conversations)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Conversation>()
            .HasOne(c => c.Admin)
            .WithMany()
            .HasForeignKey(c => c.AdminId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Conversation)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ConversationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Fabric)
            .WithMany()
            .HasForeignKey(oi => oi.FabricId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EmailVerification>()
            .HasOne(e => e.User)
            .WithMany(u => u.EmailVerifications)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OtpVerification>()
            .HasOne(o => o.User)
            .WithMany(u => u.OtpVerifications)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Color>()
            .HasData(
                new Color("Black") { Id = 1, HexCode = "#000000" },
                new Color("White") { Id = 2, HexCode = "#FFFFFF" },
                new Color("Red") { Id = 3, HexCode = "#FF0000" },
                new Color("Navy Blue") { Id = 4, HexCode = "#001F5B" },
                new Color("Royal Blue") { Id = 5, HexCode = "#4169E1" },
                new Color("Sky Blue") { Id = 6, HexCode = "#87CEEB" },
                new Color("Teal") { Id = 7, HexCode = "#008080" },
                new Color("Turquoise") { Id = 8, HexCode = "#40E0D0" },
                new Color("Green") { Id = 9, HexCode = "#008000" },
                new Color("Olive Green") { Id = 10, HexCode = "#6B8E23" },
                new Color("Mint Green") { Id = 11, HexCode = "#98FF98" },
                new Color("Lime Green") { Id = 12, HexCode = "#32CD32" },
                new Color("Yellow") { Id = 13, HexCode = "#FFFF00" },
                new Color("Mustard Yellow") { Id = 14, HexCode = "#FFDB58" },
                new Color("Gold") { Id = 15, HexCode = "#FFD700" },
                new Color("Orange") { Id = 16, HexCode = "#FF8C00" },
                new Color("Coral") { Id = 17, HexCode = "#FF6B6B" },
                new Color("Peach") { Id = 18, HexCode = "#FFCBA4" },
                new Color("Pink") { Id = 19, HexCode = "#FFC0CB" },
                new Color("Hot Pink") { Id = 20, HexCode = "#FF69B4" },
                new Color("Fuchsia") { Id = 21, HexCode = "#FF00FF" },
                new Color("Magenta") { Id = 22, HexCode = "#FF0090" },
                new Color("Purple") { Id = 23, HexCode = "#800080" },
                new Color("Lavender") { Id = 24, HexCode = "#E6E6FA" },
                new Color("Violet") { Id = 25, HexCode = "#EE82EE" },
                new Color("Indigo") { Id = 26, HexCode = "#4B0082" },
                new Color("Maroon") { Id = 27, HexCode = "#800000" },
                new Color("Burgundy") { Id = 28, HexCode = "#800020" },
                new Color("Wine Red") { Id = 29, HexCode = "#722F37" },
                new Color("Crimson") { Id = 30, HexCode = "#DC143C" },
                new Color("Scarlet") { Id = 31, HexCode = "#FF2400" },
                new Color("Brown") { Id = 32, HexCode = "#8B4513" },
                new Color("Chocolate") { Id = 33, HexCode = "#7B3F00" },
                new Color("Caramel") { Id = 34, HexCode = "#C68642" },
                new Color("Tan") { Id = 35, HexCode = "#D2B48C" },
                new Color("Beige") { Id = 36, HexCode = "#F5F5DC" },
                new Color("Cream") { Id = 37, HexCode = "#FFFDD0" },
                new Color("Ivory") { Id = 38, HexCode = "#FFFFF0" },
                new Color("Off White") { Id = 39, HexCode = "#FAF9F6" },
                new Color("Light Gray") { Id = 40, HexCode = "#D3D3D3" },
                new Color("Gray") { Id = 41, HexCode = "#808080" },
                new Color("Dark Gray") { Id = 42, HexCode = "#404040" },
                new Color("Charcoal") { Id = 43, HexCode = "#36454F" },
                new Color("Silver") { Id = 44, HexCode = "#C0C0C0" },
                new Color("Rose Gold") { Id = 45, HexCode = "#B76E79" },
                new Color("Copper") { Id = 46, HexCode = "#B87333" },
                new Color("Bronze") { Id = 47, HexCode = "#CD7F32" },
                new Color("Khaki") { Id = 48, HexCode = "#C3B091" },
                new Color("Sand") { Id = 49, HexCode = "#C2B280" },
                new Color("Rust") { Id = 50, HexCode = "#B7410E" },
                new Color("Salmon") { Id = 51, HexCode = "#FA8072" },
                new Color("Dusty Rose") { Id = 52, HexCode = "#DCAE96" },
                new Color("Blush") { Id = 53, HexCode = "#DE5D83" },
                new Color("Baby Blue") { Id = 54, HexCode = "#89CFF0" },
                new Color("Powder Blue") { Id = 55, HexCode = "#B0E0E6" },
                new Color("Cerulean") { Id = 56, HexCode = "#007BA7" },
                new Color("Cobalt Blue") { Id = 57, HexCode = "#0047AB" },
                new Color("Sage Green") { Id = 58, HexCode = "#B2AC88" },
                new Color("Forest Green") { Id = 59, HexCode = "#228B22" },
                new Color("Emerald Green") { Id = 60, HexCode = "#50C878" },
                new Color("Jade") { Id = 61, HexCode = "#00A86B" },
                new Color("Lilac") { Id = 62, HexCode = "#C8A2C8" },
                new Color("Mauve") { Id = 63, HexCode = "#E0B0FF" },
                new Color("Plum") { Id = 64, HexCode = "#DDA0DD" },
                new Color("Eggplant") { Id = 65, HexCode = "#614051" },
                new Color("Lemon Yellow") { Id = 66, HexCode = "#FFF44F" },
                new Color("Amber") { Id = 67, HexCode = "#FFBF00" },
                new Color("Apricot") { Id = 68, HexCode = "#FBCEB1" },
                new Color("Terracotta") { Id = 69, HexCode = "#E2725B" },
                new Color("Brick Red") { Id = 70, HexCode = "#CB4154" }
     );
        modelBuilder.Entity<Category>()
            .HasData(
                new Category("Ankara") { Id = 1, Description = "A vibrant wax print fabric widely used across Nigeria, known for its bold, colorful patterns and commonly worn at celebrations, ceremonies and everyday occasions." },
                new Category("Aso-Oke") { Id = 2, Description = "A hand-loomed Yoruba fabric from South-Western Nigeria, traditionally worn at weddings and ceremonies, available in three types: Oja, Ipele, and Fila." },
                new Category("Adire") { Id = 3, Description = "A traditional Yoruba indigo-dyed fabric from Nigeria, featuring intricate tie-dye or starch-resist (eleko) patterns, originating from Abeokuta and Ibadan." },
                new Category("George Fabric") { Id = 4, Description = "A luxurious fabric popular in South-Eastern Nigeria, commonly worn by Igbo and Ijaw women during weddings and special ceremonies, often adorned with glitter or embroidery." },
                new Category("Isiagu") { Id = 5, Description = "A traditional Igbo fabric from South-Eastern Nigeria featuring lion head prints, typically worn by men of title and distinction during cultural events and ceremonies." },
                new Category("Akwete") { Id = 6, Description = "A hand-woven textile from Akwete town in Abia State, Nigeria, produced by Igbo women and known for its unique weaving techniques and complex patterns." },
                new Category("Hausa Embroidered Fabric") { Id = 7, Description = "A richly embroidered fabric from Northern Nigeria, featuring intricate hand-stitched patterns around the neckline and chest, commonly used in traditional Hausa and Fulani attire." },
                new Category("Kijipa") { Id = 8, Description = "A coarse, hand-woven cotton fabric from Northern Nigeria traditionally produced by the Hausa people, known for its natural earthy tones and used in everyday traditional wear." },
                new Category("Ofi") { Id = 9, Description = "A plain hand-woven Yoruba cloth from South-Western Nigeria, typically woven in white or neutral tones and used as a base fabric for dyeing techniques like Adire." },
                new Category("Etu") { Id = 10, Description = "A dark navy blue hand-woven Yoruba fabric from South-Western Nigeria, traditionally reserved for elders and people of high social standing during important ceremonies." },
                new Category("Sanyan") { Id = 11, Description = "A prestigious hand-woven Yoruba fabric made from the silk of the Anaphe moth, featuring a distinctive brown or beige tone and traditionally worn by Yoruba royalty." },
                new Category("Alabere") { Id = 12, Description = "A fine hand-woven fabric from the Yoruba people of South-Western Nigeria, known for its delicate thread work and typically worn during high-profile traditional occasions." },
                new Category("Okene Weave") { Id = 13, Description = "A traditional hand-woven fabric from Okene in Kogi State, produced by the Ebira people, known for its bold geometric patterns and cultural significance in Central Nigeria." },
                new Category("Ogoja Cloth") { Id = 14, Description = "A traditional handwoven fabric from the Ogoja people of Cross River State, known for its earthy tones and symbolic patterns used in ceremonial and ritual contexts." },
                new Category("Urhobo Cloth") { Id = 15, Description = "A traditional fabric from the Urhobo people of Delta State, Nigeria, featuring distinct woven patterns and used during cultural festivals and important ceremonies." },
                new Category("Igala Weave") { Id = 16, Description = "A hand-woven fabric from the Igala people of Kogi State, Nigeria, known for its colorful striped patterns and cultural importance in royal and ceremonial dressing." },
                new Category("Tiv Cloth") { Id = 17, Description = "A traditional hand-woven fabric from the Tiv people of Benue State, Nigeria, distinctively featuring black and white striped patterns called Anger, used in traditional ceremonies." },
                new Category("Nupe Weave") { Id = 18, Description = "A traditional fabric from the Nupe people of Niger State, Nigeria, known for intricate hand-loom weaving techniques and vibrant colors used in royal ceremonial attire." },
                new Category("Efik Cloth") { Id = 19, Description = "A traditional fabric from the Efik people of Cross River State, Nigeria, commonly used during the famous Calabar carnival and cultural ceremonies such as the Ekpe festival." },
                new Category("Ijaw Wrapper") { Id = 20, Description = "A traditional ceremonial fabric from the Ijaw people of the Niger Delta region, typically featuring bold colors and worn alongside coral beads during important cultural and royal events." }
            );

        modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "rabiaddawgz200@gmail.com",
                    PasswordHash = "6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=",
                    FirstName = "Admin",
                    LastName = "User",
                    Role = UserRole.Admin,
                    IsEmailVerified = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
    }
}