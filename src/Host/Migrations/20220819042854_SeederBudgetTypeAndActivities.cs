using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class SeederBudgetTypeAndActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BudgetTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "TypeName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Biaya SDM", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-1daa96531003"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Prive", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Biaya Operasional", null, null }
                });

            migrationBuilder.InsertData(
                table: "BudgetActivities",
                columns: new[] { "Id", "BudgetTypeId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsShowInProjectExpense", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531002"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Jasa Konsultasi / SDM Luar", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531026"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Marketing", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531025"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya PPN", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531024"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Baya SPT Tahunan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531023"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya kesehatan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531022"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya sewa rumah", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531021"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Operasional Kas", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531020"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Akomodasi / transportasi", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531019"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Iuran & sumbangan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531018"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya ATK & Materai", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531017"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Pembelian Peralatan kerja", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531016"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Pemliharaan Bangunan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531027"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Entertain", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531015"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya telpon dan internet", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531013"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Makan karyawan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531012"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531003"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Laba ditahan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531011"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Project Internal", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531010"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "RND", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531009"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "BPJS Ketenaga kerjaan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531008"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "BPJS Kesehatan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531007"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Pinjaman Karyawan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531006"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Bonus Tahunan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531005"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "THR Karyawan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531004"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Penambahan SDM", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531003"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Training Karyawan", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531014"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Listrik", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-9daa96531028"), new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Biaya Pendidikan", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531002"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531003"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531004"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531005"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531006"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531007"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531008"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531009"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531010"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531011"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531012"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531013"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531014"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531015"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531016"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531017"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531018"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531019"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531020"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531021"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531022"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531023"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531024"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531025"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531026"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531027"));

            migrationBuilder.DeleteData(
                table: "BudgetActivities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-9daa96531028"));

            migrationBuilder.DeleteData(
                table: "BudgetTypes",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-1daa96531002"));

            migrationBuilder.DeleteData(
                table: "BudgetTypes",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-1daa96531003"));

            migrationBuilder.DeleteData(
                table: "BudgetTypes",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-1daa96531004"));
        }
    }
}
