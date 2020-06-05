using Microsoft.EntityFrameworkCore.Migrations;

namespace DDCatalogue.Migrations
{
    public partial class AddedBugbearimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 2,
                column: "Picture",
                value: "bugbear.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 2,
                column: "Picture",
                value: null);
        }
    }
}
