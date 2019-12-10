using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionService.Domain.Migrations
{
    public partial class _20191205 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAssignment",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("71b619d1-3d3f-415b-b78d-1d307dce1d33") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("19db8614-f955-4497-bcf6-9f3fb2dabe51") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("2cb71513-c0a4-4910-8a4c-2e9c9828d449") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("32e711c9-844c-479d-addd-a2f62f122250") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("474ab566-f062-4314-8d54-f8e343ea2453") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("4a68dca2-0eac-437f-8c49-11d606f871d9") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("5e202161-af2e-48ab-9040-a22ac7a1cac9") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("77ae39ee-3384-40a3-8b95-4d6b6c7a8027") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("7f2087fa-0ce4-4dc7-9772-fbe006ad2b1f") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("81f20441-938e-4fa7-aae1-7b457e0dadff") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("a3b7904a-d00d-4fb6-86a1-12d4bbbc4208") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("e801aae5-d346-497d-b227-1a5a69a54a13") });

            migrationBuilder.DeleteData(
                table: "Principal",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("0f48ddee-66a0-42b9-ac3b-f8705badf4aa") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c") });

            migrationBuilder.InsertData(
                table: "Principal",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "PrincipalCode", "PrincipalDesc", "PrincipalName", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("288d6758-80b8-4aa7-a7d9-707e6ffd7c01"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "admin", null, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "RoleCode", "RoleDesc", "RoleName", "RoleType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "administor", null, "administor", 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("d5ec1a49-aad2-4f14-a6f3-111e35eca07d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("88888888-8888-8888-8888-888888888888"), "1Node1", null, "一级组织", 0, null, null });

            migrationBuilder.InsertData(
                table: "RoleAssignment",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "PrincipalID", "RoleID", "ScopeID", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("b2efff48-1ac0-4958-84f3-cb3b02af8098"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("288d6758-80b8-4aa7-a7d9-707e6ffd7c01"), new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), new Guid("88888888-8888-8888-8888-888888888888"), null, null });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ResourceCode", "ResourceName", "RoleID", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { "SYSTEM", new Guid("a1d86598-1327-4cb6-8f5a-306ce0eac5e3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "Permission.GetUserMenus", "获取用户菜单", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("98102026-eebb-42c6-83cb-bc35cb982065"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "values.getuserclaims", "getuserclaims", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("f59d6378-fe14-4283-b91b-118e9d5772a1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "RootMenu", "RootMenu", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("05c8d0cf-1ad5-4331-864f-585e053ffb07"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "ProductMngmt", "产品管理", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("ce043224-0df7-4d93-a472-1a4012738749"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt", "系统管理", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("f8fdf5b1-0193-411f-ada0-d352fab92a64"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt", "权限管理", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("2c6c1c3f-c6e7-4b0e-9f71-83d461019734"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt", "角色管理", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("a21c2c4f-59db-475b-bc18-6d4af8dd76aa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Read", "查看", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("0f5a9ab9-03f0-4c9f-b600-9f3a57bd3957"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.RoleMngmt.Update", "更改", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("e06bec7a-ec41-46b0-9e43-73bfd22c6d64"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.ScopeMngmt", "范围管理", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("eeec07dc-e0c7-4f6f-9eab-ccdba7b0c819"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "SystemMngmt.PermissionMngmt.AssignmnentMngmt", "授权管理", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("cc1a8536-3136-4d08-b4ea-51fc75674ccc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "basket.createorder", "购物车下单", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null },
                    { "SYSTEM", new Guid("ba05d080-566a-4668-8d8a-470b7e30d1e3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "ordering.add", "新增订单", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89"), null, null }
                });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { "SYSTEM", new Guid("f83687ae-8d50-41a0-8852-39ac93680774"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("d5ec1a49-aad2-4f14-a6f3-111e35eca07d"), "1Node1.2Node1", null, "二级组织1", 1, null, null },
                    { "SYSTEM", new Guid("257a6adb-1e47-49d8-a291-50c3fc4489b0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("d5ec1a49-aad2-4f14-a6f3-111e35eca07d"), "1Node1.2Node2", null, "二级组织2", 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Scope",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "ParentScopeID", "ScopeCode", "ScopeDesc", "ScopeName", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("0dd5fe76-8e84-4833-af32-cbd5f2c559b6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", new Guid("f83687ae-8d50-41a0-8852-39ac93680774"), "1Node1.2Node1.3Node1", null, "三级组织1", 0, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAssignment",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("b2efff48-1ac0-4958-84f3-cb3b02af8098") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("05c8d0cf-1ad5-4331-864f-585e053ffb07") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("0f5a9ab9-03f0-4c9f-b600-9f3a57bd3957") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("2c6c1c3f-c6e7-4b0e-9f71-83d461019734") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("98102026-eebb-42c6-83cb-bc35cb982065") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("a1d86598-1327-4cb6-8f5a-306ce0eac5e3") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("a21c2c4f-59db-475b-bc18-6d4af8dd76aa") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("ba05d080-566a-4668-8d8a-470b7e30d1e3") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("cc1a8536-3136-4d08-b4ea-51fc75674ccc") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("ce043224-0df7-4d93-a472-1a4012738749") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("e06bec7a-ec41-46b0-9e43-73bfd22c6d64") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("eeec07dc-e0c7-4f6f-9eab-ccdba7b0c819") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("f59d6378-fe14-4283-b91b-118e9d5772a1") });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("f8fdf5b1-0193-411f-ada0-d352fab92a64") });

            migrationBuilder.DeleteData(
                table: "Scope",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("0dd5fe76-8e84-4833-af32-cbd5f2c559b6") });

            migrationBuilder.DeleteData(
                table: "Scope",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("257a6adb-1e47-49d8-a291-50c3fc4489b0") });

            migrationBuilder.DeleteData(
                table: "Principal",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("288d6758-80b8-4aa7-a7d9-707e6ffd7c01") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("8ae0bc01-b937-4e3a-a5cf-e32bc5650c89") });

            migrationBuilder.DeleteData(
                table: "Scope",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("f83687ae-8d50-41a0-8852-39ac93680774") });

            migrationBuilder.DeleteData(
                table: "Scope",
                keyColumns: new[] { "TenantCode", "ID" },
                keyValues: new object[] { "SYSTEM", new Guid("d5ec1a49-aad2-4f14-a6f3-111e35eca07d") });

            migrationBuilder.InsertData(
                table: "Principal",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "PrincipalCode", "PrincipalDesc", "PrincipalName", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("0f48ddee-66a0-42b9-ac3b-f8705badf4aa"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "admin", null, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "TenantCode", "ID", "CreateIn", "CreatedBy", "OwnerScopeCode", "RoleCode", "RoleDesc", "RoleName", "RoleType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("f5893dc8-84fd-49c0-9874-2e0f2474209c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", "administor", null, "administor", 1, 0, null, null });

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
        }
    }
}
