using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class MadeNPCFieldsJArrays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Background", "Name", "NoteableEvents", "Picture" },
                values: new object[] { "Raised with his three brothers, Klarg was below average intelligence to say the least. Always playing Kings and Queens, he became obsessed with being the ruler of a country. He forged his own crown, and took over a goblin bandit gang declaring himself as their King.|Klarg has since made a deal with Iarno to steal supplies from Phandalin and to resupply the Redbrands instead.", "Klarg BigCrown", "[\"Made a deal with the party for Yeemik's head\",\"Killed by the party\"]", "Klarg_BigCrown.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Npcs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Background", "Name", "NoteableEvents", "Picture" },
                values: new object[] { null, "Klarg Big-Crown", null, null });
        }
    }
}
