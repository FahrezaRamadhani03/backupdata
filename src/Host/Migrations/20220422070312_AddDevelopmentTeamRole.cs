using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class AddDevelopmentTeamRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevelopmentTeamRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DevelopmentTeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    LevelId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentTeamRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevelopmentTeamRoles_DevelopmentRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "DevelopmentRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevelopmentTeamRoles_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevelopmentTeamRoles_ProjectDevelopmentTeams_DevelopmentTea~",
                        column: x => x.DevelopmentTeamId,
                        principalTable: "ProjectDevelopmentTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTeamRoles_DevelopmentTeamId",
                table: "DevelopmentTeamRoles",
                column: "DevelopmentTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTeamRoles_LevelId",
                table: "DevelopmentTeamRoles",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTeamRoles_RoleId",
                table: "DevelopmentTeamRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevelopmentTeamRoles");
        }
    }
}
