using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedNPCImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Map",
                table: "Regions",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Npcs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Map",
                table: "Locales",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Map",
                table: "Buildings",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 10,
                column: "Map",
                value: "Tresendar_Manor.png");

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 10,
                column: "Picture",
                value: "Toblen_Stonehill.jpg");

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "ContinentId", "Map", "Name" },
                values: new object[] { 1, null, "Sword_Coast_North.png", "Sword Coast North" });

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Map", "RegionId" },
                values: new object[] { "Phandalin.png", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Npcs");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Map",
                table: "Regions",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Map",
                table: "Locales",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Map",
                table: "Buildings",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 10,
                column: "Map",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locales",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Map", "RegionId" },
                values: new object[] { null, null });
        }
    }
}
