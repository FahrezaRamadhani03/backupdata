using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixPODeveloperScrumTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectScrumTeams_Developers_PoDeveloperId",
                table: "ProjectScrumTeams");

            migrationBuilder.DropColumn(
                name: "PoDeveloperId",
                table: "ProjectScrumTeams");

            migrationBuilder.AddColumn<string>(
                name: "PoDeveloper",
                table: "ProjectScrumTeams",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PoDeveloper",
                table: "ProjectScrumTeams");

            migrationBuilder.AddColumn<Guid>(
                name: "PoDeveloperId",
                table: "ProjectScrumTeams",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectScrumTeams_Developers_PoDeveloperId",
                table: "ProjectScrumTeams",
                column: "PoDeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
