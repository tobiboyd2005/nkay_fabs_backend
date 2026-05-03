using nkay_fabs_backend.Models.Entities;

namespace nkay_fabs_backend.Data
{
    public static class DbSeeder
    {
        public static void Seed(FabricsDbContext context)
        {
            if (context.Fabrics.Any()) return;

            var ankara = new Category { Name = "Ankara", Description = "Vibrant African wax prints" };
            var lace = new Category { Name = "Lace", Description = "Elegant lace fabrics" };

            var green = new Color { Name = "Emerald Green", HexCode = "#1a5c3a" };
            var gold = new Color { Name = "Gold", HexCode = "#c8a96e" };

            context.Categories.AddRange(ankara, lace);
            context.Colors.AddRange(green, gold);

            context.Fabrics.AddRange(
                new Fabric
                {
                    Name = "Bold Ankara Print",
                    Description = "Vibrant wax print fabric",
                    ImageUrl = "/fabrics/ankara.jpg",
                    PricePerYard = 12.99m,
                    StockYards = 50,
                    Category = ankara,
                    Color = green
                },
                new Fabric
                {
                    Name = "Gold Lace",
                    Description = "Premium gold lace fabric",
                    ImageUrl = "/fabrics/lace.jpg",
                    PricePerYard = 24.99m,
                    StockYards = 30,
                    Category = lace,
                    Color = gold
                }
            );

            context.SaveChanges();
        }
    }
}
