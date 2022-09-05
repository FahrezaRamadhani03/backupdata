using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class CreateTableDevelopmentInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevelopmentHoliday",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    HolidayDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentHoliday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevelopmentHoliday_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevelopmentScrum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    DaysInSprint = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentScrum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevelopmentScrum_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevelopmentScrumSprint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DevelopmentScrumId = table.Column<Guid>(type: "uuid", nullable: false),
                    Sprintname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SprintStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SprintEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DayLength = table.Column<int>(type: "integer", nullable: false),
                    HolidayLength = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentScrumSprint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevelopmentScrumSprint_DevelopmentScrum_DevelopmentScrumId",
                        column: x => x.DevelopmentScrumId,
                        principalTable: "DevelopmentScrum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentHoliday_ProjectId",
                table: "DevelopmentHoliday",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentScrum_ProjectId",
                table: "DevelopmentScrum",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentScrumSprint_DevelopmentScrumId",
                table: "DevelopmentScrumSprint",
                column: "DevelopmentScrumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevelopmentHoliday");

            migrationBuilder.DropTable(
                name: "DevelopmentScrumSprint");

            migrationBuilder.DropTable(
                name: "DevelopmentScrum");
        }
    }
}
