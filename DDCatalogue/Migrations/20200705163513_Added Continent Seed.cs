using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedContinentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "Map", "Name" },
                values: new object[] { 1, null, "Faerun" });

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContinentId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Continents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContinentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContinentId",
                value: null);
        }
    }
}
