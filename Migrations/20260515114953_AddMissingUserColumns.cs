using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nkay_fabs_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingUserColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(1274), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(1311) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5026), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5048) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5063), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5065) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5067), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5069) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5071), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5074), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5076) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5078), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5082), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5084) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5086), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5088) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5090), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5091) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5094), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5095) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5097), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5102), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5103) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5107), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5108) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5110), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5114), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5115) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5118), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5119) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5121), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5123) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5125), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5129), new DateTime(2026, 5, 15, 12, 49, 48, 970, DateTimeKind.Unspecified).AddTicks(5131) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 671, DateTimeKind.Unspecified).AddTicks(2442), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(7938), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(7970) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(7987), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(7988) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(7991), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(7992) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(7994), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(7996) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(7998), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8002), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8003) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8006), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8034) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8036), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8040), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8052), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8053) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8056), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8057) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8059), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8061) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8063), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8065) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8068), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8069) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8094), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8095) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8097), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8098) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8101), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8104), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8105) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8108), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8109) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8111), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8113) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8194), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8197) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8199), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8200) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8203), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8204) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8206), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8210), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8211) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8213), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8215) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8217), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8218) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8221), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8222) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8224), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8225) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8248), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8251), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8252) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8255), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8259), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8260) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8262), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8266), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8270), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8271) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8273), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8274) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8276), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8280), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8284), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8285) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8288), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8289) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8291), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8302), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8320), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8324), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8327), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8329) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8331), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8332) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8334), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8338), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8341), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8348), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8480), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8487), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8488) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8490), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8495), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8496) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8498), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8503), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8663), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8665) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8669), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8671) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8673), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8677), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8679) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8682), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8683) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8686), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8687) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8690), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8694), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8695) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8697), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8699) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8701), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8704), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8706) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8708), new DateTime(2026, 5, 15, 12, 49, 48, 966, DateTimeKind.Unspecified).AddTicks(8710) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
