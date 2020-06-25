using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedMapsVariations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Variation",
                table: "Map",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "Id",
                keyValue: 1,
                column: "Variation",
                value: "Day");

            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "Id", "Center", "ImageUrl", "LocaleId", "Name", "Variation" },
                values: new object[] { 2, null, "PhanNight.jpg", 6, "Phandalin_Night", "Night" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Map",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Variation",
                table: "Map");
        }
    }
}
