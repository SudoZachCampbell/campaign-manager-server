using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedDawnMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name", "Variation" },
                values: new object[] { "PhanDawn.jpg", "Phandalin_Dawn", "Dawn" });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name", "Variation" },
                values: new object[] { "PhanDay.jpg", "Phandalin_Day", "Day" });

            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "Id", "Center", "ImageUrl", "LocaleId", "Name", "Variation" },
                values: new object[] { 3, null, "PhanNight.jpg", 6, "Phandalin_Night", "Night" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name", "Variation" },
                values: new object[] { "PhanDay.jpg", "Phandalin_Day", "Day" });

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name", "Variation" },
                values: new object[] { "PhanNight.jpg", "Phandalin_Night", "Night" });
        }
    }
}
