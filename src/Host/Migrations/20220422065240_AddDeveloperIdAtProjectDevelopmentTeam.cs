using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class AddDeveloperIdAtProjectDevelopmentTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeveloperId",
                table: "ProjectDevelopmentTeams",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDevelopmentTeams_DeveloperId",
                table: "ProjectDevelopmentTeams",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDevelopmentTeams_Developers_DeveloperId",
                table: "ProjectDevelopmentTeams",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDevelopmentTeams_Developers_DeveloperId",
                table: "ProjectDevelopmentTeams");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDevelopmentTeams_DeveloperId",
                table: "ProjectDevelopmentTeams");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "ProjectDevelopmentTeams");
        }
    }
}
