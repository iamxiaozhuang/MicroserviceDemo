using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemService.Domain.Migrations
{
    public partial class _20191023 : Migration
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
                    { new Guid("a6b87678-0c6d-4ba6-a13b-386e32460100"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, "SYSTEM", null, "", "SYSTEM", "www.system.com", null, null },
                    { new Guid("fd602bb6-9bef-4ece-86f0-0ec49d046291"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, "MSFT", null, "", "Microsoft", "www.microsoft.com", null, null },
                    { new Guid("839320d0-2db1-436f-ab21-6bf15d5e47cb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, "GOOG", null, "", "Google", "www.Google.com", null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("5ae86054-b6c8-4408-a0d3-fe3b060c53e9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "Permission.GetUserMenus", null, "获取用户菜单", 2, 0, null, null },
                    { new Guid("c58858e2-861c-4e06-8917-4d853ac86dfe"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "ProductMngmt", null, "产品管理", 1, 1, null, null },
                    { new Guid("3a394bcb-76ef-43fe-8bfc-e56016405c4d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "OrderingMngmt", null, "订单管理", 1, 2, null, null },
                    { new Guid("9b9c3ebb-f4fc-4347-a03e-5364bbee973d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "PaymentMngmt", null, "支付管理", 1, 3, null, null },
                    { new Guid("897335d5-562b-4e86-85e0-8aff46d01f7a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "SystemMngmt", null, "系统管理", 1, 4, null, null },
                    { new Guid("e4a756b3-34e9-45ef-b6e6-d831e05a7c82"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "PlatformMngmt", null, "平台管理", 1, 5, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("c119ac7b-2c52-40dc-93e2-7467623efa4f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c58858e2-861c-4e06-8917-4d853ac86dfe"), "ProductMngmt.Read", null, "查看", 2, 1, null, null },
                    { new Guid("0da1e306-9e27-41ea-af0a-4b492f21c45a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c58858e2-861c-4e06-8917-4d853ac86dfe"), "ProductMngmt.Add", null, "添加", 2, 2, null, null },
                    { new Guid("20816b2d-79ff-4731-8cf7-76e0c05e172e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c58858e2-861c-4e06-8917-4d853ac86dfe"), "ProductMngmt.Edit", null, "修改", 2, 3, null, null },
                    { new Guid("2c702c83-c8d4-41f5-a57e-64a770105538"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c58858e2-861c-4e06-8917-4d853ac86dfe"), "ProductMngmt.Delete", null, "删除", 2, 4, null, null },
                    { new Guid("84448bbd-1ada-458d-8c9f-799c07331e51"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("897335d5-562b-4e86-85e0-8aff46d01f7a"), "SystemMngmt.PermissionMngmt", null, "权限管理", 1, 1, null, null },
                    { new Guid("8f2a9f1d-dc12-45f2-8e0e-865e09d81968"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("897335d5-562b-4e86-85e0-8aff46d01f7a"), "SystemMngmt.JobMngmt", null, "任务管理", 1, 2, null, null },
                    { new Guid("aabe04af-602c-4dd4-9274-50a173ec6042"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("897335d5-562b-4e86-85e0-8aff46d01f7a"), "SystemMngmt.MessageMngmt", null, "消息管理", 1, 3, null, null },
                    { new Guid("539d1f4b-5555-4765-95d2-da9d4a5e67d1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("897335d5-562b-4e86-85e0-8aff46d01f7a"), "SystemMngmt.LogMngmt", null, "日志管理", 1, 4, null, null },
                    { new Guid("f29fc97f-79fc-4fc4-971f-fa41425acb6f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("e4a756b3-34e9-45ef-b6e6-d831e05a7c82"), "PlatformMngmt.ResourceMngmt", null, "资源管理", 1, 1, null, null },
                    { new Guid("ef83e251-ecec-4835-8acc-afd7284b2e2a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("e4a756b3-34e9-45ef-b6e6-d831e05a7c82"), "PlatformMngmt.TenantMngmt", null, "租户管理", 1, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("306f47d5-1ae0-4e1f-b192-b0487c8fbbed"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("0da1e306-9e27-41ea-af0a-4b492f21c45a"), "ProductMngmt.Add.AddBtn", null, "添加按钮", 3, 1, null, null },
                    { new Guid("ff494d37-c94c-487b-95bd-863a8bdaddb9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("84448bbd-1ada-458d-8c9f-799c07331e51"), "SystemMngmt.PermissionMngmt.RoleMngmt", null, "角色管理", 1, 1, null, null },
                    { new Guid("e4c2a130-cc9a-42df-a56f-ba173e05898d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("84448bbd-1ada-458d-8c9f-799c07331e51"), "SystemMngmt.PermissionMngmt.ScopeMngmt", null, "范围管理", 1, 2, null, null },
                    { new Guid("e66cf7c5-7679-4b30-8655-2b056f7b8513"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("84448bbd-1ada-458d-8c9f-799c07331e51"), "SystemMngmt.PermissionMngmt.AssignmnentMngmt", null, "授权管理", 1, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("b86aa3c8-0c2e-4f60-ac24-fb76ce513aad"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("ff494d37-c94c-487b-95bd-863a8bdaddb9"), "SystemMngmt.PermissionMngmt.RoleMngmt.Read", null, "查看", 2, 1, null, null },
                    { new Guid("66955fbc-a99d-4527-99af-ecf65124731b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("ff494d37-c94c-487b-95bd-863a8bdaddb9"), "SystemMngmt.PermissionMngmt.RoleMngmt.Update", null, "更改", 2, 2, null, null }
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
