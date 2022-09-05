using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class AddProjectDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Key = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    InitState = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Technology = table.Column<string>(type: "text", nullable: true),
                    PICName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PICPhone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PICEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

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
        }
    }
}
