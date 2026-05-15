using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nkay_fabs_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthOrdersNotificationsMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(2762), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(2788) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8795), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8837), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8839) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8842), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8843) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8846), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8850), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8854), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8856) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8859), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8863), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8864) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8867), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8869) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8871), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8873) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8875), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8880), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8881) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8884), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8885) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8888), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8889) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8892), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8894) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8896), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8898) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8900), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8902) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8904), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8909), new DateTime(2026, 5, 15, 12, 27, 0, 72, DateTimeKind.Unspecified).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 26, 59, 906, DateTimeKind.Unspecified).AddTicks(2255), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(5186) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7559), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7567) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7574), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7575) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7577), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7578) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7580), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7580) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7582), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7583) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7585), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7585) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7587), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7590), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7590) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7592), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7593) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7595), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7595) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7597), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7598) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7600), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7602), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7603) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7604), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7605) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7607), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7607) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7609), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7610) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7611), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7614), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7615) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7616), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7619), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7660), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7660) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7662), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7663) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7665), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7666) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7667), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7668) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7670), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7670) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7672), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7673) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7674), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7675) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7677), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7678) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7679), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7680) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7682), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7683) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7684), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7687), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7688) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7689), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7691), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7692) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7694), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7696), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7699), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7699) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7701), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7702) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7703), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7706), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7707) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7708), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7709) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7711), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7711) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7713), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7714) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7715), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7718), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7720), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7721) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7722), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7723) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7725), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7727), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7728) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7729), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7732), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7733) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7759), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7762), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7762) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7764), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7765) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7766), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7767) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7769), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7771), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7772) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7774), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7775) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7776), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7779), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7779) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7781), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7782) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7784), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7784) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7786), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7787) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7789), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7789) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7791), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7792) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7793), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7794) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7796), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7797) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7798), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7799) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7801), new DateTime(2026, 5, 15, 12, 27, 0, 70, DateTimeKind.Unspecified).AddTicks(7801) });

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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 448, DateTimeKind.Unspecified).AddTicks(8264), new DateTime(2026, 5, 7, 9, 54, 44, 448, DateTimeKind.Unspecified).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1666), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1680) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1690), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1695) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1698), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1701), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1706) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1713), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1714) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1755), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1756) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1761), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1765) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1771), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1772) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1774), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1782), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1789), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1790) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1792), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1796) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1804), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1806) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1808), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1810) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1816), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1820) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1822), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1824) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1828), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1830) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1837), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1839) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1841), new DateTime(2026, 5, 7, 9, 54, 44, 449, DateTimeKind.Unspecified).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 251, DateTimeKind.Unspecified).AddTicks(6400), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(1748) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5136), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5153) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5167), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5172) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5180), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5181) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5185), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5189) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5197), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5198) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5200), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5203), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5208), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5211) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5219), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5220) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5223), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5224) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5226), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5227) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5230), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5230) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5233), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5234) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5237), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5238) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5240), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5241) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5248), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5250) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5284), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5286) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5288), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5289) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5293), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5297) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5305), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5306) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5352), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5359) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5367), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5368) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5370), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5371) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5374), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5375) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5378), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5383), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5384) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5387), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5388) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5391), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5392) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5395), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5396) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5399), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5403), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5404) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5407), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5409) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5411), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5412) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5415), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5419), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5421) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5423), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5425) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5428), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5429) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5432), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5433) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5436), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5440), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5442) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5444), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5446) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5448), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5453), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5454) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5457), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5459) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5461), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5463) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5465), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5469), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5473), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5474) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5477), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5488), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5489) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5491), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5493) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5526), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5531), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5532) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5534), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5535) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5537), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5538) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5541), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5545), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5547) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5550), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5551) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5554), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5555) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5558), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5559) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5562), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5564) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5566), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5568) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5570), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5572) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5574), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5576) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5578), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5582), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5584) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5586), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5588) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5591), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5592) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5595), new DateTime(2026, 5, 7, 9, 54, 44, 446, DateTimeKind.Unspecified).AddTicks(5596) });
        }
    }
}
