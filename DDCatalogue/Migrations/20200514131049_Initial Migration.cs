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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ContinentId = table.Column<int>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locales_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LocaleId = table.Column<int>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    Senses = table.Column<string>(nullable: true),
                    Challenge = table.Column<double>(nullable: true),
                    DefeatXp = table.Column<int>(nullable: true),
                    Pp = table.Column<int>(nullable: true),
                    Actions = table.Column<string>(nullable: true),
                    LegendaryActions = table.Column<string>(nullable: true),
                    PlayerName = table.Column<string>(nullable: true),
                    Background = table.Column<string>(nullable: true),
                    Faction = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    LocaleId = table.Column<int>(nullable: true),
                    BuildingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creature_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Creature_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dungeons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true),
                    BuildingId = table.Column<int>(nullable: true),
                    LocaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dungeons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dungeons_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dungeons_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonsterBuilding",
                columns: table => new
                {
                    MonsterId = table.Column<int>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterBuilding", x => new { x.MonsterId, x.BuildingId });
                    table.ForeignKey(
                        name: "FK_MonsterBuilding_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterBuilding_Creature_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonsterLocale",
                columns: table => new
                {
                    MonsterId = table.Column<int>(nullable: false),
                    LocaleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterLocale", x => new { x.MonsterId, x.LocaleId });
                    table.ForeignKey(
                        name: "FK_MonsterLocale_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterLocale_Creature_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Npcs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MonsterId = table.Column<int>(nullable: true),
                    LocaleId = table.Column<int>(nullable: true),
                    BuildingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Npcs_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Npcs_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Npcs_Creature_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Creature",
                columns: new[] { "Id", "Ac", "Acrobatics", "Alignment", "AnimalHandling", "Arcana", "Athletics", "Cha", "Con", "Deception", "Dex", "Discriminator", "History", "HitDice", "Hp", "Insight", "Int", "Intimidation", "Investigations", "Languages", "Medicine", "Name", "Nature", "Perception", "Performance", "Persuasion", "Reactions", "Religion", "SavCha", "SavCon", "SavDex", "SavInt", "SavStr", "SavWis", "SleightOfHand", "Speed", "Stealth", "Str", "Survival", "Traits", "Wis", "Actions", "Challenge", "DefeatXp", "LegendaryActions", "Pp", "Senses" },
                values: new object[,]
                {
                    { 1, 16, null, 0, null, null, null, 10, 14, null, 11, "Monster", null, null, 39, null, 10, null, null, "Common, Dwarvish", null, "Drawf Warrior", null, null, null, null, null, null, null, null, null, null, null, null, null, "25ft", null, 14, null, null, 11, null, 1.0, 200, null, 10, "Darkvision 60ft" },
                    { 2, 16, null, 8, null, null, null, 9, 13, null, 14, "Monster", null, null, 27, null, 8, null, null, "Common, Goblin", null, "Bugbear", null, null, null, null, null, null, null, null, null, null, null, null, null, "30ft", null, 15, null, null, 11, null, 1.0, 200, null, 10, "Darkvision 60ft" },
                    { 3, 18, null, 9, null, null, null, 15, 14, null, 11, "Monster", null, null, 52, null, 11, null, null, "Any one", null, "Knight", null, null, null, null, null, null, null, null, null, null, null, null, null, "30ft", null, 16, null, null, 11, null, 3.0, 700, null, 10, null },
                    { 4, 15, null, 5, null, null, null, 8, 10, null, 14, "Monster", null, null, 7, null, 10, null, null, "Common, Goblin", null, "Goblin", null, null, null, null, null, null, null, null, null, null, null, null, null, "30ft", null, 8, null, null, 8, null, 0.25, 50, null, 9, null },
                    { 5, 10, null, 9, null, null, null, 10, 10, null, 10, "Monster", null, null, 4, null, 10, null, null, "Any one", null, "Commoner", null, null, null, null, null, null, null, null, null, null, null, null, null, "30ft", null, 10, null, null, 10, null, 0.0, 10, null, 10, null },
                    { 6, 13, null, 10, null, null, null, 6, 12, null, 15, "Monster", null, null, 11, null, 3, null, null, "", null, "Wolf", null, null, null, null, null, null, null, null, null, null, null, null, null, "40ft", null, 12, null, null, 12, null, 0.25, 50, null, 13, null },
                    { 7, 14, null, 0, null, null, null, 10, 12, null, 10, "Monster", null, null, 26, null, 10, null, null, "Common, Dwarvish", null, "Dwarf", null, null, null, null, null, null, null, null, null, null, null, null, null, "25ft", null, 13, null, null, 12, null, 0.5, 100, null, 10, null }
                });

            migrationBuilder.InsertData(
                table: "Dungeons",
                columns: new[] { "Id", "BuildingId", "LocaleId", "Map", "Name", "Type" },
                values: new object[] { 1, null, null, null, "Cragmaw Hideout", null });

            migrationBuilder.InsertData(
                table: "Locales",
                columns: new[] { "Id", "Map", "Name", "RegionId" },
                values: new object[,]
                {
                    { 7, null, "Leilon", null },
                    { 6, null, "Phandalin", null },
                    { 5, null, "Old Owl Well", null },
                    { 1, null, "Neverwinter", null },
                    { 3, null, "Cragmaw Castle", null },
                    { 2, null, "Thundertree", null },
                    { 8, null, "Neverwinter", null },
                    { 4, null, "Conyberry", null },
                    { 9, null, "Cragmaw Hideout", null }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "LocaleId", "Map", "Name" },
                values: new object[,]
                {
                    { 1, 6, null, "Stonehill Inn" },
                    { 2, 6, null, "Barthen's Provisions" },
                    { 3, 6, null, "Edermath Orchard" },
                    { 4, 6, null, "Lionshield Coster" },
                    { 5, 6, null, "Phandalin Miner's Exchange" },
                    { 6, 6, null, "Alderleaf Farm" },
                    { 7, 6, null, "Shrine of Luck" },
                    { 8, 6, null, "The Sleeping Giant" },
                    { 9, 6, null, "Townmaster's Hall" },
                    { 10, 6, null, "Tresendar Manor" }
                });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "Id", "BuildingId", "LocaleId", "MonsterId", "Name" },
                values: new object[,]
                {
                    { 2, null, 3, 1, "Gundren Rockseeker" },
                    { 8, null, 6, 1, "Tharden Rockseeker" },
                    { 9, null, 6, 1, "Nundro Rockseeker" },
                    { 1, null, 9, 2, "Klarg Big-Crown" },
                    { 6, null, 9, 4, "Yeemik Largebrain" }
                });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "Id", "BuildingId", "LocaleId", "MonsterId", "Name" },
                values: new object[,]
                {
                    { 10, 1, null, 7, "Toblen Stonehill" },
                    { 4, 2, null, 5, "Elmar Barthen" },
                    { 11, 3, null, 5, "Daran Edermath" },
                    { 5, 4, null, 3, "Linene Graywind" },
                    { 12, 5, null, 5, "Halia Thornton" },
                    { 13, 6, null, 5, "Qelline Alderleaf" },
                    { 14, 7, null, 5, "Sister Garaele" },
                    { 3, 9, null, 3, "Sildar Hallwinter" },
                    { 15, 9, null, 5, "Harbin Wester" },
                    { 7, 10, null, null, "Iarno Albrek" }
                });

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
                name: "IX_Dungeons_BuildingId",
                table: "Dungeons",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Dungeons_LocaleId",
                table: "Dungeons",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Locales_RegionId",
                table: "Locales",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterBuilding_BuildingId",
                table: "MonsterBuilding",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterLocale_LocaleId",
                table: "MonsterLocale",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_BuildingId",
                table: "Npcs",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_LocaleId",
                table: "Npcs",
                column: "LocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_MonsterId",
                table: "Npcs",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ContinentId",
                table: "Regions",
                column: "ContinentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dungeons");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "MonsterBuilding");

            migrationBuilder.DropTable(
                name: "MonsterLocale");

            migrationBuilder.DropTable(
                name: "Npcs");

            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Locales");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
