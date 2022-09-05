using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class AddMasterDataAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d45cb8d2-435e-4661-89d5-4daa96531001"), "BDG", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Bandung", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-4daa96531002"), "JKT", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Jakarta", null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d45cb8d2-435e-4661-89d5-5daa96531001"), "ID", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Indonesia", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-5daa96531002"), "SG", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Singapura", null, null }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d45cb8d2-435e-4661-89d5-7daa96531001"), "SK", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sukajadi", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-7daa96531002"), "GG", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Gegerkalong", null, null }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d45cb8d2-435e-4661-89d5-6daa96531001"), "JB", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Jawa Barat", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-6daa96531002"), "JT", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Jawa Timur", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");

            migrationBuilder.UpdateData(
                table: "DevelopmentRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"),
                column: "Level",
                value: "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"");
        }
    }
}
