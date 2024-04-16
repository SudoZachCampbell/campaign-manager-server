using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_maps_campaigns_CampaignId",
                table: "maps");

            migrationBuilder.DropForeignKey(
                name: "FK_maps_locales_LocaleId",
                table: "maps");

            migrationBuilder.DropIndex(
                name: "IX_maps_CampaignId",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "worlds");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "regions");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "dungeons");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "continents");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "buildings");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocaleId",
                table: "maps",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ContinentId",
                table: "maps",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DungeonId",
                table: "maps",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "maps",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorldId",
                table: "maps",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_maps_ContinentId",
                table: "maps",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_maps_DungeonId",
                table: "maps",
                column: "DungeonId");

            migrationBuilder.CreateIndex(
                name: "IX_maps_RegionId",
                table: "maps",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_maps_WorldId",
                table: "maps",
                column: "WorldId");

            migrationBuilder.AddForeignKey(
                name: "FK_maps_continents_ContinentId",
                table: "maps",
                column: "ContinentId",
                principalTable: "continents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_maps_dungeons_DungeonId",
                table: "maps",
                column: "DungeonId",
                principalTable: "dungeons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_maps_locales_LocaleId",
                table: "maps",
                column: "LocaleId",
                principalTable: "locales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_maps_regions_RegionId",
                table: "maps",
                column: "RegionId",
                principalTable: "regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_maps_worlds_WorldId",
                table: "maps",
                column: "WorldId",
                principalTable: "worlds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_maps_continents_ContinentId",
                table: "maps");

            migrationBuilder.DropForeignKey(
                name: "FK_maps_dungeons_DungeonId",
                table: "maps");

            migrationBuilder.DropForeignKey(
                name: "FK_maps_locales_LocaleId",
                table: "maps");

            migrationBuilder.DropForeignKey(
                name: "FK_maps_regions_RegionId",
                table: "maps");

            migrationBuilder.DropForeignKey(
                name: "FK_maps_worlds_WorldId",
                table: "maps");

            migrationBuilder.DropIndex(
                name: "IX_maps_ContinentId",
                table: "maps");

            migrationBuilder.DropIndex(
                name: "IX_maps_DungeonId",
                table: "maps");

            migrationBuilder.DropIndex(
                name: "IX_maps_RegionId",
                table: "maps");

            migrationBuilder.DropIndex(
                name: "IX_maps_WorldId",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "ContinentId",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "DungeonId",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "WorldId",
                table: "maps");

            migrationBuilder.AddColumn<byte[]>(
                name: "Map",
                table: "worlds",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "regions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocaleId",
                table: "maps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                table: "maps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "Map",
                table: "dungeons",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Map",
                table: "continents",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "buildings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_maps_CampaignId",
                table: "maps",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_maps_campaigns_CampaignId",
                table: "maps",
                column: "CampaignId",
                principalTable: "campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_maps_locales_LocaleId",
                table: "maps",
                column: "LocaleId",
                principalTable: "locales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
