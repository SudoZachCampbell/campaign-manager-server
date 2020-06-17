using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedBarthansMapLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BuildingMap",
                columns: new[] { "BuildingId", "MapId", "Coords" },
                values: new object[] { 2, 1, "[1100,3743]" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
