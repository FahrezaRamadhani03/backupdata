// <copyright file="20220408083658_AddTableDevelopmentRolesAndSeed.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class AddTableDevelopmentRolesAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevelopmentRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Leader = table.Column<bool>(type: "boolean", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DevelopmentRole",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Leader", "Level", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531001"), "PM", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, "Project manager", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531002"), "APM", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, "Acting Project Manager", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531003"), "TL", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, "Technical leader", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"), "FE", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"{{\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"}}\"", "Frontend developer", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"), "BE", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"{{\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"}}\"", "Backend developer", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"), "MBL", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"{{\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"}}\"", "Mobile developer", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"), "BA", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"{{\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"}}\"", "Business analyst", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"), "SA", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"{{\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"}}\"", "System analyst", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"), "QA", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"{{\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"}}\"", "Quality assurance", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentRole_Code",
                table: "DevelopmentRole",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevelopmentRole");
        }
    }
}
