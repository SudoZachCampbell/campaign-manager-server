using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedMoreDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Actions", "LegendaryActions", "SpecialAbilities", "Type" },
                values: new object[] { "[]", "[]", "[]", 14 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 2,
                column: "LegendaryActions",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { "[]", "[]", "{}", "[]", 14 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { "[]", "[]", "{}", "[]", 14 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { "[]", "[]", "{}", "[]", 14 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { "[]", "[]", "{}", "[]", 14 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { "[]", "[]", "{}", "[]", 14 });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Beliefs", "Flaws", "Passions" },
                values: new object[] { "[]", "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Beliefs", "Flaws", "Passions" },
                values: new object[] { "[]", "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { "[]", "[]", "[]", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Actions", "LegendaryActions", "SpecialAbilities", "Type" },
                values: new object[] { null, null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 2,
                column: "LegendaryActions",
                value: null);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { null, null, null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { null, null, null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { null, null, null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { null, null, null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Actions", "LegendaryActions", "Senses", "SpecialAbilities", "Type" },
                values: new object[] { null, null, null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Beliefs", "Flaws", "Passions" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Beliefs", "Flaws", "Passions" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Beliefs", "Flaws", "Passions", "Picture" },
                values: new object[] { null, null, null, null });
        }
    }
}
