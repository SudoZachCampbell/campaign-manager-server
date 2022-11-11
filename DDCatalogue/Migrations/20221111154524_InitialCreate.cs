using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DDCatalogue.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Map = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ContinentId = table.Column<int>(type: "integer", nullable: true),
                    Map = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locales_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LocaleId = table.Column<int>(type: "integer", nullable: true),
                    Map = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Variation = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Center = table.Column<string>(type: "text", nullable: true),
                    LocaleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Map_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Strength = table.Column<int>(type: "integer", nullable: false),
                    Dexterity = table.Column<int>(type: "integer", nullable: false),
                    Constitution = table.Column<int>(type: "integer", nullable: false),
                    Intelligence = table.Column<int>(type: "integer", nullable: false),
                    Wisdom = table.Column<int>(type: "integer", nullable: false),
                    Charisma = table.Column<int>(type: "integer", nullable: false),
                    Proficiencies = table.Column<string>(type: "text", nullable: true),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    HitDice = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Speed = table.Column<string>(type: "text", nullable: true),
                    Languages = table.Column<string>(type: "text", nullable: true),
                    Alignment = table.Column<int>(type: "integer", nullable: false),
                    Reactions = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ChallengeRating = table.Column<double>(type: "double precision", nullable: true),
                    Xp = table.Column<int>(type: "integer", nullable: true),
                    PassivePerception = table.Column<int>(type: "integer", nullable: true),
                    MonsterType = table.Column<int>(type: "integer", nullable: true),
                    Actions = table.Column<string>(type: "text", nullable: true),
                    LegendaryActions = table.Column<string>(type: "text", nullable: true),
                    SpecialAbilities = table.Column<string>(type: "text", nullable: true),
                    Senses = table.Column<string>(type: "text", nullable: true),
                    PlayerName = table.Column<string>(type: "text", nullable: true),
                    Background = table.Column<string>(type: "text", nullable: true),
                    Faction = table.Column<string>(type: "text", nullable: true),
                    Race = table.Column<string>(type: "text", nullable: true),
                    LocaleId = table.Column<int>(type: "integer", nullable: true),
                    BuildingId = table.Column<int>(type: "integer", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Map = table.Column<byte[]>(type: "bytea", nullable: true),
                    BuildingId = table.Column<int>(type: "integer", nullable: true),
                    LocaleId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dungeons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dungeons_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dungeons_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BuildingMap",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "integer", nullable: false),
                    MapId = table.Column<int>(type: "integer", nullable: false),
                    Coords = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "MonsterBuilding",
                columns: table => new
                {
                    MonsterId = table.Column<int>(type: "integer", nullable: false),
                    BuildingId = table.Column<int>(type: "integer", nullable: false)
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
                    MonsterId = table.Column<int>(type: "integer", nullable: false),
                    LocaleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterLocale", x => new { x.MonsterId, x.LocaleId });
                    table.ForeignKey(
                        name: "FK_MonsterLocale_Creature_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterLocale_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Npcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    Background = table.Column<string>(type: "text", nullable: true),
                    NoteableEvents = table.Column<string>(type: "text", nullable: true),
                    Beliefs = table.Column<string>(type: "text", nullable: true),
                    Passions = table.Column<string>(type: "text", nullable: true),
                    Flaws = table.Column<string>(type: "text", nullable: true),
                    MonsterId = table.Column<int>(type: "integer", nullable: true),
                    LocaleId = table.Column<int>(type: "integer", nullable: true),
                    BuildingId = table.Column<int>(type: "integer", nullable: true)
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
                        name: "FK_Npcs_Creature_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Npcs_Locales_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "Map", "Name" },
                values: new object[] { 1, null, "Faerun" });

            migrationBuilder.InsertData(
                table: "Creature",
                columns: new[] { "Id", "Actions", "Alignment", "ArmorClass", "ChallengeRating", "Charisma", "Constitution", "Dexterity", "Discriminator", "HitDice", "HitPoints", "Intelligence", "Languages", "LegendaryActions", "MonsterType", "Name", "PassivePerception", "Picture", "Proficiencies", "Reactions", "Senses", "Size", "SpecialAbilities", "Speed", "Strength", "Wisdom", "Xp" },
                values: new object[,]
                {
                    { 1, "[]", 0, 16, 1.0, 10, 14, 11, "Monster", "", 39, 10, "Common, Dwarvish", "[]", 14, "Drawf Warrior", 10, "", "[]", "[]", "{\"darkvision\":\"60 ft.\"}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":25,\"Measurement\":\"ft\"}]", 14, 11, 0 },
                    { 2, "[{\"name\":\"Morningstar\",\"desc\":\"Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit: 11 (2d8 + 2) piercing damage.\",\"attack_bonus\":4,\"damage\":[{\"damage_type\":{\"name\":\"Piercing\"},\"damage_dice\":\"2d8\",\"damage_bonus\":2}]},{\"name\":\"Javelin\",\"desc\":\"Melee or Ranged Weapon Attack: +4 to hit, reach 5 ft. or range 30/120 ft., one target. Hit: 9 (2d6 + 2) piercing damage in melee or 5 (1d6 + 2) piercing damage at range.\",\"attack_bonus\":4,\"damage\":[{\"damage_type\":{\"name\":\"Piercing\"},\"damage_dice\":\"2d6\",\"damage_bonus\":2}]}]", 8, 16, 1.0, 9, 13, 14, "Monster", "5d8", 27, 8, "Common, Goblin", "[]", 14, "Bugbear", 10, "bugbear.jpeg", "[{\"name\":\"Skill: Stealth\",\"value\":6},{\"name\":\"Skill: Survival\",\"value\":2}]", "[]", "{\"darkvision\":\"60 ft.\"}", "Medium", "[{\"name\":\"Brute\",\"desc\":\"A melee weapon deals one extra die of its damage when the bugbear hits with it (included in the attack).\"},{\"name\":\"Surprise Attack\",\"desc\":\"If the bugbear surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 7 (2d6) damage from the attack.\"}]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 15, 11, 200 },
                    { 3, "[]", 9, 18, 3.0, 15, 14, 11, "Monster", "", 52, 11, "Any one", "[]", 14, "Knight", 10, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 16, 11, 0 },
                    { 4, "[]", 5, 15, 0.25, 8, 10, 14, "Monster", "", 7, 10, "Common, Goblin", "[]", 14, "Goblin", 9, "", "[]", "[]", "{}", "Small", "[]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 8, 8, 0 },
                    { 5, "[]", 9, 10, 0.0, 10, 10, 10, "Monster", "", 4, 10, "Any one", "[]", 14, "Commoner", 10, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 10, 10, 0 },
                    { 6, "[]", 10, 13, 0.25, 6, 12, 15, "Monster", "", 11, 3, "", "[]", 14, "Wolf", 13, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":40,\"Measurement\":\"ft\"}]", 12, 12, 0 },
                    { 7, "[]", 0, 14, 0.5, 10, 12, 10, "Monster", "", 26, 10, "Common, Dwarvish", "[]", 14, "Dwarf", 10, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":25,\"Measurement\":\"ft\"}]", 13, 12, 0 }
                });

            migrationBuilder.InsertData(
                table: "Dungeons",
                columns: new[] { "Id", "BuildingId", "LocaleId", "Map", "Name", "Type" },
                values: new object[] { 1, null, null, null, "Cragmaw Hideout", null });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "ContinentId", "Map", "Name" },
                values: new object[] { 1, 1, "Sword_Coast_North.png", "Sword Coast North" });

            migrationBuilder.InsertData(
                table: "Locales",
                columns: new[] { "Id", "Name", "RegionId" },
                values: new object[,]
                {
                    { 1, "Neverwinter", 1 },
                    { 2, "Thundertree", 1 },
                    { 3, "Cragmaw Castle", 1 },
                    { 4, "Conyberry", 1 },
                    { 5, "Old Owl Well", 1 },
                    { 6, "Phandalin", 1 },
                    { 7, "Leilon", 1 },
                    { 8, "Neverwinter", 1 },
                    { 9, "Cragmaw Hideout", 1 }
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
                    { 10, 6, "Tresendar_Manor.png", "Tresendar Manor" }
                });

            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "Id", "Center", "ImageUrl", "LocaleId", "Name", "Variation" },
                values: new object[,]
                {
                    { 1, null, "PhanDawn.jpg", 6, "Phandalin_Dawn", "Dawn" },
                    { 2, null, "PhanDay.jpg", 6, "Phandalin_Day", "Day" },
                    { 3, null, "PhanNight.jpg", 6, "Phandalin_Night", "Night" }
                });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "Id", "Background", "Beliefs", "BuildingId", "Flaws", "LocaleId", "MonsterId", "Name", "NoteableEvents", "Passions", "Picture" },
                values: new object[,]
                {
                    { 1, "Raised with his three brothers, Klarg was below average intelligence to say the least. Always playing Kings and Queens, he became obsessed with being the ruler of a country. He forged his own crown, and took over a goblin bandit gang declaring himself as their King.|Klarg has since made a deal with Iarno to steal supplies from Phandalin and to resupply the Redbrands instead.", "[]", null, "[]", 9, 2, "Klarg BigCrown", "[\"Made a deal with the party for Yeemik's head\",\"Killed by the party\"]", "[]", "Klarg_BigCrown.jpg" },
                    { 2, "", "[]", null, "[]", 3, 1, "Gundren Rockseeker", "[]", "[]", "" },
                    { 6, "", "[]", null, "[]", 9, 4, "Yeemik Largebrain", "[]", "[]", "" },
                    { 8, "", "[]", null, "[]", 6, 1, "Tharden Rockseeker", "[]", "[]", "" },
                    { 9, "", "[]", null, "[]", 6, 1, "Nundro Rockseeker", "[]", "[]", "" }
                });

            migrationBuilder.InsertData(
                table: "BuildingMap",
                columns: new[] { "BuildingId", "MapId", "Coords" },
                values: new object[,]
                {
                    { 1, 1, "[1830,3083]" },
                    { 1, 2, "[1830,3083]" },
                    { 2, 1, "[1107,3735]" },
                    { 2, 2, "[1107,3735]" },
                    { 3, 1, "[1041,876]" },
                    { 3, 2, "[1041,876]" },
                    { 4, 1, "[2280,2300]" },
                    { 4, 2, "[2280,2300]" },
                    { 5, 1, "[3101,2115]" },
                    { 5, 2, "[3101,2115]" },
                    { 6, 1, "[2971,4447]" },
                    { 6, 2, "[2971,4447]" },
                    { 7, 1, "[1656,2445]" },
                    { 7, 2, "[1656,2445]" },
                    { 8, 1, "[1913,4396]" },
                    { 8, 2, "[1913,4396]" },
                    { 9, 1, "[2382,2836]" },
                    { 9, 2, "[2382,2836]" },
                    { 10, 1, "[1351,6418]" },
                    { 10, 2, "[1351,6418]" }
                });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "Id", "Background", "Beliefs", "BuildingId", "Flaws", "LocaleId", "MonsterId", "Name", "NoteableEvents", "Passions", "Picture" },
                values: new object[,]
                {
                    { 3, "", "[]", 9, "[]", 6, 3, "Sildar Hallwinter", "[]", "[]", "" },
                    { 4, "", "[]", 2, "[]", 6, 5, "Elmar Barthen", "[]", "[]", "" },
                    { 5, "", "[]", 4, "[]", 6, 3, "Linene Graywind", "[]", "[]", "" },
                    { 7, "", "[]", 10, "[]", 6, null, "Iarno Albrek", "[]", "[]", "" },
                    { 10, "", "[]", 1, "[]", 6, 7, "Toblen Stonehill", "[]", "[]", "Toblen_Stonehill.jpg" },
                    { 11, "", "[]", 3, "[]", 6, 5, "Daran Edermath", "[]", "[]", "" },
                    { 12, "", "[]", 5, "[]", 6, 5, "Halia Thornton", "[]", "[]", "" },
                    { 13, "", "[]", 6, "[]", 6, 5, "Qelline Alderleaf", "[]", "[]", "" },
                    { 14, "", "[]", 7, "[]", 6, 5, "Sister Garaele", "[]", "[]", "" },
                    { 15, "", "[]", 9, "[]", 6, 5, "Harbin Wester", "[]", "[]", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingMap_MapId",
                table: "BuildingMap",
                column: "MapId");

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
                name: "IX_Map_LocaleId",
                table: "Map",
                column: "LocaleId");

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
                name: "BuildingMap");

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
                name: "Map");

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
