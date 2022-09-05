using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixTemplateReportFooter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BodyDetail",
                table: "TemplateReports",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Footer",
                table: "TemplateReports",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyDetail",
                table: "TemplateReports");

            migrationBuilder.DropColumn(
                name: "Footer",
                table: "TemplateReports");
        }
    }
}
