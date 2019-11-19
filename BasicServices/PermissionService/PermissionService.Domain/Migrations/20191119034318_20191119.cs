using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionService.Domain.Migrations
{
    public partial class _20191119 : Migration
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
                values: new object[] { "SYSTEM", new Guid("0f48ddee-66a0-42b9-ac3b-f8705badf4aa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "admin", null, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "RoleCode", "RoleDesc", "RoleName", "RoleType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "administor", null, "administor", 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("88888888-8888-8888-8888-888888888888"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("88888888-8888-8888-8888-888888888888"), "RootScope", null, "RootScope", 0, null, null });

            migrationBuilder.InsertData(
                table: "RoleAssignment",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "PrincipalID", "RoleID", "ScopeID", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("71b619d1-3d3f-415b-b78d-1d307dce1d33"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("0f48ddee-66a0-42b9-ac3b-f8705badf4aa"), new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), new Guid("88888888-8888-8888-8888-888888888888"), null, null });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ResourceCode", "ResourceName", "RoleID", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { "SYSTEM", new Guid("5e202161-af2e-48ab-9040-a22ac7a1cac9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "Permission.GetUserMenus", "获取用户菜单", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("32e711c9-844c-479d-addd-a2f62f122250"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "values.getuserclaims", "getuserclaims", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("81f20441-938e-4fa7-aae1-7b457e0dadff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "RootMenu", "RootMenu", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("e801aae5-d346-497d-b227-1a5a69a54a13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "ProductMngmt", "产品管理", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("2cb71513-c0a4-4910-8a4c-2e9c9828d449"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt", "系统管理", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("19db8614-f955-4497-bcf6-9f3fb2dabe51"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt", "权限管理", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("a3b7904a-d00d-4fb6-86a1-12d4bbbc4208"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt", "角色管理", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("4a68dca2-0eac-437f-8c49-11d606f871d9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Read", "查看", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("7f2087fa-0ce4-4dc7-9772-fbe006ad2b1f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Update", "更改", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("77ae39ee-3384-40a3-8b95-4d6b6c7a8027"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.ScopeMngmt", "范围管理", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null },
                    { "SYSTEM", new Guid("474ab566-f062-4314-8d54-f8e343ea2453"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.AssignmnentMngmt", "授权管理", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), null, null }
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
