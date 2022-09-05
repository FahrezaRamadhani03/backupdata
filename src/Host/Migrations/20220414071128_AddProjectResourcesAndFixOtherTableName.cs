// <copyright file="20220414071128_AddProjectResourcesAndFixOtherTableName.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class AddProjectResourcesAndFixOtherTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevelopmentRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DevelopmentRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Leader = table.Column<bool>(type: "boolean", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectResources_DevelopmentRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "DevelopmentRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectResources_Projects_Id",
                        column: x => x.Id,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DevelopmentRoles",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Leader", "Level", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531001"), "PM", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, "Project manager", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531002"), "APM", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, "Acting Project Manager", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531003"), "TL", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, "Technical Leader", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"), "FE", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Frontend Developer", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"), "BE", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Backend Developer", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"), "MBL", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Mobile Developer", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"), "BA", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Business Analyst", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"), "SA", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "System Analyst", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"), "QA", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Quality Assurance", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentRoles_Code",
                table: "DevelopmentRoles",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResources_RoleId",
                table: "ProjectResources",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectResources");

            migrationBuilder.DropTable(
                name: "DevelopmentRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DevelopmentRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Leader = table.Column<bool>(type: "boolean", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
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
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531003"), "TL", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, "Technical Leader", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531004"), "FE", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Frontend Developer", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531005"), "BE", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Backend Developer", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531006"), "MBL", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Mobile Developer", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531007"), "BA", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Business Analyst", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531008"), "SA", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "System Analyst", null, null },
                    { new Guid("d45cb8d2-435e-4661-89d5-3daa96531009"), "QA", null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "\"[\\\"Senior\\\",  \\\"Middle\\\",  \\\"Junior\\\"]\"", "Quality Assurance", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentRole_Code",
                table: "DevelopmentRole",
                column: "Code");
        }
    }
}
