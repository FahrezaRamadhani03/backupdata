using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixBudgetDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BudgetTypeId",
                table: "BudgetDetails",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetails_BudgetTypeId",
                table: "BudgetDetails",
                column: "BudgetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetDetails_BudgetTypes_BudgetTypeId",
                table: "BudgetDetails",
                column: "BudgetTypeId",
                principalTable: "BudgetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetDetails_BudgetTypes_BudgetTypeId",
                table: "BudgetDetails");

            migrationBuilder.DropIndex(
                name: "IX_BudgetDetails_BudgetTypeId",
                table: "BudgetDetails");

            migrationBuilder.DropColumn(
                name: "BudgetTypeId",
                table: "BudgetDetails");
        }
    }
}
