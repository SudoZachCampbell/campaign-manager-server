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
                    Map = table.Column<string>(nullable: true)
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
                    Map = table.Column<string>(nullable: true)
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
                    Map = table.Column<string>(nullable: true)
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
                    Strength = table.Column<int>(nullable: true),
                    Dexterity = table.Column<int>(nullable: true),
                    Constitution = table.Column<int>(nullable: true),
                    Intelligence = table.Column<int>(nullable: true),
                    Wisdom = table.Column<int>(nullable: true),
                    Charisma = table.Column<int>(nullable: true),
                    Proficiencies = table.Column<string>(nullable: true),
                    ArmorClass = table.Column<int>(nullable: false),
                    HitPoints = table.Column<int>(nullable: false),
                    HitDice = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    Alignment = table.Column<int>(nullable: false),
                    Reactions = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ChallengeRating = table.Column<double>(nullable: true),
                    PassivePerception = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Actions = table.Column<string>(nullable: true),
                    LegendaryActions = table.Column<string>(nullable: true),
                    SpecialAbilities = table.Column<string>(nullable: true),
                    Senses = table.Column<string>(nullable: true),
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
                    Picture = table.Column<string>(nullable: true),
                    Background = table.Column<string>(nullable: true),
                    NoteableEvents = table.Column<string>(nullable: true),
                    Beliefs = table.Column<string>(nullable: true),
                    Passions = table.Column<string>(nullable: true),
                    Flaws = table.Column<string>(nullable: true),
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
                columns: new[] { "Id", "Alignment", "ArmorClass", "Charisma", "Constitution", "Dexterity", "Discriminator", "HitDice", "HitPoints", "Intelligence", "Languages", "Name", "Picture", "Proficiencies", "Reactions", "Size", "Speed", "Strength", "Wisdom", "Actions", "ChallengeRating", "LegendaryActions", "PassivePerception", "Senses", "SpecialAbilities", "Type" },
                values: new object[,]
                {
                    { 1, 0, 16, 10, 14, 11, "Monster", null, 39, 10, "Common, Dwarvish", "Drawf Warrior", null, null, null, "Medium", "[{\"Name\":\"walk\",\"Value\":25,\"Measurement\":\"ft\"}]", 14, 11, null, 1.0, null, 10, "{\"darkvision\":\"60 ft.\"}", null, 0 },
                    { 2, 8, 16, 9, 13, 14, "Monster", "5d8", 27, 8, "Common, Goblin", "Bugbear", "bugbear.jpeg", "[{\"name\":\"Skill: Stealth\",\"value\":6},{\"name\":\"Skill: Survival\",\"value\":2}]", null, "Medium", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 15, 11, "[{\"name\":\"Morningstar\",\"desc\":\"Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit: 11 (2d8 + 2) piercing damage.\",\"attack_bonus\":4,\"damage\":[{\"damage_type\":{\"name\":\"Piercing\"},\"damage_dice\":\"2d8\",\"damage_bonus\":2}]},{\"name\":\"Javelin\",\"desc\":\"Melee or Ranged Weapon Attack: +4 to hit, reach 5 ft. or range 30/120 ft., one target. Hit: 9 (2d6 + 2) piercing damage in melee or 5 (1d6 + 2) piercing damage at range.\",\"attack_bonus\":4,\"damage\":[{\"damage_type\":{\"name\":\"Piercing\"},\"damage_dice\":\"2d6\",\"damage_bonus\":2}]}]", 1.0, null, 10, "{\"darkvision\":\"60 ft.\"}", "[{\"name\":\"Brute\",\"desc\":\"A melee weapon deals one extra die of its damage when the bugbear hits with it (included in the attack).\"},{\"name\":\"Surprise Attack\",\"desc\":\"If the bugbear surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 7 (2d6) damage from the attack.\"}]", 9 },
                    { 3, 9, 18, 15, 14, 11, "Monster", null, 52, 11, "Any one", "Knight", null, null, null, "Medium", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 16, 11, null, 3.0, null, 10, null, null, 0 },
                    { 4, 5, 15, 8, 10, 14, "Monster", null, 7, 10, "Common, Goblin", "Goblin", null, null, null, "Small", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 8, 8, null, 0.25, null, 9, null, null, 0 },
                    { 5, 9, 10, 10, 10, 10, "Monster", null, 4, 10, "Any one", "Commoner", null, null, null, "Medium", "[{\"Name\":\"walk\",\"Value\":30,\"Measurement\":\"ft\"}]", 10, 10, null, 0.0, null, 10, null, null, 0 },
                    { 6, 10, 13, 6, 12, 15, "Monster", null, 11, 3, "", "Wolf", null, null, null, "Medium", "[{\"Name\":\"walk\",\"Value\":40,\"Measurement\":\"ft\"}]", 12, 12, null, 0.25, null, 13, null, null, 0 },
                    { 7, 0, 14, 10, 12, 10, "Monster", null, 26, 10, "Common, Dwarvish", "Dwarf", null, null, null, "Medium", "[{\"Name\":\"walk\",\"Value\":25,\"Measurement\":\"ft\"}]", 13, 12, null, 0.5, null, 10, null, null, 0 }
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
                    { 8, null, "Neverwinter", null },
                    { 7, null, "Leilon", null },
                    { 5, null, "Old Owl Well", null },
                    { 1, null, "Neverwinter", null },
                    { 3, null, "Cragmaw Castle", null },
                    { 2, null, "Thundertree", null },
                    { 9, null, "Cragmaw Hideout", null },
                    { 4, null, "Conyberry", null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "ContinentId", "Map", "Name" },
                values: new object[] { 1, null, "Sword_Coast_North.png", "Sword Coast North" });

            migrationBuilder.InsertData(
                table: "Locales",
                columns: new[] { "Id", "Map", "Name", "RegionId" },
                values: new object[] { 6, "Phandalin.png", "Phandalin", 1 });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "Id", "Background", "Beliefs", "BuildingId", "Flaws", "LocaleId", "MonsterId", "Name", "NoteableEvents", "Passions", "Picture" },
                values: new object[,]
                {
                    { 2, null, null, null, null, 3, 1, "Gundren Rockseeker", null, null, null },
                    { 1, "Raised with his three brothers, Klarg was below average intelligence to say the least. Always playing Kings and Queens, he became obsessed with being the ruler of a country. He forged his own crown, and took over a goblin bandit gang declaring himself as their King.|Klarg has since made a deal with Iarno to steal supplies from Phandalin and to resupply the Redbrands instead.", null, null, null, 9, 2, "Klarg BigCrown", "[\"Made a deal with the party for Yeemik's head\",\"Killed by the party\"]", null, "Klarg_BigCrown.jpg" },
                    { 6, null, null, null, null, 9, 4, "Yeemik Largebrain", null, null, null }
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
                table: "Npcs",
                columns: new[] { "Id", "Background", "Beliefs", "BuildingId", "Flaws", "LocaleId", "MonsterId", "Name", "NoteableEvents", "Passions", "Picture" },
                values: new object[,]
                {
                    { 8, null, null, null, null, 6, 1, "Tharden Rockseeker", null, null, null },
                    { 9, null, null, null, null, 6, 1, "Nundro Rockseeker", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Npcs",
                columns: new[] { "Id", "Background", "Beliefs", "BuildingId", "Flaws", "LocaleId", "MonsterId", "Name", "NoteableEvents", "Passions", "Picture" },
                values: new object[,]
                {
                    { 10, null, null, 1, null, 6, 7, "Toblen Stonehill", null, null, "Toblen_Stonehill.jpg" },
                    { 4, null, null, 2, null, 6, 5, "Elmar Barthen", null, null, null },
                    { 11, null, null, 3, null, 6, 5, "Daran Edermath", null, null, null },
                    { 5, null, null, 4, null, 6, 3, "Linene Graywind", null, null, null },
                    { 12, null, null, 5, null, 6, 5, "Halia Thornton", null, null, null },
                    { 13, null, null, 6, null, 6, 5, "Qelline Alderleaf", null, null, null },
                    { 14, null, null, 7, null, 6, 5, "Sister Garaele", null, null, null },
                    { 3, null, null, 9, null, 6, 3, "Sildar Hallwinter", null, null, null },
                    { 15, null, null, 9, null, 6, 5, "Harbin Wester", null, null, null },
                    { 7, null, null, 10, null, 6, null, "Iarno Albrek", null, null, null }
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
