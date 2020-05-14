using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class Changeseedtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocaleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 4,
                column: "LocaleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 5,
                column: "LocaleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 7,
                column: "LocaleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 10,
                column: "LocaleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 11,
                column: "LocaleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 12,
                column: "LocaleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 13,
                column: "LocaleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 14,
                column: "LocaleId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 15,
                column: "LocaleId",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocaleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 4,
                column: "LocaleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 5,
                column: "LocaleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 7,
                column: "LocaleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 10,
                column: "LocaleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 11,
                column: "LocaleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 12,
                column: "LocaleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 13,
                column: "LocaleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 14,
                column: "LocaleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 15,
                column: "LocaleId",
                value: null);
        }
    }
}
