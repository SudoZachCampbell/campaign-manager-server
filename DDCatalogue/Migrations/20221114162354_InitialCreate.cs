using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDCatalogue.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Map = table.Column<byte[]>(type: "bytea", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContinentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Map = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    Map = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Variation = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Center = table.Column<string>(type: "text", nullable: true),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Map = table.Column<byte[]>(type: "bytea", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: false),
                    MapId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    Background = table.Column<string>(type: "text", nullable: true),
                    NoteableEvents = table.Column<string>(type: "text", nullable: true),
                    Beliefs = table.Column<string>(type: "text", nullable: true),
                    Passions = table.Column<string>(type: "text", nullable: true),
                    Flaws = table.Column<string>(type: "text", nullable: true),
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                values: new object[] { new Guid("9504646c-77c0-4f92-aec1-2fadf62cd2b7"), null, "Faerun" });

            migrationBuilder.InsertData(
                table: "Creature",
                columns: new[] { "Id", "Actions", "Alignment", "ArmorClass", "ChallengeRating", "Charisma", "Constitution", "Dexterity", "Discriminator", "HitDice", "HitPoints", "Intelligence", "Languages", "LegendaryActions", "MonsterType", "Name", "PassivePerception", "Picture", "Proficiencies", "Reactions", "Senses", "Size", "SpecialAbilities", "Speed", "Strength", "Wisdom", "Xp" },
                values: new object[,]
                {
                    { new Guid("02108b37-768b-45dc-82ae-968041ee541f"), "[]", 10, 13, 0.25, 6, 12, 15, "Monster", "", 11, 3, "", "[]", 14, "Wolf", 13, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":40,\"Measurement\":\"ft\"}]", 12, 12, 0 },
                    { new Guid("0cc31a48-dfa1-403c-ac9a-1c39bd533dfb"), "[]", 0, 16, 1.0, 10, 14, 11, "Monster", "", 39, 10, "Common, Dwarvish", "[]", 14, "Drawf Warrior", 10, "", "[]", "[]", "{\"darkvision\":\"60 ft.\"}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":25,\"Measurement\":\"ft\"}]", 14, 11, 0 },
                    { new Guid("2dc5b20f-6d65-4c4d-8928-597d3e8291fa"), "[]", 0, 14, 0.5, 10, 12, 10, "Monster", "", 26, 10, "Common, Dwarvish", "[]", 14, "Dwarf", 10, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":25,\"Measurement\":\"ft\"}]", 13, 12, 0 },
                    { new Guid("a17bd70f-a811-4a63-bd43-17f77f696e86"), "[]", 5, 15, 0.25, 8, 10, 14, "Monster", "", 7, 10, "Common, Goblin", "[]", 14, "Goblin", 9, "", "[]", "[]", "{}", "Small", "[]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 8, 8, 0 },
                    { new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "[]", 9, 10, 0.0, 10, 10, 10, "Monster", "", 4, 10, "Any one", "[]", 14, "Commoner", 10, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 10, 10, 0 },
                    { new Guid("dbfb7da7-08b2-4b12-adf4-2f8fe7c15c34"), "[{\"name\":\"Morningstar\",\"desc\":\"Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit: 11 (2d8 + 2) piercing damage.\",\"attack_bonus\":4,\"damage\":[{\"damage_type\":{\"name\":\"Piercing\"},\"damage_dice\":\"2d8\",\"damage_bonus\":2}]},{\"name\":\"Javelin\",\"desc\":\"Melee or Ranged Weapon Attack: +4 to hit, reach 5 ft. or range 30/120 ft., one target. Hit: 9 (2d6 + 2) piercing damage in melee or 5 (1d6 + 2) piercing damage at range.\",\"attack_bonus\":4,\"damage\":[{\"damage_type\":{\"name\":\"Piercing\"},\"damage_dice\":\"2d6\",\"damage_bonus\":2}]}]", 8, 16, 1.0, 9, 13, 14, "Monster", "5d8", 27, 8, "Common, Goblin", "[]", 14, "Bugbear", 10, "bugbear.jpeg", "[{\"name\":\"Skill: Stealth\",\"value\":6},{\"name\":\"Skill: Survival\",\"value\":2}]", "[]", "{\"darkvision\":\"60 ft.\"}", "Medium", "[{\"name\":\"Brute\",\"desc\":\"A melee weapon deals one extra die of its damage when the bugbear hits with it (included in the attack).\"},{\"name\":\"Surprise Attack\",\"desc\":\"If the bugbear surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 7 (2d6) damage from the attack.\"}]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 15, 11, 200 },
                    { new Guid("fe3133a3-b86a-4f53-833c-df0bb75dc2a2"), "[]", 9, 18, 3.0, 15, 14, 11, "Monster", "", 52, 11, "Any one", "[]", 14, "Knight", 10, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 16, 11, 0 }
                });

            migrationBuilder.InsertData(
                table: "Dungeons",
                columns: new[] { "Id", "BuildingId", "LocaleId", "Map", "Name", "Type" },
                values: new object[] { new Guid("20d431a5-d40e-4e75-a9c1-ca8ae353e0ed"), null, null, null, "Cragmaw Hideout", null });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "ContinentId", "Map", "Name" },
                values: new object[] { new Guid("050b1c46-0676-420b-872c-143db80d358b"), new Guid("9504646c-77c0-4f92-aec1-2fadf62cd2b7"), "Sword_Coast_North.png", "Sword Coast North" });

            migrationBuilder.InsertData(
                table: "Locales",
                columns: new[] { "Id", "Name", "RegionId" },
                values: new object[,]
                {
                    { new Guid("05b8a745-b8aa-4bba-b7c7-507cd352b02e"), "Old Owl Well", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("23f6a61a-bf84-4039-9be4-9eb5192c57c6"), "Neverwinter", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("46a4a3a3-70bb-4782-bfa9-ea13397cb4ac"), "Leilon", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("70c4e46c-0287-4320-a4dc-6adfd08011b0"), "Conyberry", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("82cb5a0f-a72a-4b3b-adbe-4c540bae2eee"), "Neverwinter", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), "Phandalin", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("9b2ff871-d933-4811-acfa-764f8173df3c"), "Cragmaw Castle", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("a5d3885b-7b2a-466d-88ba-921f1d71f1b4"), "Cragmaw Hideout", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("cfbe696c-02af-47e8-9b58-2103a6f04c9b"), "Thundertree", new Guid("050b1c46-0676-420b-872c-143db80d358b") }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "LocaleId", "Map", "Name" },
                values: new object[,]
                {
                    { new Guid("0110289a-95c6-4385-be5d-741821c8a107"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), null, "Edermath Orchard" },
                    { new Guid("3829d18f-0c01-4c08-a16f-55d983db578a"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), null, "Townmaster's Hall" },
                    { new Guid("4c3bf7ce-dfd6-4894-afa7-f86137003e87"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), null, "Shrine of Luck" },
                    { new Guid("5ca1de81-cf25-4c98-a251-1c3fe661457f"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), "Tresendar_Manor.png", "Tresendar Manor" },
                    { new Guid("6f6bfd5e-a158-487a-b54a-9f27842ce762"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), null, "Stonehill Inn" },
                    { new Guid("7042bd21-7239-4866-bcd3-a7a054c05430"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), null, "Alderleaf Farm" },
                    { new Guid("b3c67d0b-ba6c-4974-b393-5c7d3f1d6644"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), null, "Barthen's Provisions" },
                    { new Guid("b439fe6f-dde1-4854-8ea6-a5972a6ea06e"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), null, "Lionshield Coster" },
                    { new Guid("d4b56822-cd18-4a75-b8c9-b51f1d32236c"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), null, "The Sleeping Giant" },
                    { new Guid("e54fa7e6-34c0-4ed4-9338-9341162739e5"), new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), null, "Phandalin Miner's Exchange" }
                });

            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "Id", "Center", "ImageUrl", "LocaleId", "Name", "Variation" },
                values: new object[,]
                {
                    { new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), null, "PhanDawn.jpg", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), "Phandalin_Dawn", "Dawn" },
                    { new Guid("a4fa09ec-f479-464b-afd0-1c9e89ff080b"), null, "PhanNight.jpg", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), "Phandalin_Night", "Night" },
                    { new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), null, "PhanDay.jpg", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), "Phandalin_Day", "Day" }
                });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "Id", "Background", "Beliefs", "BuildingId", "Flaws", "LocaleId", "MonsterId", "Name", "NoteableEvents", "Passions", "Picture" },
                values: new object[,]
                {
                    { new Guid("5004c517-1e49-4a93-917a-f6de57262c70"), "", "[]", null, "[]", new Guid("a5d3885b-7b2a-466d-88ba-921f1d71f1b4"), new Guid("a17bd70f-a811-4a63-bd43-17f77f696e86"), "Yeemik Largebrain", "[]", "[]", "" },
                    { new Guid("915c0e65-755d-4a10-9ebc-1d2ef045f5f6"), "", "[]", null, "[]", new Guid("9b2ff871-d933-4811-acfa-764f8173df3c"), new Guid("0cc31a48-dfa1-403c-ac9a-1c39bd533dfb"), "Gundren Rockseeker", "[]", "[]", "" },
                    { new Guid("ada63dfd-4645-49ad-b64d-fc3ccfb642e3"), "Raised with his three brothers, Klarg was below average intelligence to say the least. Always playing Kings and Queens, he became obsessed with being the ruler of a country. He forged his own crown, and took over a goblin bandit gang declaring himself as their King.|Klarg has since made a deal with Iarno to steal supplies from Phandalin and to resupply the Redbrands instead.", "[]", null, "[]", new Guid("a5d3885b-7b2a-466d-88ba-921f1d71f1b4"), new Guid("dbfb7da7-08b2-4b12-adf4-2f8fe7c15c34"), "Klarg BigCrown", "[\"Made a deal with the party for Yeemik's head\",\"Killed by the party\"]", "[]", "Klarg_BigCrown.jpg" },
                    { new Guid("b11241c1-f071-4103-a03f-b3dcd806d61c"), "", "[]", null, "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("0cc31a48-dfa1-403c-ac9a-1c39bd533dfb"), "Tharden Rockseeker", "[]", "[]", "" },
                    { new Guid("f0df09cf-a538-482a-8a08-ffc47b0f27a0"), "", "[]", null, "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("0cc31a48-dfa1-403c-ac9a-1c39bd533dfb"), "Nundro Rockseeker", "[]", "[]", "" }
                });

            migrationBuilder.InsertData(
                table: "BuildingMap",
                columns: new[] { "BuildingId", "MapId", "Coords" },
                values: new object[,]
                {
                    { new Guid("0110289a-95c6-4385-be5d-741821c8a107"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[1041,876]" },
                    { new Guid("0110289a-95c6-4385-be5d-741821c8a107"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[1041,876]" },
                    { new Guid("3829d18f-0c01-4c08-a16f-55d983db578a"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[2382,2836]" },
                    { new Guid("3829d18f-0c01-4c08-a16f-55d983db578a"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[2382,2836]" },
                    { new Guid("4c3bf7ce-dfd6-4894-afa7-f86137003e87"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[1656,2445]" },
                    { new Guid("4c3bf7ce-dfd6-4894-afa7-f86137003e87"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[1656,2445]" },
                    { new Guid("5ca1de81-cf25-4c98-a251-1c3fe661457f"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[1351,6418]" },
                    { new Guid("5ca1de81-cf25-4c98-a251-1c3fe661457f"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[1351,6418]" },
                    { new Guid("6f6bfd5e-a158-487a-b54a-9f27842ce762"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[1830,3083]" },
                    { new Guid("6f6bfd5e-a158-487a-b54a-9f27842ce762"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[1830,3083]" },
                    { new Guid("7042bd21-7239-4866-bcd3-a7a054c05430"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[2971,4447]" },
                    { new Guid("7042bd21-7239-4866-bcd3-a7a054c05430"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[2971,4447]" },
                    { new Guid("b3c67d0b-ba6c-4974-b393-5c7d3f1d6644"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[1107,3735]" },
                    { new Guid("b3c67d0b-ba6c-4974-b393-5c7d3f1d6644"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[1107,3735]" },
                    { new Guid("b439fe6f-dde1-4854-8ea6-a5972a6ea06e"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[2280,2300]" },
                    { new Guid("b439fe6f-dde1-4854-8ea6-a5972a6ea06e"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[2280,2300]" },
                    { new Guid("d4b56822-cd18-4a75-b8c9-b51f1d32236c"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[1913,4396]" },
                    { new Guid("d4b56822-cd18-4a75-b8c9-b51f1d32236c"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[1913,4396]" },
                    { new Guid("e54fa7e6-34c0-4ed4-9338-9341162739e5"), new Guid("148d6be4-48e7-451e-8096-2f399937fc51"), "[3101,2115]" },
                    { new Guid("e54fa7e6-34c0-4ed4-9338-9341162739e5"), new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), "[3101,2115]" }
                });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "Id", "Background", "Beliefs", "BuildingId", "Flaws", "LocaleId", "MonsterId", "Name", "NoteableEvents", "Passions", "Picture" },
                values: new object[,]
                {
                    { new Guid("08740102-65fd-47d4-a1c2-eeb07b6e0915"), "", "[]", new Guid("3829d18f-0c01-4c08-a16f-55d983db578a"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Harbin Wester", "[]", "[]", "" },
                    { new Guid("21327109-05b8-44a7-961c-f511101bc7b4"), "", "[]", new Guid("6f6bfd5e-a158-487a-b54a-9f27842ce762"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("2dc5b20f-6d65-4c4d-8928-597d3e8291fa"), "Toblen Stonehill", "[]", "[]", "Toblen_Stonehill.jpg" },
                    { new Guid("25af5ee4-f7e3-415b-9555-198e75d20a07"), "", "[]", new Guid("e54fa7e6-34c0-4ed4-9338-9341162739e5"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Halia Thornton", "[]", "[]", "" },
                    { new Guid("2ce5db2b-57d8-4078-96bb-ec8f999b2b89"), "", "[]", new Guid("7042bd21-7239-4866-bcd3-a7a054c05430"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Qelline Alderleaf", "[]", "[]", "" },
                    { new Guid("328e57d4-fe0c-4603-b85f-a54c303b359f"), "", "[]", new Guid("5ca1de81-cf25-4c98-a251-1c3fe661457f"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Iarno Albrek", "[]", "[]", "" },
                    { new Guid("436c3a8a-3f57-4393-aad7-2531d1ab2233"), "", "[]", new Guid("0110289a-95c6-4385-be5d-741821c8a107"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Daran Edermath", "[]", "[]", "" },
                    { new Guid("60d13f9d-a971-4d4c-aef9-88101fac543f"), "", "[]", new Guid("b3c67d0b-ba6c-4974-b393-5c7d3f1d6644"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Elmar Barthen", "[]", "[]", "" },
                    { new Guid("a54f8ba3-3dfe-47dd-912f-e76f773ab133"), "", "[]", new Guid("b439fe6f-dde1-4854-8ea6-a5972a6ea06e"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("fe3133a3-b86a-4f53-833c-df0bb75dc2a2"), "Linene Graywind", "[]", "[]", "" },
                    { new Guid("b3aa1448-07e6-401b-87ca-a94bdda81f68"), "", "[]", new Guid("4c3bf7ce-dfd6-4894-afa7-f86137003e87"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Sister Garaele", "[]", "[]", "" },
                    { new Guid("b50fcd71-3fe3-4387-bd2a-8045ec5c3fc9"), "", "[]", new Guid("3829d18f-0c01-4c08-a16f-55d983db578a"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("fe3133a3-b86a-4f53-833c-df0bb75dc2a2"), "Sildar Hallwinter", "[]", "[]", "" }
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
