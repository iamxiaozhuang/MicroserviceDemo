using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemService.Domain.Migrations
{
    public partial class _20191119 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Resource",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    ResourceCode = table.Column<string>(nullable: false),
                    ResourceName = table.Column<string>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    ParentResourceID = table.Column<Guid>(nullable: false),
                    SortNO = table.Column<int>(nullable: false),
                    ResourceDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Resource_Resource_ParentResourceID",
                        column: x => x.ParentResourceID,
                        principalTable: "Resource",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    TenantCode = table.Column<string>(nullable: false),
                    TenantName = table.Column<string>(nullable: false),
                    TenantUrl = table.Column<string>(nullable: false),
                    TenantLogo = table.Column<string>(nullable: false),
                    SortNO = table.Column<int>(nullable: false),
                    TenantDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[] { new Guid("88888888-8888-8888-8888-888888888888"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "RootMenu", null, "RootMenu", 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "SortNO", "TenantCode", "TenantDesc", "TenantLogo", "TenantName", "TenantUrl", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("52695b8c-6033-4e22-b177-a70838a5f69c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, "SYSTEM", null, "", "SYSTEM", "www.system.com", null, null },
                    { new Guid("b6abe819-c9f8-48ed-8fa2-d28faf7557b4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, "MSFT", null, "", "Microsoft", "www.microsoft.com", null, null },
                    { new Guid("b11547c4-8dd7-4184-b3a8-96a9f3a7b955"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, "GOOG", null, "", "Google", "www.Google.com", null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("58ff99ee-1ad9-4cfe-8407-74fbb494fff7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "Permission.GetUserMenus", null, "获取用户菜单", 2, 0, null, null },
                    { new Guid("3feae607-8c67-4870-ad7b-9f7a685d4db8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "ProductMngmt", null, "产品管理", 1, 1, null, null },
                    { new Guid("fd10e54b-2e87-4abc-becd-3b39882413bd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "OrderingMngmt", null, "订单管理", 1, 2, null, null },
                    { new Guid("85312b0a-fc1f-43a2-8dc6-50266fc99cc1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "PaymentMngmt", null, "支付管理", 1, 3, null, null },
                    { new Guid("eee46887-62a2-4d55-b8cf-77c096339d14"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "SystemMngmt", null, "系统管理", 1, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("d0c9d91d-145d-4941-9a8f-f75083feaf66"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3feae607-8c67-4870-ad7b-9f7a685d4db8"), "ProductMngmt.Read", null, "查看", 2, 1, null, null },
                    { new Guid("ab944839-be7d-4184-98dd-1292011c1a1e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3feae607-8c67-4870-ad7b-9f7a685d4db8"), "ProductMngmt.Add", null, "添加", 2, 2, null, null },
                    { new Guid("340baee6-c56e-4b47-8f32-0445a9c3331d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3feae607-8c67-4870-ad7b-9f7a685d4db8"), "ProductMngmt.Edit", null, "修改", 2, 3, null, null },
                    { new Guid("c4a3567b-bc52-4406-88dd-eac55a31e891"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3feae607-8c67-4870-ad7b-9f7a685d4db8"), "ProductMngmt.Delete", null, "删除", 2, 4, null, null },
                    { new Guid("3c9a3c21-daf2-4653-8034-88ec946d36ca"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("eee46887-62a2-4d55-b8cf-77c096339d14"), "SystemMngmt.PermissionMngmt", null, "权限管理", 1, 1, null, null },
                    { new Guid("17c7f6f9-0d34-4b16-9e6a-3b05638b8afe"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("eee46887-62a2-4d55-b8cf-77c096339d14"), "SystemMngmt.JobMngmt", null, "任务管理", 1, 2, null, null },
                    { new Guid("2ce185a5-8095-4276-90b8-d4554682851e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("eee46887-62a2-4d55-b8cf-77c096339d14"), "SystemMngmt.MessageMngmt", null, "消息管理", 1, 3, null, null },
                    { new Guid("8c0debaa-33a9-421e-b29a-a2da0cb4ce78"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("eee46887-62a2-4d55-b8cf-77c096339d14"), "SystemMngmt.CacheMngmt", null, "缓存管理", 1, 3, null, null },
                    { new Guid("7d64baf8-43a0-4c02-bf66-c13a91fb0198"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("eee46887-62a2-4d55-b8cf-77c096339d14"), "SystemMngmt.LogMngmt", null, "日志管理", 1, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("fd87a982-d757-44b6-a2e4-6bba177f2448"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("ab944839-be7d-4184-98dd-1292011c1a1e"), "ProductMngmt.Add.AddBtn", null, "添加按钮", 3, 1, null, null },
                    { new Guid("22f7aaeb-8a5e-448d-a53c-ab8bc11aba79"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3c9a3c21-daf2-4653-8034-88ec946d36ca"), "SystemMngmt.PermissionMngmt.RoleMngmt", null, "角色管理", 1, 1, null, null },
                    { new Guid("3e1ac31b-2459-43ad-b4b7-65c409ac527a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3c9a3c21-daf2-4653-8034-88ec946d36ca"), "SystemMngmt.PermissionMngmt.ScopeMngmt", null, "范围管理", 1, 2, null, null },
                    { new Guid("e1a98928-e0d3-413a-b516-c1b9021316e2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3c9a3c21-daf2-4653-8034-88ec946d36ca"), "SystemMngmt.PermissionMngmt.UserMngmt", null, "用户管理", 1, 2, null, null },
                    { new Guid("7ed38fa3-6314-43f4-a3c3-9f2a1b4f96ad"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3c9a3c21-daf2-4653-8034-88ec946d36ca"), "SystemMngmt.PermissionMngmt.AssignmnentMngmt", null, "授权管理", 1, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("ab427912-168e-42d7-8ace-a99b4f3b0e9c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("22f7aaeb-8a5e-448d-a53c-ab8bc11aba79"), "SystemMngmt.PermissionMngmt.RoleMngmt.Read", null, "查看", 2, 1, null, null },
                    { new Guid("253e85e9-35ac-459e-bb5c-662c3e680c3f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("22f7aaeb-8a5e-448d-a53c-ab8bc11aba79"), "SystemMngmt.PermissionMngmt.RoleMngmt.Update", null, "更改", 2, 2, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recycle_TenantCode",
                table: "Recycle",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ParentResourceID",
                table: "Resource",
                column: "ParentResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceCode",
                table: "Resource",
                column: "ResourceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_TenantCode",
                table: "Tenant",
                column: "TenantCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recycle");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
