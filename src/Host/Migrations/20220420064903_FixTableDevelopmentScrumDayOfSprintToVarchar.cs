using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixTableDevelopmentScrumDayOfSprintToVarchar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DaysInSprint",
                table: "DevelopmentScrum",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "DevelopmentScrumSprintId",
                table: "DevelopmentHoliday",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentHoliday_DevelopmentScrumSprintId",
                table: "DevelopmentHoliday",
                column: "DevelopmentScrumSprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopmentHoliday_DevelopmentScrumSprint_DevelopmentScrumS~",
                table: "DevelopmentHoliday",
                column: "DevelopmentScrumSprintId",
                principalTable: "DevelopmentScrumSprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentHoliday_DevelopmentScrumSprint_DevelopmentScrumS~",
                table: "DevelopmentHoliday");

            migrationBuilder.DropIndex(
                name: "IX_DevelopmentHoliday_DevelopmentScrumSprintId",
                table: "DevelopmentHoliday");

            migrationBuilder.DropColumn(
                name: "DevelopmentScrumSprintId",
                table: "DevelopmentHoliday");

            migrationBuilder.AlterColumn<int>(
                name: "DaysInSprint",
                table: "DevelopmentScrum",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
