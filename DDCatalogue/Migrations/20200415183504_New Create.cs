using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class NewCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterBase",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
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
                    Discriminator = table.Column<string>(nullable: false),
                    Player = table.Column<bool>(nullable: true),
                    PlayerName = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: true),
                    Background = table.Column<string>(nullable: true),
                    Faction = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Xp = table.Column<int>(nullable: true),
                    Inspiration = table.Column<bool>(nullable: true),
                    Senses = table.Column<string>(nullable: true),
                    Challenge = table.Column<double>(nullable: true),
                    DefeatXp = table.Column<int>(nullable: true),
                    Actions = table.Column<string>(nullable: true),
                    LegendaryActions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterBase", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    ContinentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.ContinentId);
                });

            migrationBuilder.CreateTable(
                name: "Dungeons",
                columns: table => new
                {
                    DungeonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dungeons", x => x.DungeonId);
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
                name: "Npcs",
                columns: table => new
                {
                    NpcId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npcs", x => x.NpcId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContinentId = table.Column<int>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "ContinentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    MunicipalityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.MunicipalityId);
                    table.ForeignKey(
                        name: "FK_Municipalities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityId = table.Column<int>(nullable: true),
                    Map = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_MunicipalityId",
                table: "Buildings",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentId",
                table: "Countries",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_CountryId",
                table: "Municipalities",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "CharacterBase");

            migrationBuilder.DropTable(
                name: "Dungeons");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Npcs");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
