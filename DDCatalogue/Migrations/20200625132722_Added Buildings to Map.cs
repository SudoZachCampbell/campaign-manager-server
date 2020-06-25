using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedBuildingstoMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BuildingMap",
                columns: new[] { "BuildingId", "MapId", "Coords" },
                values: new object[,]
                {
                    { 1, 2, "[1830,3083]" },
                    { 2, 2, "[1107,3735]" },
                    { 3, 2, "[1041,876]" },
                    { 4, 2, "[2280,2300]" },
                    { 5, 2, "[3101,2115]" },
                    { 6, 2, "[2971,4447]" },
                    { 7, 2, "[1656,2445]" },
                    { 8, 2, "[1913,4396]" },
                    { 9, 2, "[2382,2836]" },
                    { 10, 2, "[1351,6418]" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "BuildingMap",
                keyColumns: new[] { "BuildingId", "MapId" },
                keyValues: new object[] { 10, 2 });
        }
    }
}
