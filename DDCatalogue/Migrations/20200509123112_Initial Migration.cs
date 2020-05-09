using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    ContinentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.ContinentId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ContinentId = table.Column<int>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                    table.ForeignKey(
                        name: "FK_Regions_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "ContinentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    LocaleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.LocaleId);
                    table.ForeignKey(
                        name: "FK_Locales_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LocaleId = table.Column<int>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "LocaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dungeons",
                columns: table => new
                {
                    DungeonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true),
                    BuildingId = table.Column<int>(nullable: true),
                    MunicipalityLocaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dungeons", x => x.DungeonId);
                    table.ForeignKey(
                        name: "FK_Dungeons_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dungeons_Locales_MunicipalityLocaleId",
                        column: x => x.MunicipalityLocaleId,
                        principalTable: "Locales",
                        principalColumn: "LocaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Str = table.Column<int>(nullable: true),
                    Dex = table.Column<int>(nullable: true),
                    Con = table.Column<int>(nullable: true),
                    Int = table.Column<int>(nullable: true),
                    Wis = table.Column<int>(nullable: true),
                    Cha = table.Column<int>(nullable: true),
                    Acrobatics = table.Column<bool>(nullable: true),
                    AnimalHandling = table.Column<bool>(nullable: true),
                    Arcana = table.Column<bool>(nullable: true),
                    Athletics = table.Column<bool>(nullable: true),
                    Deception = table.Column<bool>(nullable: true),
                    History = table.Column<bool>(nullable: true),
                    Insight = table.Column<bool>(nullable: true),
                    Intimidation = table.Column<bool>(nullable: true),
                    Investigations = table.Column<bool>(nullable: true),
                    Medicine = table.Column<bool>(nullable: true),
                    Nature = table.Column<bool>(nullable: true),
                    Perception = table.Column<bool>(nullable: true),
                    Performance = table.Column<bool>(nullable: true),
                    Persuasion = table.Column<bool>(nullable: true),
                    Religion = table.Column<bool>(nullable: true),
                    SleightOfHand = table.Column<bool>(nullable: true),
                    Stealth = table.Column<bool>(nullable: true),
                    Survival = table.Column<bool>(nullable: true),
                    SavStr = table.Column<bool>(nullable: true),
                    SavDex = table.Column<bool>(nullable: true),
                    SavCon = table.Column<bool>(nullable: true),
                    SavInt = table.Column<bool>(nullable: true),
                    SavWis = table.Column<bool>(nullable: true),
                    SavCha = table.Column<bool>(nullable: true),
                    Ac = table.Column<int>(nullable: false),
                    Hp = table.Column<int>(nullable: false),
                    HitDice = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    Traits = table.Column<string>(nullable: true),
                    Alignment = table.Column<int>(nullable: false),
                    Reactions = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    LocaleId = table.Column<int>(nullable: true),
                    BuildingId = table.Column<int>(nullable: true),
                    PlayerName = table.Column<string>(nullable: true),
                    Background = table.Column<string>(nullable: true),
                    Faction = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    PlayerId = table.Column<int>(nullable: true),
                    NpcId = table.Column<int>(nullable: true),
                    Monster_LocaleId = table.Column<int>(nullable: true),
                    Monster_BuildingId = table.Column<int>(nullable: true),
                    Senses = table.Column<string>(nullable: true),
                    Challenge = table.Column<double>(nullable: true),
                    DefeatXp = table.Column<int>(nullable: true),
                    Pp = table.Column<int>(nullable: true),
                    Actions = table.Column<string>(nullable: true),
                    LegendaryActions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.CreatureId);
                    table.ForeignKey(
                        name: "FK_Creature_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Creature_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "LocaleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Creature_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Creature_Buildings_Monster_BuildingId",
                        column: x => x.Monster_BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Creature_Locales_Monster_LocaleId",
                        column: x => x.Monster_LocaleId,
                        principalTable: "Locales",
                        principalColumn: "LocaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Npcs",
                columns: table => new
                {
                    NpcId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npcs", x => x.NpcId);
                    table.ForeignKey(
                        name: "FK_Npcs_Creature_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creature",
                        principalColumn: "CreatureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Creature",
                columns: new[] { "CreatureId", "Ac", "Acrobatics", "Alignment", "AnimalHandling", "Arcana", "Athletics", "Cha", "Con", "Deception", "Dex", "Discriminator", "History", "HitDice", "Hp", "Insight", "Int", "Intimidation", "Investigations", "Languages", "Medicine", "Name", "Nature", "Perception", "Performance", "Persuasion", "Reactions", "Religion", "SavCha", "SavCon", "SavDex", "SavInt", "SavStr", "SavWis", "SleightOfHand", "Speed", "Stealth", "Str", "Survival", "Traits", "Wis", "Actions", "Monster_BuildingId", "Challenge", "DefeatXp", "LegendaryActions", "Monster_LocaleId", "Pp", "Senses" },
                values: new object[] { 1, 16, null, 0, null, null, null, 10, 14, null, 11, "Monster", null, null, 39, null, 10, null, null, "Common, Dwarvish", null, "Drawf Warrior", null, null, null, null, null, null, null, null, null, null, null, null, null, "25ft", null, 14, null, null, 11, null, null, 1.0, 200, null, null, 10, "Darkvision 60ft" });

            migrationBuilder.InsertData(
                table: "Creature",
                columns: new[] { "CreatureId", "Ac", "Acrobatics", "Alignment", "AnimalHandling", "Arcana", "Athletics", "Cha", "Con", "Deception", "Dex", "Discriminator", "History", "HitDice", "Hp", "Insight", "Int", "Intimidation", "Investigations", "Languages", "Medicine", "Name", "Nature", "Perception", "Performance", "Persuasion", "Reactions", "Religion", "SavCha", "SavCon", "SavDex", "SavInt", "SavStr", "SavWis", "SleightOfHand", "Speed", "Stealth", "Str", "Survival", "Traits", "Wis", "Actions", "Monster_BuildingId", "Challenge", "DefeatXp", "LegendaryActions", "Monster_LocaleId", "Pp", "Senses" },
                values: new object[] { 2, 16, null, 8, null, null, null, 9, 13, null, 14, "Monster", null, null, 27, null, 8, null, null, "Common, Goblin", null, "Bugbear", null, null, null, null, null, null, null, null, null, null, null, null, null, "30ft", null, 15, null, null, 11, null, null, 1.0, 200, null, null, 10, "Darkvision 60ft" });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "NpcId", "CreatureId", "Name" },
                values: new object[] { 1, 1, "Engrad Longbones" });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_LocaleId",
                table: "Buildings",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_BuildingId",
                table: "Creature",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_LocaleId",
                table: "Creature",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_NpcId",
                table: "Creature",
                column: "NpcId");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_PlayerId",
                table: "Creature",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_Monster_BuildingId",
                table: "Creature",
                column: "Monster_BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_Monster_LocaleId",
                table: "Creature",
                column: "Monster_LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Dungeons_BuildingId",
                table: "Dungeons",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Dungeons_MunicipalityLocaleId",
                table: "Dungeons",
                column: "MunicipalityLocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Locales_RegionId",
                table: "Locales",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_CreatureId",
                table: "Npcs",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ContinentId",
                table: "Regions",
                column: "ContinentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Creature_Npcs_NpcId",
                table: "Creature",
                column: "NpcId",
                principalTable: "Npcs",
                principalColumn: "NpcId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Locales_LocaleId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Creature_Locales_LocaleId",
                table: "Creature");

            migrationBuilder.DropForeignKey(
                name: "FK_Creature_Locales_Monster_LocaleId",
                table: "Creature");

            migrationBuilder.DropForeignKey(
                name: "FK_Creature_Buildings_BuildingId",
                table: "Creature");

            migrationBuilder.DropForeignKey(
                name: "FK_Creature_Buildings_Monster_BuildingId",
                table: "Creature");

            migrationBuilder.DropForeignKey(
                name: "FK_Creature_Npcs_NpcId",
                table: "Creature");

            migrationBuilder.DropTable(
                name: "Dungeons");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Locales");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Npcs");

            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
