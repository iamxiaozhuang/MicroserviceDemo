using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionService.Domain.Migrations
{
    public partial class _20191023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Principal",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantCode = table.Column<string>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerScopeCode = table.Column<string>(nullable: true),
                    PrincipalCode = table.Column<string>(nullable: false),
                    PrincipalName = table.Column<string>(nullable: false),
                    PrincipalDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principal", x => new { x.TenantCode, x.ID });
                });

            migrationBuilder.CreateTable(
                name: "Recycle",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantCode = table.Column<string>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerScopeCode = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: false),
                    RowKey = table.Column<Guid>(nullable: false),
                    RowData = table.Column<string>(nullable: false),
                    DeleteBatchID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recycle", x => new { x.TenantCode, x.ID });
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantCode = table.Column<string>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerScopeCode = table.Column<string>(nullable: true),
                    RoleCode = table.Column<string>(nullable: false),
                    RoleName = table.Column<string>(nullable: false),
                    RoleType = table.Column<int>(nullable: false),
                    SortNO = table.Column<int>(nullable: false),
                    RoleDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => new { x.TenantCode, x.ID });
                });

            migrationBuilder.CreateTable(
                name: "Scope",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantCode = table.Column<string>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerScopeCode = table.Column<string>(nullable: true),
                    ScopeCode = table.Column<string>(nullable: false),
                    ScopeName = table.Column<string>(nullable: false),
                    ParentScopeID = table.Column<Guid>(nullable: false),
                    SortNO = table.Column<int>(nullable: false),
                    ScopeDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scope", x => new { x.TenantCode, x.ID });
                    table.ForeignKey(
                        name: "FK_Scope_Scope_TenantCode_ParentScopeID",
                        columns: x => new { x.TenantCode, x.ParentScopeID },
                        principalTable: "Scope",
                        principalColumns: new[] { "TenantCode", "ID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantCode = table.Column<string>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerScopeCode = table.Column<string>(nullable: true),
                    RoleID = table.Column<Guid>(nullable: false),
                    ResourceCode = table.Column<string>(nullable: false),
                    ResourceName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.TenantCode, x.ID });
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_TenantCode_RoleID",
                        columns: x => new { x.TenantCode, x.RoleID },
                        principalTable: "Role",
                        principalColumns: new[] { "TenantCode", "ID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleAssignment",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantCode = table.Column<string>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerScopeCode = table.Column<string>(nullable: true),
                    PrincipalID = table.Column<Guid>(nullable: false),
                    RoleID = table.Column<Guid>(nullable: false),
                    ScopeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAssignment", x => new { x.TenantCode, x.ID });
                    table.ForeignKey(
                        name: "FK_RoleAssignment_Principal_TenantCode_PrincipalID",
                        columns: x => new { x.TenantCode, x.PrincipalID },
                        principalTable: "Principal",
                        principalColumns: new[] { "TenantCode", "ID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAssignment_Role_TenantCode_RoleID",
                        columns: x => new { x.TenantCode, x.RoleID },
                        principalTable: "Role",
                        principalColumns: new[] { "TenantCode", "ID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAssignment_Scope_TenantCode_ScopeID",
                        columns: x => new { x.TenantCode, x.ScopeID },
                        principalTable: "Scope",
                        principalColumns: new[] { "TenantCode", "ID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Principal",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "PrincipalCode", "PrincipalDesc", "PrincipalName", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("5d3fc5d1-a30f-4742-b626-b978a7c4af5e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "admin", null, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "RoleCode", "RoleDesc", "RoleName", "RoleType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "administor", null, "administor", 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("88888888-8888-8888-8888-888888888888"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("88888888-8888-8888-8888-888888888888"), "RootScope", null, "RootScope", 0, null, null });

            migrationBuilder.InsertData(
                table: "RoleAssignment",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "PrincipalID", "RoleID", "ScopeID", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("55c3cbd1-1427-4bc5-b325-3dd5b4b0a24f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("5d3fc5d1-a30f-4742-b626-b978a7c4af5e"), new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), new Guid("88888888-8888-8888-8888-888888888888"), null, null });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ResourceCode", "ResourceName", "RoleID", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { "SYSTEM", new Guid("effb913d-7092-42a5-b75d-be5f856aa3a0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "RootMenu", "RootMenu", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), null, null },
                    { "SYSTEM", new Guid("8eabe7f3-9604-4d0b-8e66-b7de07cdaa6d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "ProductMngmt", "产品管理", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), null, null },
                    { "SYSTEM", new Guid("c934eddf-e65a-4828-acfb-6b947801488d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt", "系统管理", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), null, null },
                    { "SYSTEM", new Guid("708c9838-ad2f-48b9-aee6-d0d218e3db42"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt", "权限管理", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), null, null },
                    { "SYSTEM", new Guid("da520c6a-f60f-4f56-b7b8-d6a71e160e64"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt", "角色管理", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), null, null },
                    { "SYSTEM", new Guid("a2ca3b83-3ee8-4785-83f8-26dd4264ca42"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Read", "查看", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), null, null },
                    { "SYSTEM", new Guid("1b139b8f-25f9-41d2-bba2-6f79a5a8d05a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Update", "更改", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), null, null },
                    { "SYSTEM", new Guid("c06b8be9-680b-4898-acd8-e6cda5169738"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.ScopeMngmt", "范围管理", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), null, null },
                    { "SYSTEM", new Guid("3a6d08c3-5c43-473a-bef1-cc9b67b5ace7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.AssignmnentMngmt", "授权管理", new Guid("8e28c0e8-92e0-4449-8907-4454fa084caf"), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Principal_TenantCode",
                table: "Principal",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_Principal_TenantCode_PrincipalCode",
                table: "Principal",
                columns: new[] { "TenantCode", "PrincipalCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recycle_TenantCode",
                table: "Recycle",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_Role_TenantCode",
                table: "Role",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_Role_TenantCode_RoleCode",
                table: "Role",
                columns: new[] { "TenantCode", "RoleCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignment_TenantCode",
                table: "RoleAssignment",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignment_TenantCode_PrincipalID",
                table: "RoleAssignment",
                columns: new[] { "TenantCode", "PrincipalID" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignment_TenantCode_RoleID",
                table: "RoleAssignment",
                columns: new[] { "TenantCode", "RoleID" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignment_TenantCode_ScopeID",
                table: "RoleAssignment",
                columns: new[] { "TenantCode", "ScopeID" });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_TenantCode",
                table: "RolePermission",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_TenantCode_RoleID",
                table: "RolePermission",
                columns: new[] { "TenantCode", "RoleID" });

            migrationBuilder.CreateIndex(
                name: "IX_Scope_TenantCode",
                table: "Scope",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_Scope_TenantCode_ParentScopeID",
                table: "Scope",
                columns: new[] { "TenantCode", "ParentScopeID" });

            migrationBuilder.CreateIndex(
                name: "IX_Scope_TenantCode_ScopeCode",
                table: "Scope",
                columns: new[] { "TenantCode", "ScopeCode" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recycle");

            migrationBuilder.DropTable(
                name: "RoleAssignment");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Principal");

            migrationBuilder.DropTable(
                name: "Scope");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
