using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class NewConstructors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inspiration",
                table: "CharacterBase");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "CharacterBase");

            migrationBuilder.DropColumn(
                name: "Player",
                table: "CharacterBase");

            migrationBuilder.DropColumn(
                name: "Xp",
                table: "CharacterBase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Inspiration",
                table: "CharacterBase",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "CharacterBase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Player",
                table: "CharacterBase",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Xp",
                table: "CharacterBase",
                type: "int",
                nullable: true);
        }
    }
}
