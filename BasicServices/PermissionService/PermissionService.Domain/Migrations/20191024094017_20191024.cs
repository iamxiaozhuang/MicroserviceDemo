using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionService.Domain.Migrations
{
    public partial class _20191024 : Migration
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
                values: new object[] { "SYSTEM", new Guid("a6fab670-7c22-4dc7-acf3-1b739e2e8b91"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "admin", null, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "RoleCode", "RoleDesc", "RoleName", "RoleType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "administor", null, "administor", 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("88888888-8888-8888-8888-888888888888"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("88888888-8888-8888-8888-888888888888"), "RootScope", null, "RootScope", 0, null, null });

            migrationBuilder.InsertData(
                table: "RoleAssignment",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "PrincipalID", "RoleID", "ScopeID", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("d5d14bc7-b83e-4df0-a572-a27935259e4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("a6fab670-7c22-4dc7-acf3-1b739e2e8b91"), new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), new Guid("88888888-8888-8888-8888-888888888888"), null, null });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ResourceCode", "ResourceName", "RoleID", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { "SYSTEM", new Guid("81bc728f-7edb-47db-beb9-ba8a1a4d7325"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "Permission.GetUserMenus", "获取用户菜单", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("7519b7f7-d46a-4929-886d-fca6d5b5d941"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "values.getuserclaims", "getuserclaims", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("ce4e13a6-aa4c-4f6c-b5ff-87dea9a89e20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "RootMenu", "RootMenu", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("3fa831f6-31c2-43b7-afc0-e9e158cb4c93"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "ProductMngmt", "产品管理", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("83a024fb-1e7e-4c6c-8f49-6fc17446b2b3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt", "系统管理", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("8be510da-b906-4261-9989-2446afd9e6e2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt", "权限管理", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("a7c3ab21-b601-4bb1-8b3c-eb45a4bb7b48"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt", "角色管理", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("57a86b61-07ba-438e-9f9a-9a4448d00356"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Read", "查看", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("4b6f4af5-4593-400f-b150-a3c2b7c75fcb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Update", "更改", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("8744628f-a654-44b4-b078-59a5b495f95e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.ScopeMngmt", "范围管理", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null },
                    { "SYSTEM", new Guid("89ca89ee-c79e-4e36-a340-0297f9efa6a1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.AssignmnentMngmt", "授权管理", new Guid("b3b8f99c-f144-42da-9450-2119b9c020b8"), null, null }
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
