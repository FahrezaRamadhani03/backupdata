using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixAddSeederExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BudgetTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "TypeName", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("d45cb8d2-435e-4661-89d5-1daa96531001"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Property", null, null });

            migrationBuilder.InsertData(
                table: "BudgetActivities",
                columns: new[] { "Id", "BudgetTypeId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("d45cb8d2-435e-4661-89d5-9daa96531001"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531001"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Membeli Scanner barcode", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531001"));

            migrationBuilder.DeleteData(
                table: "BudgetTypes",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-1daa96531001"));
        }
    }
}
