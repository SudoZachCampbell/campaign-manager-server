using System;
using CampaignManager.Data.Model.Creatures;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class NpcUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beliefs",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Flaws",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "NoteableEvents",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Passions",
                table: "npcs");

            migrationBuilder.RenameColumn(
                name: "Background",
                table: "npcs",
                newName: "Epithet");

            migrationBuilder.AddColumn<NpcAttributes>(
                name: "Attributes",
                table: "npcs",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<NpcLore>(
                name: "Lore",
                table: "npcs",
                type: "jsonb",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "npc_npc",
                columns: table => new
                {
                    FromId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_npc_npc", x => new { x.FromId, x.ToId });
                    table.ForeignKey(
                        name: "FK_npc_npc_npcs_FromId",
                        column: x => x.FromId,
                        principalTable: "npcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_npc_npc_npcs_ToId",
                        column: x => x.ToId,
                        principalTable: "npcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "npc_pc",
                columns: table => new
                {
                    NpcId = table.Column<Guid>(type: "uuid", nullable: false),
                    PcId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_npc_pc", x => new { x.NpcId, x.PcId });
                    table.ForeignKey(
                        name: "FK_npc_pc_npcs_NpcId",
                        column: x => x.NpcId,
                        principalTable: "npcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_npc_pc_pcs_PcId",
                        column: x => x.PcId,
                        principalTable: "pcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_npc_npc_ToId",
                table: "npc_npc",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_npc_pc_PcId",
                table: "npc_pc",
                column: "PcId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "npc_npc");

            migrationBuilder.DropTable(
                name: "npc_pc");

            migrationBuilder.DropColumn(
                name: "Attributes",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Lore",
                table: "npcs");

            migrationBuilder.RenameColumn(
                name: "Epithet",
                table: "npcs",
                newName: "Background");

            migrationBuilder.AddColumn<string>(
                name: "Beliefs",
                table: "npcs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flaws",
                table: "npcs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoteableEvents",
                table: "npcs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Passions",
                table: "npcs",
                type: "text",
                nullable: true);
        }
    }
}
