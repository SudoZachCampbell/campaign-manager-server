using System;
using System.Collections.Generic;
using DDCatalogue.Model.Properties;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DDCatalogue.Migrations
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
                    Actions = table.Column<List<CreatureAction>>(type: "jsonb", nullable: true),
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
                    { new Guid("0cc31a48-dfa1-403c-ac9a-1c39bd533dfb"), null, 0, 16, 1.0, 10, 14, 11, "Monster", "", 39, 10, "Common, Dwarvish", "[]", 14, "Drawf Warrior", 10, "", "[]", "[]", "{\"darkvision\":\"60 ft.\"}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":25,\"Measurement\":\"ft\"}]", 14, 11, 0 },
                    { new Guid("2dc5b20f-6d65-4c4d-8928-597d3e8291fa"), null, 0, 14, 0.5, 10, 12, 10, "Monster", "", 26, 10, "Common, Dwarvish", "[]", 14, "Dwarf", 10, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":25,\"Measurement\":\"ft\"}]", 13, 12, 0 },
                    { new Guid("a17bd70f-a811-4a63-bd43-17f77f696e86"), null, 5, 15, 0.25, 8, 10, 14, "Monster", "", 7, 10, "Common, Goblin", "[]", 14, "Goblin", 9, "", "[]", "[]", "{}", "Small", "[]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 8, 8, 0 },
                    { new Guid("ab4d8995-b5d1-4e07-aad8-249faee6d16d"), null, 10, 13, 0.25, 6, 12, 15, "Monster", "", 11, 3, "", "[]", 14, "Wolf", 13, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":40,\"Measurement\":\"ft\"}]", 12, 12, 0 },
                    { new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), null, 9, 10, 0.0, 10, 10, 10, "Monster", "", 4, 10, "Any one", "[]", 14, "Commoner", 10, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 10, 10, 0 },
                    { new Guid("dbfb7da7-08b2-4b12-adf4-2f8fe7c15c34"), null, 8, 16, 1.0, 9, 13, 14, "Monster", "5d8", 27, 8, "Common, Goblin", "[]", 14, "Bugbear", 10, "bugbear.jpeg", "[{\"name\":\"Skill: Stealth\",\"value\":6},{\"name\":\"Skill: Survival\",\"value\":2}]", "[]", "{\"darkvision\":\"60 ft.\"}", "Medium", "[{\"name\":\"Brute\",\"desc\":\"A melee weapon deals one extra die of its damage when the bugbear hits with it (included in the attack).\"},{\"name\":\"Surprise Attack\",\"desc\":\"If the bugbear surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 7 (2d6) damage from the attack.\"}]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 15, 11, 200 },
                    { new Guid("fe3133a3-b86a-4f53-833c-df0bb75dc2a2"), null, 9, 18, 3.0, 15, 14, 11, "Monster", "", 52, 11, "Any one", "[]", 14, "Knight", 10, "", "[]", "[]", "{}", "Medium", "[]", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 16, 11, 0 }
                });

            migrationBuilder.InsertData(
                table: "Dungeons",
                columns: new[] { "Id", "BuildingId", "LocaleId", "Map", "Name", "Type" },
                values: new object[] { new Guid("7f005891-d2fb-4207-9df9-bb5de4a59bd5"), null, null, null, "Cragmaw Hideout", null });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "ContinentId", "Map", "Name" },
                values: new object[] { new Guid("050b1c46-0676-420b-872c-143db80d358b"), new Guid("9504646c-77c0-4f92-aec1-2fadf62cd2b7"), "Sword_Coast_North.png", "Sword Coast North" });

            migrationBuilder.InsertData(
                table: "Locales",
                columns: new[] { "Id", "Name", "RegionId" },
                values: new object[,]
                {
                    { new Guid("05a500d0-ab28-47dd-8a70-af9befc98589"), "Neverwinter", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("3087d4c8-1435-4f90-9a55-b532847190f2"), "Leilon", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("76b7fe93-49cb-45cc-bb11-042999aa0216"), "Conyberry", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("8cc5872e-b07b-4134-ae92-a60773901584"), "Thundertree", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), "Phandalin", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("9b2ff871-d933-4811-acfa-764f8173df3c"), "Cragmaw Castle", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("a5d3885b-7b2a-466d-88ba-921f1d71f1b4"), "Cragmaw Hideout", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("c32bcb3c-12db-4b9d-8660-abc61ea9f4b6"), "Old Owl Well", new Guid("050b1c46-0676-420b-872c-143db80d358b") },
                    { new Guid("e6128841-36f5-4acb-8448-a37fbd1806c8"), "Neverwinter", new Guid("050b1c46-0676-420b-872c-143db80d358b") }
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
                    { new Guid("4fd05e80-0d1f-4497-9886-61d1137c3272"), null, "PhanNight.jpg", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), "Phandalin_Night", "Night" },
                    { new Guid("d6236d75-aa21-4569-bc13-7a8c913997d9"), null, "PhanDay.jpg", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), "Phandalin_Day", "Day" }
                });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "Id", "Background", "Beliefs", "BuildingId", "Flaws", "LocaleId", "MonsterId", "Name", "NoteableEvents", "Passions", "Picture" },
                values: new object[,]
                {
                    { new Guid("17286391-d384-4c99-a5d7-25b8b745841b"), "", "[]", null, "[]", new Guid("a5d3885b-7b2a-466d-88ba-921f1d71f1b4"), new Guid("a17bd70f-a811-4a63-bd43-17f77f696e86"), "Yeemik Largebrain", "[]", "[]", "" },
                    { new Guid("6a84b114-50eb-4a8e-8d9f-7af748fb4a7e"), "", "[]", null, "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("0cc31a48-dfa1-403c-ac9a-1c39bd533dfb"), "Tharden Rockseeker", "[]", "[]", "" },
                    { new Guid("b3d85d3d-e8b5-4348-9c09-fcf6beb4aa1b"), "", "[]", null, "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("0cc31a48-dfa1-403c-ac9a-1c39bd533dfb"), "Nundro Rockseeker", "[]", "[]", "" },
                    { new Guid("ce2d5a1c-3b0b-4f15-92bc-4e9580be1d95"), "Raised with his three brothers, Klarg was below average intelligence to say the least. Always playing Kings and Queens, he became obsessed with being the ruler of a country. He forged his own crown, and took over a goblin bandit gang declaring himself as their King.|Klarg has since made a deal with Iarno to steal supplies from Phandalin and to resupply the Redbrands instead.", "[]", null, "[]", new Guid("a5d3885b-7b2a-466d-88ba-921f1d71f1b4"), new Guid("dbfb7da7-08b2-4b12-adf4-2f8fe7c15c34"), "Klarg BigCrown", "[\"Made a deal with the party for Yeemik's head\",\"Killed by the party\"]", "[]", "Klarg_BigCrown.jpg" },
                    { new Guid("e5188e4c-6375-4d9e-8ae8-01e97f975bf0"), "", "[]", null, "[]", new Guid("9b2ff871-d933-4811-acfa-764f8173df3c"), new Guid("0cc31a48-dfa1-403c-ac9a-1c39bd533dfb"), "Gundren Rockseeker", "[]", "[]", "" }
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
                    { new Guid("2af8e063-a51c-4b35-b2aa-afe4c80bcfae"), "", "[]", new Guid("6f6bfd5e-a158-487a-b54a-9f27842ce762"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("2dc5b20f-6d65-4c4d-8928-597d3e8291fa"), "Toblen Stonehill", "[]", "[]", "Toblen_Stonehill.jpg" },
                    { new Guid("3ae33b0e-eff1-42d3-94eb-978151447d3a"), "", "[]", new Guid("b3c67d0b-ba6c-4974-b393-5c7d3f1d6644"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Elmar Barthen", "[]", "[]", "" },
                    { new Guid("47b3dc26-04c8-48e9-abc0-a0520feca227"), "", "[]", new Guid("e54fa7e6-34c0-4ed4-9338-9341162739e5"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Halia Thornton", "[]", "[]", "" },
                    { new Guid("62375d83-0351-4968-959d-8cd329d279fa"), "", "[]", new Guid("5ca1de81-cf25-4c98-a251-1c3fe661457f"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Iarno Albrek", "[]", "[]", "" },
                    { new Guid("701cf283-f930-42b1-a5df-de4ed109a693"), "", "[]", new Guid("4c3bf7ce-dfd6-4894-afa7-f86137003e87"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Sister Garaele", "[]", "[]", "" },
                    { new Guid("8ad35369-4c60-4bc0-a43a-ecd13fcc5094"), "", "[]", new Guid("b439fe6f-dde1-4854-8ea6-a5972a6ea06e"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("fe3133a3-b86a-4f53-833c-df0bb75dc2a2"), "Linene Graywind", "[]", "[]", "" },
                    { new Guid("99dc4563-34da-4558-a5c7-a39cf1bb296b"), "", "[]", new Guid("3829d18f-0c01-4c08-a16f-55d983db578a"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("fe3133a3-b86a-4f53-833c-df0bb75dc2a2"), "Sildar Hallwinter", "[]", "[]", "" },
                    { new Guid("b1d2b4b7-dab2-4d4b-b757-a47b62ac45e7"), "", "[]", new Guid("7042bd21-7239-4866-bcd3-a7a054c05430"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Qelline Alderleaf", "[]", "[]", "" },
                    { new Guid("d00283f9-c643-4ad6-8bff-bd18fb816300"), "", "[]", new Guid("3829d18f-0c01-4c08-a16f-55d983db578a"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Harbin Wester", "[]", "[]", "" },
                    { new Guid("d4368ed6-b706-45d1-9b70-93df51d3d285"), "", "[]", new Guid("0110289a-95c6-4385-be5d-741821c8a107"), "[]", new Guid("97e40163-3c5c-4f76-b3ce-e6e88ec936ed"), new Guid("daf11f58-fdc0-4ca7-a291-8b7f1d248070"), "Daran Edermath", "[]", "[]", "" }
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

        /// <inheritdoc />
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
