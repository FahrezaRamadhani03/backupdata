using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixDevelopmentRoleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531003"),
                column: "Name",
                value: "Technical Leader");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Frontend Developer" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Backend Developer" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Mobile Developer" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Business Analyst" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "System Analyst" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Quality Assurance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531003"),
                column: "Name",
                value: "Technical leader");

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Frontend developer" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Backend developer" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Mobile developer" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Business analyst" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "System analyst" });

            migrationBuilder.UpdateData(
                table: "DevelopmentRole",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"),
                columns: new[] { "Level", "Name" },
                values: new object[] { "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Quality assurance" });
        }
    }
}
