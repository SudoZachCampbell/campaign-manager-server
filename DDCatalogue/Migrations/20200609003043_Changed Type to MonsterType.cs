using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class ChangedTypetoMonsterType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Creature");

            migrationBuilder.AddColumn<int>(
                name: "MonsterType",
                table: "Creature",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 1,
                column: "MonsterType",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 2,
                column: "MonsterType",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 3,
                column: "MonsterType",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 4,
                column: "MonsterType",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 5,
                column: "MonsterType",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 6,
                column: "MonsterType",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 7,
                column: "MonsterType",
                value: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonsterType",
                table: "Creature");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Creature",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: 14);
        }
    }
}
