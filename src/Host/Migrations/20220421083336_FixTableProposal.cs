using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class FixTableProposal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Proposals",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ProjectAmount",
                table: "Proposals",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Proposal");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectAmount",
                table: "Proposals",
                type: "text",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
