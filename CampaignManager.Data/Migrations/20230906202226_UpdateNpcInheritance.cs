using System.Collections.Generic;
using CampaignManager.Data.Model.Attributes;
using CampaignManager.Data.Model.Operations;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNpcInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "ArmorClass",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Charisma",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Constitution",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Dexterity",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "HitDice",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "HitPoints",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Intelligence",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Proficiencies",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Reactions",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "npcs");

            migrationBuilder.DropColumn(
                name: "Wisdom",
                table: "npcs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Alignment",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArmorClass",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Charisma",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Constitution",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dexterity",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HitDice",
                table: "npcs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HitPoints",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Intelligence",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "npcs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<Proficiencies>>(
                name: "Proficiencies",
                table: "npcs",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<List<CreatureAction>>(
                name: "Reactions",
                table: "npcs",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<List<Speed>>(
                name: "Speed",
                table: "npcs",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wisdom",
                table: "npcs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
