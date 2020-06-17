using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedBuildingMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingMap",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false),
                    MapId = table.Column<int>(nullable: false),
                    Coords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingMap", x => new { x.BuildingId, x.MapId });
                    table.ForeignKey(
                        name: "FK_BuildingMap_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingMap_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BuildingMap",
                columns: new[] { "BuildingId", "MapId", "Coords" },
                values: new object[] { 1, 1, "[1830,3083]" });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingMap_MapId",
                table: "BuildingMap",
                column: "MapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingMap");
        }
    }
}
