using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class fixTypoColumnNameProjectDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DevelopmentMothod",
                table: "Projects",
                newName: "DevelopmentMethod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "DevelopmentMethod",
                table: "Projects",
                newName: "DevelopmentMothod");
        }
    }
}
