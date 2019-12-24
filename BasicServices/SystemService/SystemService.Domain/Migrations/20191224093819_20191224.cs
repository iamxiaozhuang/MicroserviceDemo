using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemService.Domain.Migrations
{
    public partial class _20191224 : Migration
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
                    { new Guid("8b586023-13a5-4917-8ed9-b2205ccc3e4f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, "SYSTEM", null, "", "SYSTEM", "www.system.com", null, null },
                    { new Guid("04ad276b-bf9d-4310-a532-78b7aea6d12e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, "MSFT", null, "", "Microsoft", "www.microsoft.com", null, null },
                    { new Guid("e55538c6-e188-49aa-b05b-e38c63e78eba"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, "GOOG", null, "", "Google", "www.Google.com", null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("f7524a68-2240-49b4-b30e-debb88ceff45"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "Permission.GetUserMenus", null, "获取用户菜单", 2, 0, null, null },
                    { new Guid("00597049-0235-4582-aa49-5ed181e7e4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "ProductMngmt", null, "产品管理", 1, 1, null, null },
                    { new Guid("67712b81-1d99-462a-ae6c-3233d48c9e90"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "OrderingMngmt", null, "订单管理", 1, 2, null, null },
                    { new Guid("c7c363ca-48cb-4ecf-a22b-9e11793a4b37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "PaymentMngmt", null, "支付管理", 1, 3, null, null },
                    { new Guid("b541e964-dcdf-45ee-b5e7-1420327a5f73"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "SystemMngmt", null, "系统管理", 1, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1f62f061-20a1-493d-83b1-fc14e158b8c9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("00597049-0235-4582-aa49-5ed181e7e4ce"), "product.list", null, "列出", 2, 1, null, null },
                    { new Guid("980e8188-18d2-4d05-b5cd-79880384be12"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("00597049-0235-4582-aa49-5ed181e7e4ce"), "product.get", null, "获取单个", 2, 2, null, null },
                    { new Guid("3cd6c00a-abe5-43c6-b58e-72ddde536bc5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("00597049-0235-4582-aa49-5ed181e7e4ce"), "product.add", null, "添加", 2, 3, null, null },
                    { new Guid("251558f5-b1bd-4785-87f4-c88b30f734f0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("00597049-0235-4582-aa49-5ed181e7e4ce"), "product.update", null, "更新", 2, 4, null, null },
                    { new Guid("5060bc4c-cf5b-409a-b6b8-8a4385e35f20"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("00597049-0235-4582-aa49-5ed181e7e4ce"), "product.delete", null, "删除", 2, 5, null, null },
                    { new Guid("9d05c9be-8f3a-4eb2-a74a-c5170e0d60ab"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("00597049-0235-4582-aa49-5ed181e7e4ce"), "basket.createorder", null, "购物车下单", 2, 6, null, null },
                    { new Guid("2b87714d-043a-485b-a356-605ed5561a64"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("67712b81-1d99-462a-ae6c-3233d48c9e90"), "ordering.add", null, "新增订单", 2, 1, null, null },
                    { new Guid("0e5501fc-2afa-4c92-b872-6d495f85374f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b541e964-dcdf-45ee-b5e7-1420327a5f73"), "SystemMngmt.PermissionMngmt", null, "权限管理", 1, 1, null, null },
                    { new Guid("adf742f1-8a92-4cd0-9814-84fd3a73e4fb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b541e964-dcdf-45ee-b5e7-1420327a5f73"), "SystemMngmt.JobMngmt", null, "任务管理", 1, 2, null, null },
                    { new Guid("9ae9c077-d7f1-4021-9439-b4e83dc82f82"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b541e964-dcdf-45ee-b5e7-1420327a5f73"), "SystemMngmt.MessageMngmt", null, "消息管理", 1, 3, null, null },
                    { new Guid("a67e5312-5847-48c7-99f7-703384fa0d4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b541e964-dcdf-45ee-b5e7-1420327a5f73"), "SystemMngmt.CacheMngmt", null, "缓存管理", 1, 3, null, null },
                    { new Guid("bce2e46e-a4ec-49ed-846d-394c83bc5009"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b541e964-dcdf-45ee-b5e7-1420327a5f73"), "SystemMngmt.LogMngmt", null, "日志管理", 1, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("f33021a4-3cae-40f1-af19-6c187ac2aecc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3cd6c00a-abe5-43c6-b58e-72ddde536bc5"), "product.add.addbtn", null, "添加按钮", 3, 1, null, null },
                    { new Guid("279a4970-6f6e-4e10-9345-cde11ffade89"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("0e5501fc-2afa-4c92-b872-6d495f85374f"), "SystemMngmt.PermissionMngmt.RoleMngmt", null, "角色管理", 1, 1, null, null },
                    { new Guid("2d756cbd-de72-4e65-b58c-5647f26ce398"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("0e5501fc-2afa-4c92-b872-6d495f85374f"), "SystemMngmt.PermissionMngmt.ScopeMngmt", null, "范围管理", 1, 2, null, null },
                    { new Guid("7d751a26-ba2b-4d59-928d-d8705502c85c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("0e5501fc-2afa-4c92-b872-6d495f85374f"), "SystemMngmt.PermissionMngmt.UserMngmt", null, "用户管理", 1, 2, null, null },
                    { new Guid("d1ac524c-967a-4d74-95b9-aa464be4bc2b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("0e5501fc-2afa-4c92-b872-6d495f85374f"), "SystemMngmt.PermissionMngmt.AssignmnentMngmt", null, "授权管理", 1, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("d99cb46d-cffa-4a4c-a18e-720820679a93"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("279a4970-6f6e-4e10-9345-cde11ffade89"), "SystemMngmt.PermissionMngmt.RoleMngmt.Read", null, "查看", 2, 1, null, null },
                    { new Guid("ac45cef8-abd7-45e9-9c13-9259e2a7159c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("279a4970-6f6e-4e10-9345-cde11ffade89"), "SystemMngmt.PermissionMngmt.RoleMngmt.Update", null, "更改", 2, 2, null, null }
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
