using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class CampaignPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                table: "pcs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_pcs_CampaignId",
                table: "pcs",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_pcs_campaigns_CampaignId",
                table: "pcs",
                column: "CampaignId",
                principalTable: "campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pcs_campaigns_CampaignId",
                table: "pcs");

            migrationBuilder.DropIndex(
                name: "IX_pcs_CampaignId",
                table: "pcs");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "pcs");
        }
    }
}
