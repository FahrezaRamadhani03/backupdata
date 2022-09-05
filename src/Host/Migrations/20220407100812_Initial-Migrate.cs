using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garuda.Host.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "audit_logs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    class_name = table.Column<string>(type: "text", nullable: true),
                    action = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    old_value = table.Column<string>(type: "text", nullable: true),
                    new_value = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    deleted_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audit_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    DisplayName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Level = table.Column<int>(type: "integer", maxLength: 500, nullable: false),
                    IconClass = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schemes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Fullname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RefreshToken = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateRevoked = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateExpired = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Jti = table.Column<string>(type: "character varying(1000)", unicode: false, maxLength: 1000, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupMenuPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    CanView = table.Column<bool>(type: "boolean", nullable: false),
                    CanUpdate = table.Column<bool>(type: "boolean", nullable: false),
                    CanCreate = table.Column<bool>(type: "boolean", nullable: false),
                    CanDelete = table.Column<bool>(type: "boolean", nullable: false),
                    CanSubmit = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMenuPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMenuPermissions_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMenuPermissions_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchemeUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    SchemeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchemeUnits_Schemes_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "Schemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchemeUnits_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUnits_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUnits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "Price", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("d45cb8d2-435e-4661-89d5-3daa96531712"), null, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Larman", "120000", null, null });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "QPB Administrator", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("fa997ce4-5b76-447c-9b08-5f448f185ad3"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Mine Head", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Administrator", new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DisplayName", "DisplayOrder", "IconClass", "Level", "ParentId", "Slug", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5026c85e-04f4-4d65-9fd2-bff26ad90013"), "user", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "User Management", 0, "icon-user", 1, new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"), "/IndexUser", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"), "set", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Profile", 5, "icon-cog-outline", 0, new Guid("00000000-0000-0000-0000-000000000000"), "", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("049dde67-5798-4e74-8fff-503400311161"), "vact", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "View Actual", 1, "", 1, new Guid("d73f2bc0-8b65-46f2-9e06-9bd52e990283"), "", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("806f809b-cdd3-4591-a553-085ac97037b9"), "vplan", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "View Plan", 0, "", 1, new Guid("d73f2bc0-8b65-46f2-9e06-9bd52e990283"), "", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("d73f2bc0-8b65-46f2-9e06-9bd52e990283"), "doclib", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Document Library", 4, "icon-search", 0, new Guid("00000000-0000-0000-0000-000000000000"), "", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"), "dash", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Dashboard", 0, "icon-home", 0, new Guid("00000000-0000-0000-0000-000000000000"), "/Dashboard", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("77118193-d70c-4e36-97a0-683b9e825569"), "act", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "My Activity", 2, "icon-notes", 0, new Guid("00000000-0000-0000-0000-000000000000"), "", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("6906ffec-78d6-4631-977d-b0375351fb70"), "cr", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Create Actual", 1, "icon-add", 1, new Guid("293f7746-eac8-4bd1-9550-87347467ebd2"), "", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("77af2b15-1d76-489c-89b7-8f003d19acff"), "cp", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Plan Contractor", 2, "", 2, new Guid("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"), "/CreatePlanContractor", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("08d3fe57-51f3-40d7-8cbc-75899871abf2"), "cp", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Plan Operation", 1, "", 2, new Guid("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"), "/CreatePlanOperation", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("9f54020e-85c1-46fb-9da3-c6150a3e327b"), "cp", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Plan Mine Closure", 0, "", 2, new Guid("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"), "/CreatePlanMineClosure", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"), "cp", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Create Plan", 0, "", 1, new Guid("293f7746-eac8-4bd1-9550-87347467ebd2"), "", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("293f7746-eac8-4bd1-9550-87347467ebd2"), "cr", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Create", 1, "icon-add", 0, new Guid("00000000-0000-0000-0000-000000000000"), "", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("7f2302be-efd5-43f1-b6c9-8e8886c8460c"), "doc", new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "My Document", 3, "icon-file", 0, new Guid("00000000-0000-0000-0000-000000000000"), "", new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "Schemes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("045a0ec7-04e9-4136-b0a6-5ef1d529ea92"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Contractor", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("77c9ef27-2f65-473e-8b61-ff4ce9693655"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Mine Closure", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("5db13726-605c-4a00-b1c4-d6ce3ba507b3"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Operation", new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("af82ee9b-e754-4cb5-ae58-213419183dcf"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "GPK", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("5b11f06f-426b-44f1-9023-170cb85797e3"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "KTD TDM", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("29ec8ffc-c508-4dd5-8c3d-4675ed6af4cc"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "JBG", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("80f560d6-1f61-460e-95ac-ea5b9c001df5"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "IMM", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("b1f30d87-b5a6-4fdb-9f72-76f06db7f7a5"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "KTD EMB", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("23ebbe54-45aa-4435-935d-6fad0d650b86"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "Melak", new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("21cf75f0-c7c6-427b-a392-fce59cb50bc6"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "TRUST", new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "Fullname", "IsActive", "LastLogin", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { new Guid("8b3c44cb-244b-4f13-b2a0-22020ae26bc6"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "atthoriqgf@gmail.com", "Atthoriq", true, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "atthoriq_atthoriq" },
                    { new Guid("81314787-537b-474f-999a-9152c9703bbb"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "system@system.co", "System", true, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "systemadmin" },
                    { new Guid("fa3876d9-b8ce-4029-9df6-2e8ee94a3d78"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "systemreserve@system.co", "System Admin Reserve", true, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "systemadminreserve" },
                    { new Guid("2446aa92-3c84-4072-8c5e-d8c41deac9c4"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "rezacodym@gmail.com", "Reza Muharam", true, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "reza_reza" },
                    { new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, "dermawanto_d@banpuindo.co.id", "Dermawanto", true, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "dermawanto_d" }
                });

            migrationBuilder.InsertData(
                table: "GroupMenuPermissions",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanSubmit", "CanUpdate", "CanView", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "GroupId", "MenuId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("64f03301-c574-46c2-b1e6-2922eaaa826a"), false, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("6d8a282b-2728-4c07-a28f-93ac06977ef6"), true, true, false, true, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("5026c85e-04f4-4d65-9fd2-bff26ad90013"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("e59e9251-d424-4ae1-b0c7-bdd01a4a1fee"), false, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("db5c3fdc-6d75-42a5-97bb-2a0edfbfe45a"), true, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("77af2b15-1d76-489c-89b7-8f003d19acff"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("77b62aa0-5794-41fb-9005-a197c50385e0"), true, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("08d3fe57-51f3-40d7-8cbc-75899871abf2"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("cf5aa817-c923-40ea-9394-de0da2335866"), true, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("9f54020e-85c1-46fb-9da3-c6150a3e327b"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("7c5ab91a-5a1b-4b52-a643-ade5b42f862c"), false, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("b4ab5dec-b541-4a99-b998-511d093207cd"), false, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("6607d37e-dc2b-4ea8-8de5-32bbf7d1ccd3"), false, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("293f7746-eac8-4bd1-9550-87347467ebd2"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("07e87c49-180f-4f00-99e2-7322c0638a2d"), false, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("2144142f-4fea-4e39-92c6-75097b01cd80"), true, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("77af2b15-1d76-489c-89b7-8f003d19acff"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("82ace0f9-6a4f-4a53-b524-306caf258b6d"), true, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("08d3fe57-51f3-40d7-8cbc-75899871abf2"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("246857d8-d23b-4287-9e70-bd3101ec4df8"), true, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("9f54020e-85c1-46fb-9da3-c6150a3e327b"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("fd27fabc-218a-4163-89ee-469f38611af3"), false, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("f1e6588e-ef55-4fcd-9be2-ad71fce2e678"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("2259be39-3027-4aaf-b7d4-6a5d7f196c0d"), false, false, false, false, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("293f7746-eac8-4bd1-9550-87347467ebd2"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("702e4653-2abc-41f1-86f5-c1543ab7d585"), true, true, false, true, true, new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("5026c85e-04f4-4d65-9fd2-bff26ad90013"), new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "SchemeUnits",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "SchemeId", "UnitId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("8e4b6643-4b95-4051-9dc8-5fc2a2ab727f"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("77c9ef27-2f65-473e-8b61-ff4ce9693655"), new Guid("5b11f06f-426b-44f1-9023-170cb85797e3"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("21fb0208-60a4-4827-8451-c597b54cad74"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("5db13726-605c-4a00-b1c4-d6ce3ba507b3"), new Guid("af82ee9b-e754-4cb5-ae58-213419183dcf"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("51f35363-b1ef-4fbd-9021-224cf52c3bd3"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("5db13726-605c-4a00-b1c4-d6ce3ba507b3"), new Guid("29ec8ffc-c508-4dd5-8c3d-4675ed6af4cc"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("c28fc63a-ab3b-4cfa-b246-243f35ffc552"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("5db13726-605c-4a00-b1c4-d6ce3ba507b3"), new Guid("b1f30d87-b5a6-4fdb-9f72-76f06db7f7a5"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("842147f1-c5fa-40ce-96f0-561dda8d7ad9"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("5db13726-605c-4a00-b1c4-d6ce3ba507b3"), new Guid("23ebbe54-45aa-4435-935d-6fad0d650b86"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("b61b1d7d-ee3c-4eae-af2b-49c0e2415449"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("5db13726-605c-4a00-b1c4-d6ce3ba507b3"), new Guid("80f560d6-1f61-460e-95ac-ea5b9c001df5"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("d086072c-4a06-402e-a735-11d5b034a866"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("045a0ec7-04e9-4136-b0a6-5ef1d529ea92"), new Guid("21cf75f0-c7c6-427b-a392-fce59cb50bc6"), new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "GroupId", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("10195c34-4e6d-4795-bbde-bbd17e2c1b0b"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("fa997ce4-5b76-447c-9b08-5f448f185ad3"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") },
                    { new Guid("e5c455f1-f239-4f29-bebd-8bc4239e15fb"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("81314787-537b-474f-999a-9152c9703bbb") },
                    { new Guid("ec211d37-2400-4877-8696-62ac17faeecb"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("2446aa92-3c84-4072-8c5e-d8c41deac9c4") },
                    { new Guid("f1a56c59-0128-4799-826d-50ce44921cb6"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("fa997ce4-5b76-447c-9b08-5f448f185ad3"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("2446aa92-3c84-4072-8c5e-d8c41deac9c4") },
                    { new Guid("4b894dac-7e06-4891-8498-6521ba85dcac"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("8b3c44cb-244b-4f13-b2a0-22020ae26bc6") },
                    { new Guid("145e7f39-120c-4cdd-baac-fbbd74b72a69"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("fa997ce4-5b76-447c-9b08-5f448f185ad3"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("8b3c44cb-244b-4f13-b2a0-22020ae26bc6") },
                    { new Guid("d050c114-fc5f-45c8-a736-b0cacdfc47e6"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("1ce881eb-4ae2-4b04-83d9-7062e6cfffd5"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") },
                    { new Guid("fe9b8375-2bab-4449-88a1-efe80155054e"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") }
                });

            migrationBuilder.InsertData(
                table: "UserUnits",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "UnitId", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("25ec2241-215e-4d2f-890a-88bad0f4127a"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("29ec8ffc-c508-4dd5-8c3d-4675ed6af4cc"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") },
                    { new Guid("00a5ad59-340c-45cb-b423-51aaab6d4ee8"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("21cf75f0-c7c6-427b-a392-fce59cb50bc6"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") },
                    { new Guid("57d4d61b-5814-4f7f-b00f-f5b5a1026908"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("5b11f06f-426b-44f1-9023-170cb85797e3"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") },
                    { new Guid("8f536667-9dcb-4ec4-96a9-8397b0dbf2c6"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("23ebbe54-45aa-4435-935d-6fad0d650b86"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") },
                    { new Guid("a3f3920a-6ac6-4774-9b73-ef58c346e0df"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("80f560d6-1f61-460e-95ac-ea5b9c001df5"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") },
                    { new Guid("d280a08e-1090-4b71-8e7c-8dc391bddafc"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b1f30d87-b5a6-4fdb-9f72-76f06db7f7a5"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") },
                    { new Guid("43e29254-3301-4b3c-a53b-2eaddb5aa4c3"), new Guid("81314787-537b-474f-999a-9152c9703bbb"), new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("af82ee9b-e754-4cb5-ae58-213419183dcf"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("b5a93e5d-e159-4c69-b90d-ae3239a692d3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMenuPermissions_GroupId",
                table: "GroupMenuPermissions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMenuPermissions_MenuId",
                table: "GroupMenuPermissions",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeUnits_SchemeId",
                table: "SchemeUnits",
                column: "SchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeUnits_UnitId",
                table: "SchemeUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserId",
                table: "UserGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUnits_UnitId",
                table: "UserUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUnits_UserId",
                table: "UserUnits",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit_logs");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "GroupMenuPermissions");

            migrationBuilder.DropTable(
                name: "SchemeUnits");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "UserUnits");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Schemes");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
