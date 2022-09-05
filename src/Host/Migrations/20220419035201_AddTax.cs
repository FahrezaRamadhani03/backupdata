using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class AddTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "Rate", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2a69de34-7b4a-4c92-8644-bd78182bb9c7"), "T", null, new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PPN", 10f, null, null },
                    { new Guid("c0327584-6c87-4db2-9c8f-a0aeba523180"), "P", null, new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PPh 23", 2f, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_Code",
                table: "Taxes",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxes");
        }
    }
}
