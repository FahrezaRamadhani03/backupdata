using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class DropTableBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

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
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "Price", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("d45cb8d2-435e-4661-89d5-3daa96531712"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Larman", "120000", null, null });

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
