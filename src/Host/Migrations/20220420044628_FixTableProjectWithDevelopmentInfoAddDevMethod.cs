using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixTableProjectWithDevelopmentInfoAddDevMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DevelopmentMothod",
                table: "Projects",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevelopmentMothod",
                table: "Projects");
        }
    }
}
