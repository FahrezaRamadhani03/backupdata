using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Garuda.Host.Migrations
{
    public partial class FixTableClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "ClientId",
               table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Projects",
                type: "integer",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "ClientId",
               table: "Projects");

            migrationBuilder.AddColumn<Guid>(
              name: "ClientId",
              table: "Projects",
              type: "uuid",
              nullable: false,
              defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
