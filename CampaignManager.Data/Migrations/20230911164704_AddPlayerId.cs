using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "pcs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pcs_PlayerId",
                table: "pcs",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_pcs_accounts_PlayerId",
                table: "pcs",
                column: "PlayerId",
                principalTable: "accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pcs_accounts_PlayerId",
                table: "pcs");

            migrationBuilder.DropIndex(
                name: "IX_pcs_PlayerId",
                table: "pcs");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "pcs");
        }
    }
}
