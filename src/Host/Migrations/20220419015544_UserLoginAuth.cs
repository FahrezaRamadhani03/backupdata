// <copyright file="20220419015544_UserLoginAuth.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class UserLoginAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2446aa92-3c84-4072-8c5e-d8c41deac9c4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8b3c44cb-244b-4f13-b2a0-22020ae26bc6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("81314787-537b-474f-999a-9152c9703bbb"),
                column: "Password",
                value: "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fa3876d9-b8ce-4029-9df6-2e8ee94a3d78"),
                column: "Password",
                value: "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "Fullname", "IsActive", "LastLogin", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { new Guid("2446aa92-3c84-4072-8c5e-d8c41deac9c4"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "rezacodym@gmail.com", "Reza Muharam", true, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "reza_reza" },
                    { new Guid("8b3c44cb-244b-4f13-b2a0-22020ae26bc6"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "atthoriqgf@gmail.com", "Atthoriq", true, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "atthoriq_atthoriq" },
                    { new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "dermawanto_d@banpuindo.co.id", "Dermawanto", true, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "dermawanto_d" }
                });
        }
    }
}
