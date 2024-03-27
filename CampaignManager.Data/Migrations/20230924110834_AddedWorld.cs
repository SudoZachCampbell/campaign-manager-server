using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedWorld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorldId",
                table: "continents",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "worlds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Map = table.Column<byte[]>(type: "bytea", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_worlds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_worlds_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_worlds_campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_continents_WorldId",
                table: "continents",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_worlds_CampaignId",
                table: "worlds",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_worlds_OwnerId",
                table: "worlds",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_continents_worlds_WorldId",
                table: "continents",
                column: "WorldId",
                principalTable: "worlds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_continents_worlds_WorldId",
                table: "continents");

            migrationBuilder.DropTable(
                name: "worlds");

            migrationBuilder.DropIndex(
                name: "IX_continents_WorldId",
                table: "continents");

            migrationBuilder.DropColumn(
                name: "WorldId",
                table: "continents");
        }
    }
}
