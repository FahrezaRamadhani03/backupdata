using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class UnUniqKeyValueForNameOnBudgetActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BudgetActivities_Name",
                table: "BudgetActivities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BudgetActivities_Name",
                table: "BudgetActivities",
                column: "Name",
                unique: true);
        }
    }
}
