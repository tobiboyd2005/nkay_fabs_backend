using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nkay_fabs_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 7, 9, 54, 44, 448, DateTimeKind.Unspecified).AddTicks(8264), "A vibrant wax print fabric widely used across Nigeria, known for its bold, colorful patterns and commonly worn at celebrations, ceremonies and everyday occasions.", "Ankara", new DateTime(2026, 5, 7, 9, 54, 44, 448, DateTimeKind.Unspecified).AddTicks(8291) },
                    { 2, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1666), "A hand-loomed Yoruba fabric from South-Western Nigeria, traditionally worn at weddings and ceremonies, available in three types: Oja, Ipele, and Fila.", "Aso-Oke", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1680) },
                    { 3, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1690), "A traditional Yoruba indigo-dyed fabric from Nigeria, featuring intricate tie-dye or starch-resist (eleko) patterns, originating from Abeokuta and Ibadan.", "Adire", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1695) },
                    { 4, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1698), "A luxurious fabric popular in South-Eastern Nigeria, commonly worn by Igbo and Ijaw women during weddings and special ceremonies, often adorned with glitter or embroidery.", "George Fabric", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1699) },
                    { 5, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1701), "A traditional Igbo fabric from South-Eastern Nigeria featuring lion head prints, typically worn by men of title and distinction during cultural events and ceremonies.", "Isiagu", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1706) },
                    { 6, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1713), "A hand-woven textile from Akwete town in Abia State, Nigeria, produced by Igbo women and known for its unique weaving techniques and complex patterns.", "Akwete", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1714) },
                    { 7, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1755), "A richly embroidered fabric from Northern Nigeria, featuring intricate hand-stitched patterns around the neckline and chest, commonly used in traditional Hausa and Fulani attire.", "Hausa Embroidered Fabric", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1756) },
                    { 8, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1761), "A coarse, hand-woven cotton fabric from Northern Nigeria traditionally produced by the Hausa people, known for its natural earthy tones and used in everyday traditional wear.", "Kijipa", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1765) },
                    { 9, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1771), "A plain hand-woven Yoruba cloth from South-Western Nigeria, typically woven in white or neutral tones and used as a base fabric for dyeing techniques like Adire.", "Ofi", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1772) },
                    { 10, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1774), "A dark navy blue hand-woven Yoruba fabric from South-Western Nigeria, traditionally reserved for elders and people of high social standing during important ceremonies.", "Etu", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1776) },
                    { 11, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1782), "A prestigious hand-woven Yoruba fabric made from the silk of the Anaphe moth, featuring a distinctive brown or beige tone and traditionally worn by Yoruba royalty.", "Sanyan", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1786) },
                    { 12, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1789), "A fine hand-woven fabric from the Yoruba people of South-Western Nigeria, known for its delicate thread work and typically worn during high-profile traditional occasions.", "Alabere", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1790) },
                    { 13, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1792), "A traditional hand-woven fabric from Okene in Kogi State, produced by the Ebira people, known for its bold geometric patterns and cultural significance in Central Nigeria.", "Okene Weave", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1796) },
                    { 14, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1804), "A traditional handwoven fabric from the Ogoja people of Cross River State, known for its earthy tones and symbolic patterns used in ceremonial and ritual contexts.", "Ogoja Cloth", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1806) },
                    { 15, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1808), "A traditional fabric from the Urhobo people of Delta State, Nigeria, featuring distinct woven patterns and used during cultural festivals and important ceremonies.", "Urhobo Cloth", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1810) },
                    { 16, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1816), "A hand-woven fabric from the Igala people of Kogi State, Nigeria, known for its colorful striped patterns and cultural importance in royal and ceremonial dressing.", "Igala Weave", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1820) },
                    { 17, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1822), "A traditional hand-woven fabric from the Tiv people of Benue State, Nigeria, distinctively featuring black and white striped patterns called Anger, used in traditional ceremonies.", "Tiv Cloth", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1824) },
                    { 18, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1828), "A traditional fabric from the Nupe people of Niger State, Nigeria, known for intricate hand-loom weaving techniques and vibrant colors used in royal ceremonial attire.", "Nupe Weave", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1830) },
                    { 19, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1837), "A traditional fabric from the Efik people of Cross River State, Nigeria, commonly used during the famous Calabar carnival and cultural ceremonies such as the Ekpe festival.", "Efik Cloth", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1839) },
                    { 20, new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1841), "A traditional ceremonial fabric from the Ijaw people of the Niger Delta region, typically featuring bold colors and worn alongside coral beads during important cultural and royal events.", "Ijaw Wrapper", new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1842) }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreatedAt", "HexCode", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 7, 9, 54, 44, 251, DateTimeKind.Unspecified).AddTicks(6400), "#000000", "Black", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(1748) },
                    { 2, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5136), "#FFFFFF", "White", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5153) },
                    { 3, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5167), "#FF0000", "Red", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5172) },
                    { 4, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5180), "#001F5B", "Navy Blue", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5181) },
                    { 5, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5185), "#4169E1", "Royal Blue", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5189) },
                    { 6, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5197), "#87CEEB", "Sky Blue", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5198) },
                    { 7, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5200), "#008080", "Teal", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5201) },
                    { 8, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5203), "#40E0D0", "Turquoise", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5204) },
                    { 9, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5208), "#008000", "Green", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5211) },
                    { 10, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5219), "#6B8E23", "Olive Green", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5220) },
                    { 11, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5223), "#98FF98", "Mint Green", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5224) },
                    { 12, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5226), "#32CD32", "Lime Green", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5227) },
                    { 13, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5230), "#FFFF00", "Yellow", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5230) },
                    { 14, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5233), "#FFDB58", "Mustard Yellow", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5234) },
                    { 15, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5237), "#FFD700", "Gold", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5238) },
                    { 16, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5240), "#FF8C00", "Orange", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5241) },
                    { 17, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5248), "#FF6B6B", "Coral", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5250) },
                    { 18, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5284), "#FFCBA4", "Peach", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5286) },
                    { 19, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5288), "#FFC0CB", "Pink", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5289) },
                    { 20, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5293), "#FF69B4", "Hot Pink", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5297) },
                    { 21, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5305), "#FF00FF", "Fuchsia", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5306) },
                    { 22, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5352), "#FF0090", "Magenta", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5359) },
                    { 23, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5367), "#800080", "Purple", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5368) },
                    { 24, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5370), "#E6E6FA", "Lavender", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5371) },
                    { 25, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5374), "#EE82EE", "Violet", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5375) },
                    { 26, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5378), "#4B0082", "Indigo", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5380) },
                    { 27, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5383), "#800000", "Maroon", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5384) },
                    { 28, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5387), "#800020", "Burgundy", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5388) },
                    { 29, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5391), "#722F37", "Wine Red", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5392) },
                    { 30, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5395), "#DC143C", "Crimson", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5396) },
                    { 31, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5399), "#FF2400", "Scarlet", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5400) },
                    { 32, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5403), "#8B4513", "Brown", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5404) },
                    { 33, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5407), "#7B3F00", "Chocolate", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5409) },
                    { 34, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5411), "#C68642", "Caramel", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5412) },
                    { 35, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5415), "#D2B48C", "Tan", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5416) },
                    { 36, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5419), "#F5F5DC", "Beige", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5421) },
                    { 37, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5423), "#FFFDD0", "Cream", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5425) },
                    { 38, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5428), "#FFFFF0", "Ivory", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5429) },
                    { 39, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5432), "#FAF9F6", "Off White", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5433) },
                    { 40, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5436), "#D3D3D3", "Light Gray", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5437) },
                    { 41, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5440), "#808080", "Gray", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5442) },
                    { 42, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5444), "#404040", "Dark Gray", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5446) },
                    { 43, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5448), "#36454F", "Charcoal", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5450) },
                    { 44, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5453), "#C0C0C0", "Silver", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5454) },
                    { 45, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5457), "#B76E79", "Rose Gold", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5459) },
                    { 46, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5461), "#B87333", "Copper", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5463) },
                    { 47, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5465), "#CD7F32", "Bronze", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5467) },
                    { 48, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5469), "#C3B091", "Khaki", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5470) },
                    { 49, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5473), "#C2B280", "Sand", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5474) },
                    { 50, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5477), "#B7410E", "Rust", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5481) },
                    { 51, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5488), "#FA8072", "Salmon", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5489) },
                    { 52, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5491), "#DCAE96", "Dusty Rose", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5493) },
                    { 53, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5526), "#DE5D83", "Blush", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5528) },
                    { 54, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5531), "#89CFF0", "Baby Blue", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5532) },
                    { 55, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5534), "#B0E0E6", "Powder Blue", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5535) },
                    { 56, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5537), "#007BA7", "Cerulean", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5538) },
                    { 57, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5541), "#0047AB", "Cobalt Blue", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5543) },
                    { 58, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5545), "#B2AC88", "Sage Green", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5547) },
                    { 59, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5550), "#228B22", "Forest Green", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5551) },
                    { 60, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5554), "#50C878", "Emerald Green", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5555) },
                    { 61, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5558), "#00A86B", "Jade", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5559) },
                    { 62, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5562), "#C8A2C8", "Lilac", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5564) },
                    { 63, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5566), "#E0B0FF", "Mauve", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5568) },
                    { 64, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5570), "#DDA0DD", "Plum", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5572) },
                    { 65, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5574), "#614051", "Eggplant", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5576) },
                    { 66, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5578), "#FFF44F", "Lemon Yellow", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5580) },
                    { 67, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5582), "#FFBF00", "Amber", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5584) },
                    { 68, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5586), "#FBCEB1", "Apricot", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5588) },
                    { 69, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5591), "#E2725B", "Terracotta", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5592) },
                    { 70, new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5595), "#CB4154", "Brick Red", new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5596) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 70);
        }
    }
}
