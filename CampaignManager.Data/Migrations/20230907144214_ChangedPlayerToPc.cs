using System;
using System.Collections.Generic;
using CampaignManager.Data.Model.Attributes;
using CampaignManager.Data.Model.Operations;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPlayerToPc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.CreateTable(
                name: "pcs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PcName = table.Column<string>(type: "text", nullable: false),
                    Background = table.Column<string>(type: "text", nullable: false),
                    Faction = table.Column<string>(type: "text", nullable: false),
                    Race = table.Column<string>(type: "text", nullable: false),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Strength = table.Column<int>(type: "integer", nullable: false),
                    Dexterity = table.Column<int>(type: "integer", nullable: false),
                    Constitution = table.Column<int>(type: "integer", nullable: false),
                    Intelligence = table.Column<int>(type: "integer", nullable: false),
                    Wisdom = table.Column<int>(type: "integer", nullable: false),
                    Charisma = table.Column<int>(type: "integer", nullable: false),
                    Proficiencies = table.Column<List<Proficiencies>>(type: "jsonb", nullable: true),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    HitDice = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Speed = table.Column<List<Speed>>(type: "jsonb", nullable: true),
                    Languages = table.Column<string>(type: "text", nullable: false),
                    Alignment = table.Column<int>(type: "integer", nullable: false),
                    Reactions = table.Column<List<CreatureAction>>(type: "jsonb", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pcs_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pcs_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pcs_locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pcs_BuildingId",
                table: "pcs",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_pcs_LocaleId",
                table: "pcs",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_pcs_OwnerId",
                table: "pcs",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pcs");

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Alignment = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    Background = table.Column<string>(type: "text", nullable: false),
                    CharacterName = table.Column<string>(type: "text", nullable: false),
                    Charisma = table.Column<int>(type: "integer", nullable: false),
                    Constitution = table.Column<int>(type: "integer", nullable: false),
                    Dexterity = table.Column<int>(type: "integer", nullable: false),
                    Faction = table.Column<string>(type: "text", nullable: false),
                    HitDice = table.Column<string>(type: "text", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    Intelligence = table.Column<int>(type: "integer", nullable: false),
                    Languages = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false),
                    PlayerName = table.Column<string>(type: "text", nullable: false),
                    Proficiencies = table.Column<List<Proficiencies>>(type: "jsonb", nullable: true),
                    Race = table.Column<string>(type: "text", nullable: false),
                    Reactions = table.Column<List<CreatureAction>>(type: "jsonb", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Speed = table.Column<List<Speed>>(type: "jsonb", nullable: true),
                    Strength = table.Column<int>(type: "integer", nullable: false),
                    Wisdom = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_players_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_players_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_players_locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_BuildingId",
                table: "players",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_players_LocaleId",
                table: "players",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_players_OwnerId",
                table: "players",
                column: "OwnerId");
        }
    }
}
