using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class ChangedMonsterValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ac",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "Hp",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "Pp",
                table: "Creature");

            migrationBuilder.AddColumn<int>(
                name: "ArmorClass",
                table: "Creature",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HitPoints",
                table: "Creature",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassivePerception",
                table: "Creature",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmorClass",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "HitPoints",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "PassivePerception",
                table: "Creature");

            migrationBuilder.AddColumn<int>(
                name: "Ac",
                table: "Creature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hp",
                table: "Creature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pp",
                table: "Creature",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ac", "Hp", "Pp" },
                values: new object[] { 16, 39, 10 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Ac", "Hp", "Pp" },
                values: new object[] { 16, 27, 10 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ac", "Hp", "Pp" },
                values: new object[] { 18, 52, 10 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ac", "Hp", "Pp" },
                values: new object[] { 15, 7, 9 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Ac", "Hp", "Pp" },
                values: new object[] { 10, 4, 10 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Ac", "Hp", "Pp" },
                values: new object[] { 13, 11, 13 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Ac", "Hp", "Pp" },
                values: new object[] { 14, 26, 10 });
        }
    }
}
