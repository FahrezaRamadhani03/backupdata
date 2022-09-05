using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixTableDevelopmentRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DevelopmentRole_Code",
                table: "DevelopmentRole");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DevelopmentRole",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DevelopmentRole",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentRole_Code",
                table: "DevelopmentRole",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DevelopmentRole_Code",
                table: "DevelopmentRole");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DevelopmentRole",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DevelopmentRole",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentRole_Code",
                table: "DevelopmentRole",
                column: "Code",
                unique: true);
        }
    }
}
