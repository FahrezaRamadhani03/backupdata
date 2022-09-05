using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixTableProjectResources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectResources_Projects_Id",
                table: "ProjectResources");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "ProjectResources",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResources_ProjectId",
                table: "ProjectResources",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectResources_Projects_ProjectId",
                table: "ProjectResources",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectResources_Projects_ProjectId",
                table: "ProjectResources");

            migrationBuilder.DropIndex(
                name: "IX_ProjectResources_ProjectId",
                table: "ProjectResources");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectResources");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectResources_Projects_Id",
                table: "ProjectResources",
                column: "Id",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
