using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class AddDeveloperRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentTeamRoles_DevelopmentRoles_RoleId",
                table: "DevelopmentTeamRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentTeamRoles_Levels_LevelId",
                table: "DevelopmentTeamRoles");

            migrationBuilder.DropIndex(
                name: "IX_DevelopmentTeamRoles_LevelId",
                table: "DevelopmentTeamRoles");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "DevelopmentTeamRoles");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "DevelopmentTeamRoles",
                newName: "DeveloperRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_DevelopmentTeamRoles_RoleId",
                table: "DevelopmentTeamRoles",
                newName: "IX_DevelopmentTeamRoles_DeveloperRoleId");

            migrationBuilder.CreateTable(
                name: "DeveloperRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_DeveloperRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeveloperRoles_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperRoles_DevelopmentRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "DevelopmentRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperRoles_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperRoles_DeveloperId",
                table: "DeveloperRoles",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperRoles_LevelId",
                table: "DeveloperRoles",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperRoles_RoleId",
                table: "DeveloperRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopmentTeamRoles_DeveloperRoles_DeveloperRoleId",
                table: "DevelopmentTeamRoles",
                column: "DeveloperRoleId",
                principalTable: "DeveloperRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentTeamRoles_DeveloperRoles_DeveloperRoleId",
                table: "DevelopmentTeamRoles");

            migrationBuilder.DropTable(
                name: "DeveloperRoles");

            migrationBuilder.RenameColumn(
                name: "DeveloperRoleId",
                table: "DevelopmentTeamRoles",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_DevelopmentTeamRoles_DeveloperRoleId",
                table: "DevelopmentTeamRoles",
                newName: "IX_DevelopmentTeamRoles_RoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "LevelId",
                table: "DevelopmentTeamRoles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentTeamRoles_LevelId",
                table: "DevelopmentTeamRoles",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopmentTeamRoles_DevelopmentRoles_RoleId",
                table: "DevelopmentTeamRoles",
                column: "RoleId",
                principalTable: "DevelopmentRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopmentTeamRoles_Levels_LevelId",
                table: "DevelopmentTeamRoles",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
