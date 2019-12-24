using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionService.Domain.Migrations
{
    public partial class _20191224 : Migration
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
                values: new object[] { "SYSTEM", new Guid("37e9e76f-9e84-4b8f-80ad-480747c06b74"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "admin", null, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "RoleCode", "RoleDesc", "RoleName", "RoleType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "administor", null, "administor", 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("88888888-8888-8888-8888-888888888888"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("88888888-8888-8888-8888-888888888888"), "RootScope", null, "RootScope", 0, null, null });

            migrationBuilder.InsertData(
                table: "RoleAssignment",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "PrincipalID", "RoleID", "ScopeID", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("c24e3959-5c86-4316-802b-34efe602a6a2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("37e9e76f-9e84-4b8f-80ad-480747c06b74"), new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), new Guid("88888888-8888-8888-8888-888888888888"), null, null });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ResourceCode", "ResourceName", "RoleID", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { "SYSTEM", new Guid("70b5047d-bb2c-4f97-ae6f-751f5dc69660"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "Permission.GetUserMenus", "获取用户菜单", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("a43beabb-62df-4b28-bd28-a7819aef6523"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "ordering.add", "新增订单", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("6ba0db6d-72a2-4bd3-ab84-24bdf765ff11"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "basket.createorder", "购物车下单", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("9cea7fda-1541-471a-8021-b994946bf959"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.AssignmnentMngmt", "授权管理", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("85d21226-3a13-4dd2-8da2-e2fe1fa1b0ef"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.ScopeMngmt", "范围管理", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("8a826da0-1f6f-4140-937e-43af307044bb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Update", "更改", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("7f0ffa23-db79-4ff5-b5ec-39edd3881c11"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Read", "查看", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("a799f4ed-ff6d-4647-8ba1-08434660546e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt", "角色管理", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("4ef641ed-08d4-4607-a385-1ac6ca49da18"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt", "权限管理", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("a7b3457c-9603-41cf-94b8-e89d77fe478d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt", "系统管理", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("e9aacb40-0b0c-42c3-93e0-c1d6337252db"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "product.update", "修改", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("e1265d9a-00e1-4b3a-913f-35dd2269d28f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "product.add", "添加", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("8b751573-ddac-4ad4-8d88-6d15dacc0b81"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "product.get", "获取", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("bdaead14-e418-4521-9cd6-13ec53ba5065"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "product.list", "列出", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("f0fa5ed7-e8fd-42a7-9aa5-799d8560243f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "ProductMngmt", "产品管理", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("84138a15-36b2-4dc1-81f5-f69fed515c67"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "RootMenu", "RootMenu", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("4165c9b4-535a-4c0b-bd8c-4e90c2cd9f9f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "values.getuserclaims", "getuserclaims", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null },
                    { "SYSTEM", new Guid("5247a560-23fb-4a79-ba4d-e72cafcc5116"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "product.delete", "删除", new Guid("e34f723c-d4c3-4a72-9f10-565f771bded0"), null, null }
                });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("2e20b00c-d287-4db8-aa0e-ced487e62414"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("88888888-8888-8888-8888-888888888888"), "1Node1", null, "一级组织", 0, null, null });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { "SYSTEM", new Guid("fb1499d9-87a0-4b64-86e1-5e5d1ae35471"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("2e20b00c-d287-4db8-aa0e-ced487e62414"), "1Node1.2Node1", null, "二级组织1", 1, null, null },
                    { "SYSTEM", new Guid("0a479213-7454-417f-b9a0-7258bbb753ee"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("2e20b00c-d287-4db8-aa0e-ced487e62414"), "1Node1.2Node2", null, "二级组织2", 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("ce9eb279-6945-46b2-af1d-f3bff769b142"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("fb1499d9-87a0-4b64-86e1-5e5d1ae35471"), "1Node1.2Node1.3Node1", null, "三级组织1", 0, null, null });

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
