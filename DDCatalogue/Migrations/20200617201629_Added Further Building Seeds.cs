using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedFurtherBuildingSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 2, 1 },
                column: "Coords",
                value: "[1107,3735]");

            migrationBuilder.InsertData(
                table: "BuildingMap",
                columns: new[] { "BuildingId", "MapId", "Coords" },
                values: new object[,]
                {
                    { 3, 1, "[1041,876]" },
                    { 4, 1, "[2280,2300]" },
                    { 5, 1, "[3101,2115]" },
                    { 6, 1, "[2971,4447]" },
                    { 7, 1, "[1656,2445]" },
                    { 8, 1, "[1913,4396]" },
                    { 9, 1, "[2382,2836]" },
                    { 10, 1, "[1351,6418]" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.UpdateData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 2, 1 },
                column: "Coords",
                value: "[1100,3743]");
        }
    }
}
