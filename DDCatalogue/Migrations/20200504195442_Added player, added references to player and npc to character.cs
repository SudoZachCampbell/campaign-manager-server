using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class Addedplayeraddedreferencestoplayerandnpctocharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NpcId",
                table: "CharacterBase",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "CharacterBase",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterBase_NpcId",
                table: "CharacterBase",
                column: "NpcId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterBase_PlayerId",
                table: "CharacterBase",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterBase_Npcs_NpcId",
                table: "CharacterBase",
                column: "NpcId",
                principalTable: "Npcs",
                principalColumn: "NpcId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterBase_Player_PlayerId",
                table: "CharacterBase",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterBase_Npcs_NpcId",
                table: "CharacterBase");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterBase_Player_PlayerId",
                table: "CharacterBase");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropIndex(
                name: "IX_CharacterBase_NpcId",
                table: "CharacterBase");

            migrationBuilder.DropIndex(
                name: "IX_CharacterBase_PlayerId",
                table: "CharacterBase");

            migrationBuilder.DropColumn(
                name: "NpcId",
                table: "CharacterBase");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "CharacterBase");
        }
    }
}
