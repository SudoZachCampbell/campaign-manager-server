using System;
using System.Collections.Generic;
using CampaignManager.Data.Model.Attributes;
using CampaignManager.Data.Model.Operations;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_campaigns_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "continents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Map = table.Column<byte[]>(type: "bytea", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_continents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_continents_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_items_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "monsters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChallengeRating = table.Column<double>(type: "double precision", nullable: false),
                    Xp = table.Column<int>(type: "integer", nullable: false),
                    PassivePerception = table.Column<int>(type: "integer", nullable: false),
                    MonsterType = table.Column<int>(type: "integer", nullable: false),
                    Actions = table.Column<List<CreatureAction>>(type: "jsonb", nullable: true),
                    LegendaryActions = table.Column<List<CreatureAction>>(type: "jsonb", nullable: true),
                    SpecialAbilities = table.Column<List<CreatureAction>>(type: "jsonb", nullable: true),
                    Senses = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: true),
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
                    Size = table.Column<string>(type: "text", nullable: false),
                    Speed = table.Column<List<Speed>>(type: "jsonb", nullable: true),
                    Languages = table.Column<string>(type: "text", nullable: false),
                    Alignment = table.Column<int>(type: "integer", nullable: false),
                    Reactions = table.Column<List<CreatureAction>>(type: "jsonb", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_monsters_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounts_campaigns",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts_campaigns", x => new { x.AccountId, x.CampaignId });
                    table.ForeignKey(
                        name: "FK_accounts_campaigns_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_campaigns_campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContinentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Map = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_regions_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_regions_continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "continents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "campaigns_monsters",
                columns: table => new
                {
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaigns_monsters", x => new { x.CampaignId, x.MonsterId });
                    table.ForeignKey(
                        name: "FK_campaigns_monsters_campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_campaigns_monsters_monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_locales_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_locales_regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    Map = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buildings_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buildings_locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "locales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "maps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Variation = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Center = table.Column<string>(type: "text", nullable: true),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_maps_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_maps_locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "monsters_locales",
                columns: table => new
                {
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monsters_locales", x => new { x.MonsterId, x.LocaleId });
                    table.ForeignKey(
                        name: "FK_monsters_locales_locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_monsters_locales_monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dungeons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Map = table.Column<byte[]>(type: "bytea", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dungeons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dungeons_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dungeons_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dungeons_locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "locales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "monsters_buildings",
                columns: table => new
                {
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monsters_buildings", x => new { x.MonsterId, x.BuildingId });
                    table.ForeignKey(
                        name: "FK_monsters_buildings_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_monsters_buildings_monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "npcs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Background = table.Column<string>(type: "text", nullable: false),
                    NoteableEvents = table.Column<string>(type: "text", nullable: true),
                    Beliefs = table.Column<string>(type: "text", nullable: true),
                    Passions = table.Column<string>(type: "text", nullable: true),
                    Flaws = table.Column<string>(type: "text", nullable: true),
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    Size = table.Column<string>(type: "text", nullable: false),
                    Speed = table.Column<List<Speed>>(type: "jsonb", nullable: true),
                    Languages = table.Column<string>(type: "text", nullable: false),
                    Alignment = table.Column<int>(type: "integer", nullable: false),
                    Reactions = table.Column<List<CreatureAction>>(type: "jsonb", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_npcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_npcs_accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_npcs_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_npcs_locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_npcs_monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterName = table.Column<string>(type: "text", nullable: false),
                    PlayerName = table.Column<string>(type: "text", nullable: false),
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
                    Size = table.Column<string>(type: "text", nullable: false),
                    Speed = table.Column<List<Speed>>(type: "jsonb", nullable: true),
                    Languages = table.Column<string>(type: "text", nullable: false),
                    Alignment = table.Column<int>(type: "integer", nullable: false),
                    Reactions = table.Column<List<CreatureAction>>(type: "jsonb", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "buildings_maps",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: false),
                    MapId = table.Column<Guid>(type: "uuid", nullable: false),
                    Coords = table.Column<List<int>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings_maps", x => new { x.BuildingId, x.MapId });
                    table.ForeignKey(
                        name: "FK_buildings_maps_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buildings_maps_maps_MapId",
                        column: x => x.MapId,
                        principalTable: "maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_campaigns_CampaignId",
                table: "accounts_campaigns",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_buildings_LocaleId",
                table: "buildings",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_buildings_OwnerId",
                table: "buildings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_buildings_maps_MapId",
                table: "buildings_maps",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_campaigns_OwnerId",
                table: "campaigns",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_campaigns_monsters_MonsterId",
                table: "campaigns_monsters",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_continents_OwnerId",
                table: "continents",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_dungeons_BuildingId",
                table: "dungeons",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_dungeons_LocaleId",
                table: "dungeons",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_dungeons_OwnerId",
                table: "dungeons",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_items_OwnerId",
                table: "items",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_locales_OwnerId",
                table: "locales",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_locales_RegionId",
                table: "locales",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_maps_LocaleId",
                table: "maps",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_maps_OwnerId",
                table: "maps",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_monsters_OwnerId",
                table: "monsters",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_monsters_buildings_BuildingId",
                table: "monsters_buildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_monsters_locales_LocaleId",
                table: "monsters_locales",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_npcs_BuildingId",
                table: "npcs",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_npcs_LocaleId",
                table: "npcs",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_npcs_MonsterId",
                table: "npcs",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_npcs_OwnerId",
                table: "npcs",
                column: "OwnerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_regions_ContinentId",
                table: "regions",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_regions_OwnerId",
                table: "regions",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts_campaigns");

            migrationBuilder.DropTable(
                name: "buildings_maps");

            migrationBuilder.DropTable(
                name: "campaigns_monsters");

            migrationBuilder.DropTable(
                name: "dungeons");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "monsters_buildings");

            migrationBuilder.DropTable(
                name: "monsters_locales");

            migrationBuilder.DropTable(
                name: "npcs");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "maps");

            migrationBuilder.DropTable(
                name: "campaigns");

            migrationBuilder.DropTable(
                name: "monsters");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "locales");

            migrationBuilder.DropTable(
                name: "regions");

            migrationBuilder.DropTable(
                name: "continents");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
