using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class ChangedMapseedtobeaccurate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocaleId",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Map",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocaleId",
                value: 5);
        }
    }
}
