using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class AddIsExtendDaysToDevelopmentScrumSprintTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExtendDays",
                table: "DevelopmentScrumSprint",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExtendDays",
                table: "DevelopmentScrumSprint");
        }
    }
}
