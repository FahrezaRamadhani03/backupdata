using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class SeedHoliday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Date", "DeletedBy", "DeletedDate", "Description", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("03b7613b-3a26-4810-b6e9-59d2591115c1"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tahun Baru Masehi", null, null },
                    { new Guid("03b7613b-3a26-4810-b6e9-59d2591115c2"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Hari Raya Nyepi", null, null },
                    { new Guid("03b7613b-3a26-4810-b6e9-59d2591115c3"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Hari Buruh Internasional", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: new Guid("03b7613b-3a26-4810-b6e9-59d2591115c1"));

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: new Guid("03b7613b-3a26-4810-b6e9-59d2591115c2"));

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: new Guid("03b7613b-3a26-4810-b6e9-59d2591115c3"));
        }
    }
}
