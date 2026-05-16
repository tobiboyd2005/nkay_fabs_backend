using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nkay_fabs_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerYard = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockYards = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fabrics_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fabrics_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    LastMessageAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Users_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailVerifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailVerifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpVerifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OtpCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpVerifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversationId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FabricId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(1627), "A vibrant wax print fabric widely used across Nigeria, known for its bold, colorful patterns and commonly worn at celebrations, ceremonies and everyday occasions.", "Ankara", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(1658) },
                    { 2, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(5968), "A hand-loomed Yoruba fabric from South-Western Nigeria, traditionally worn at weddings and ceremonies, available in three types: Oja, Ipele, and Fila.", "Aso-Oke", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(5992) },
                    { 3, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6005), "A traditional Yoruba indigo-dyed fabric from Nigeria, featuring intricate tie-dye or starch-resist (eleko) patterns, originating from Abeokuta and Ibadan.", "Adire", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6006) },
                    { 4, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6009), "A luxurious fabric popular in South-Eastern Nigeria, commonly worn by Igbo and Ijaw women during weddings and special ceremonies, often adorned with glitter or embroidery.", "George Fabric", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6010) },
                    { 5, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6013), "A traditional Igbo fabric from South-Eastern Nigeria featuring lion head prints, typically worn by men of title and distinction during cultural events and ceremonies.", "Isiagu", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6014) },
                    { 6, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6016), "A hand-woven textile from Akwete town in Abia State, Nigeria, produced by Igbo women and known for its unique weaving techniques and complex patterns.", "Akwete", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6018) },
                    { 7, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6021), "A richly embroidered fabric from Northern Nigeria, featuring intricate hand-stitched patterns around the neckline and chest, commonly used in traditional Hausa and Fulani attire.", "Hausa Embroidered Fabric", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6022) },
                    { 8, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6025), "A coarse, hand-woven cotton fabric from Northern Nigeria traditionally produced by the Hausa people, known for its natural earthy tones and used in everyday traditional wear.", "Kijipa", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6026) },
                    { 9, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6029), "A plain hand-woven Yoruba cloth from South-Western Nigeria, typically woven in white or neutral tones and used as a base fabric for dyeing techniques like Adire.", "Ofi", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6030) },
                    { 10, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6032), "A dark navy blue hand-woven Yoruba fabric from South-Western Nigeria, traditionally reserved for elders and people of high social standing during important ceremonies.", "Etu", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6033) },
                    { 11, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6036), "A prestigious hand-woven Yoruba fabric made from the silk of the Anaphe moth, featuring a distinctive brown or beige tone and traditionally worn by Yoruba royalty.", "Sanyan", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6039) },
                    { 12, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6042), "A fine hand-woven fabric from the Yoruba people of South-Western Nigeria, known for its delicate thread work and typically worn during high-profile traditional occasions.", "Alabere", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6043) },
                    { 13, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6046), "A traditional hand-woven fabric from Okene in Kogi State, produced by the Ebira people, known for its bold geometric patterns and cultural significance in Central Nigeria.", "Okene Weave", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6047) },
                    { 14, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6050), "A traditional handwoven fabric from the Ogoja people of Cross River State, known for its earthy tones and symbolic patterns used in ceremonial and ritual contexts.", "Ogoja Cloth", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6051) },
                    { 15, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6054), "A traditional fabric from the Urhobo people of Delta State, Nigeria, featuring distinct woven patterns and used during cultural festivals and important ceremonies.", "Urhobo Cloth", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6056) },
                    { 16, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6058), "A hand-woven fabric from the Igala people of Kogi State, Nigeria, known for its colorful striped patterns and cultural importance in royal and ceremonial dressing.", "Igala Weave", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6059) },
                    { 17, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6063), "A traditional hand-woven fabric from the Tiv people of Benue State, Nigeria, distinctively featuring black and white striped patterns called Anger, used in traditional ceremonies.", "Tiv Cloth", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6064) },
                    { 18, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6066), "A traditional fabric from the Nupe people of Niger State, Nigeria, known for intricate hand-loom weaving techniques and vibrant colors used in royal ceremonial attire.", "Nupe Weave", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6067) },
                    { 19, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6069), "A traditional fabric from the Efik people of Cross River State, Nigeria, commonly used during the famous Calabar carnival and cultural ceremonies such as the Ekpe festival.", "Efik Cloth", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6071) },
                    { 20, new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6074), "A traditional ceremonial fabric from the Ijaw people of the Niger Delta region, typically featuring bold colors and worn alongside coral beads during important cultural and royal events.", "Ijaw Wrapper", new DateTime(2026, 5, 16, 15, 50, 22, 601, DateTimeKind.Unspecified).AddTicks(6075) }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreatedAt", "HexCode", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 16, 15, 50, 22, 410, DateTimeKind.Unspecified).AddTicks(8286), "#000000", "Black", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(684) },
                    { 2, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4638), "#FFFFFF", "White", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4652) },
                    { 3, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4663), "#FF0000", "Red", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4668) },
                    { 4, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4676), "#001F5B", "Navy Blue", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4681) },
                    { 5, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4688), "#4169E1", "Royal Blue", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4693) },
                    { 6, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4701), "#87CEEB", "Sky Blue", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4706) },
                    { 7, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4708), "#008080", "Teal", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4709) },
                    { 8, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4711), "#40E0D0", "Turquoise", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4712) },
                    { 9, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4719), "#008000", "Green", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4722) },
                    { 10, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4729), "#6B8E23", "Olive Green", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4730) },
                    { 11, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4733), "#98FF98", "Mint Green", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4734) },
                    { 12, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4736), "#32CD32", "Lime Green", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4740) },
                    { 13, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4749), "#FFFF00", "Yellow", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4752) },
                    { 14, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4757), "#FFDB58", "Mustard Yellow", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4760) },
                    { 15, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4765), "#FFD700", "Gold", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4766) },
                    { 16, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4770), "#FF8C00", "Orange", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4773) },
                    { 17, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4778), "#FF6B6B", "Coral", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4782) },
                    { 18, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4787), "#FFCBA4", "Peach", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4790) },
                    { 19, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4795), "#FFC0CB", "Pink", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4798) },
                    { 20, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4803), "#FF69B4", "Hot Pink", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4807) },
                    { 21, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4813), "#FF00FF", "Fuchsia", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4816) },
                    { 22, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4822), "#FF0090", "Magenta", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4825) },
                    { 23, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4831), "#800080", "Purple", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4835) },
                    { 24, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4842), "#E6E6FA", "Lavender", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4843) },
                    { 25, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4845), "#EE82EE", "Violet", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4847) },
                    { 26, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4917), "#4B0082", "Indigo", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4919) },
                    { 27, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4922), "#800000", "Maroon", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4924) },
                    { 28, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4926), "#800020", "Burgundy", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4930) },
                    { 29, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4936), "#722F37", "Wine Red", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4940) },
                    { 30, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4946), "#DC143C", "Crimson", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4950) },
                    { 31, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4956), "#FF2400", "Scarlet", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4960) },
                    { 32, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4963), "#8B4513", "Brown", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4964) },
                    { 33, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4966), "#7B3F00", "Chocolate", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4970) },
                    { 34, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4976), "#C68642", "Caramel", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4979) },
                    { 35, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4984), "#D2B48C", "Tan", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4987) },
                    { 36, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4992), "#F5F5DC", "Beige", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4993) },
                    { 37, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(4999), "#FFFDD0", "Cream", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5002) },
                    { 38, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5007), "#FFFFF0", "Ivory", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5009) },
                    { 39, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5014), "#FAF9F6", "Off White", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5017) },
                    { 40, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5022), "#D3D3D3", "Light Gray", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5025) },
                    { 41, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5030), "#808080", "Gray", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5033) },
                    { 42, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5038), "#404040", "Dark Gray", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5042) },
                    { 43, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5047), "#36454F", "Charcoal", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5051) },
                    { 44, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5056), "#C0C0C0", "Silver", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5060) },
                    { 45, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5062), "#B76E79", "Rose Gold", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5063) },
                    { 46, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5066), "#B87333", "Copper", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5067) },
                    { 47, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5072), "#CD7F32", "Bronze", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5075) },
                    { 48, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5080), "#C3B091", "Khaki", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5083) },
                    { 49, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5088), "#C2B280", "Sand", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5091) },
                    { 50, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5096), "#B7410E", "Rust", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5099) },
                    { 51, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5104), "#FA8072", "Salmon", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5108) },
                    { 52, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5113), "#DCAE96", "Dusty Rose", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5114) },
                    { 53, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5116), "#DE5D83", "Blush", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5117) },
                    { 54, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5119), "#89CFF0", "Baby Blue", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5120) },
                    { 55, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5126), "#B0E0E6", "Powder Blue", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5129) },
                    { 56, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5134), "#007BA7", "Cerulean", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5138) },
                    { 57, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5182), "#0047AB", "Cobalt Blue", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5188) },
                    { 58, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5196), "#B2AC88", "Sage Green", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5201) },
                    { 59, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5209), "#228B22", "Forest Green", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5214) },
                    { 60, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5223), "#50C878", "Emerald Green", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5224) },
                    { 61, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5226), "#00A86B", "Jade", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5228) },
                    { 62, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5232), "#C8A2C8", "Lilac", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5235) },
                    { 63, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5241), "#E0B0FF", "Mauve", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5244) },
                    { 64, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5249), "#DDA0DD", "Plum", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5252) },
                    { 65, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5258), "#614051", "Eggplant", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5261) },
                    { 66, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5266), "#FFF44F", "Lemon Yellow", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5270) },
                    { 67, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5275), "#FFBF00", "Amber", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5276) },
                    { 68, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5278), "#FBCEB1", "Apricot", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5279) },
                    { 69, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5282), "#E2725B", "Terracotta", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5283) },
                    { 70, new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5286), "#CB4154", "Brick Red", new DateTime(2026, 5, 16, 15, 50, 22, 597, DateTimeKind.Unspecified).AddTicks(5289) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FirstName", "IsActive", "IsEmailVerified", "LastName", "PasswordHash", "PhoneNumber", "Role", "UpdatedAt", "Username" },
                values: new object[] { 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "rabiaddawgz200@gmail.com", "Admin", true, true, "User", "6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=", null, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_AdminId",
                table: "Conversations",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_UserId",
                table: "Conversations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerifications_UserId",
                table: "EmailVerifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrics_CategoryId",
                table: "Fabrics",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrics_ColorId",
                table: "Fabrics",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FabricId",
                table: "OrderItems",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpVerifications_UserId",
                table: "OtpVerifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailVerifications");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OtpVerifications");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Fabrics");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
