using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedDefaultValuestoCreature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Wisdom",
                table: "Creature",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Strength",
                table: "Creature",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Intelligence",
                table: "Creature",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Dexterity",
                table: "Creature",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Constitution",
                table: "Creature",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Charisma",
                table: "Creature",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { "", "", "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 2,
                column: "Reactions",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { "", "", "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { "", "", "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { "", "", "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { "", "", "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { "", "", "[]", "[]" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Wisdom",
                table: "Creature",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Strength",
                table: "Creature",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Intelligence",
                table: "Creature",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Dexterity",
                table: "Creature",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Constitution",
                table: "Creature",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Charisma",
                table: "Creature",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 2,
                column: "Reactions",
                value: null);

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HitDice", "Picture", "Proficiencies", "Reactions" },
                values: new object[] { null, null, null, null });
        }
    }
}
