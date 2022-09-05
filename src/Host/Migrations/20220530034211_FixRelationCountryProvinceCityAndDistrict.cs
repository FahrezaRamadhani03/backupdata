using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixRelationCountryProvinceCityAndDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Provinces",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Districts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                table: "Cities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-4daa96531001"),
                column: "ProvinceId",
                value: new Guid("d45cb8d2-435e-4661-89d5-6daa96531001"));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-4daa96531002"),
                columns: new[] { "Code", "Name", "ProvinceId" },
                values: new object[] { "TGL", "Tegal", new Guid("d45cb8d2-435e-4661-89d5-6daa96531002") });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-7daa96531001"),
                column: "CityId",
                value: new Guid("d45cb8d2-435e-4661-89d5-4daa96531001"));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-7daa96531002"),
                columns: new[] { "CityId", "Name" },
                values: new object[] { new Guid("d45cb8d2-435e-4661-89d5-4daa96531001"), "Sukasari" });

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-6daa96531001"),
                column: "CountryId",
                value: new Guid("d45cb8d2-435e-4661-89d5-5daa96531001"));

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-6daa96531002"),
                columns: new[] { "CountryId", "Name" },
                values: new object[] { new Guid("d45cb8d2-435e-4661-89d5-5daa96531001"), "Jawa Tengah" });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_CountryId",
                table: "Provinces",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_CountryId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Districts_CityId",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Cities");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-4daa96531002"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "JKT", "Jakarta" });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-7daa96531002"),
                column: "Name",
                value: "Gegerkalong");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d45cb8d2-435e-4661-89d5-6daa96531002"),
                column: "Name",
                value: "Jawa Timur");
        }
    }
}
