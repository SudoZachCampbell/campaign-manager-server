using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedNPCFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Npcs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Beliefs",
                table: "Npcs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flaws",
                table: "Npcs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteableEvents",
                table: "Npcs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Passions",
                table: "Npcs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "Beliefs",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "Flaws",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "NoteableEvents",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "Passions",
                table: "Npcs");
        }
    }
}
