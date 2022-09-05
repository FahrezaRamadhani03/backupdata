using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FeatTableProjectWithDevelopmentInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DevelopmentEnd",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DevelopmentStart",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "KickoffDate",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MaintenanceEnd",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceLength",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaintenanceStart",
                table: "Projects",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MaintenanceUnit",
                table: "Projects",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevelopmentEnd",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DevelopmentStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "KickoffDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MaintenanceEnd",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MaintenanceLength",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MaintenanceStart",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MaintenanceUnit",
                table: "Projects");
        }
    }
}
