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
                    { new Guid("af5b4445-046f-4561-8310-556137bb82ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, "SYSTEM", null, "", "SYSTEM", "www.system.com", null, null },
                    { new Guid("1b89ac39-a25e-4d77-b6dc-1f37958276dd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, "MSFT", null, "", "Microsoft", "www.microsoft.com", null, null },
                    { new Guid("c7a749fa-f703-4e2f-b6ee-d0d66da58464"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, "GOOG", null, "", "Google", "www.Google.com", null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("f86d59fd-a5a3-4d56-b31b-59667ebc5878"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "ProductMngmt", null, "产品管理", 1, 1, null, null },
                    { new Guid("edf3f3bf-8e96-4da8-92f9-337c05224c7a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "OrderingMngmt", null, "订单管理", 1, 2, null, null },
                    { new Guid("ff605e09-3c8c-42f6-9715-202eccdbc13e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "PaymentMngmt", null, "支付管理", 1, 3, null, null },
                    { new Guid("52cda552-3ee6-4bd3-9c1d-f9aa9df4b660"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "SystemMngmt", null, "系统管理", 1, 4, null, null },
                    { new Guid("faf35762-96ec-4edf-9575-d87c632cb2fe"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "PlatformMngmt", null, "平台管理", 1, 5, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("c82bc08d-1130-441e-b224-2e71eb286ce9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("f86d59fd-a5a3-4d56-b31b-59667ebc5878"), "ProductMngmt.Read", null, "查看", 2, 1, null, null },
                    { new Guid("09daed1f-6028-4977-90d5-7a552ffd35e6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("f86d59fd-a5a3-4d56-b31b-59667ebc5878"), "ProductMngmt.Add", null, "添加", 2, 2, null, null },
                    { new Guid("59454a4e-a939-43fc-957e-4ba83e05ff22"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("f86d59fd-a5a3-4d56-b31b-59667ebc5878"), "ProductMngmt.Edit", null, "修改", 2, 3, null, null },
                    { new Guid("72c0ec72-3b0f-4f49-971a-a7a15430ca70"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("f86d59fd-a5a3-4d56-b31b-59667ebc5878"), "ProductMngmt.Delete", null, "删除", 2, 4, null, null },
                    { new Guid("61f0aeff-e6ac-465d-8a44-6db8d53d7e6a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("52cda552-3ee6-4bd3-9c1d-f9aa9df4b660"), "SystemMngmt.PermissionMngmt", null, "权限管理", 1, 1, null, null },
                    { new Guid("7d7d472e-43aa-449f-bf0e-68e157ae2fd0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("52cda552-3ee6-4bd3-9c1d-f9aa9df4b660"), "SystemMngmt.JobMngmt", null, "任务管理", 1, 2, null, null },
                    { new Guid("5c17f9ea-5b02-4cad-aa55-059ca51b8d39"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("52cda552-3ee6-4bd3-9c1d-f9aa9df4b660"), "SystemMngmt.MessageMngmt", null, "消息管理", 1, 3, null, null },
                    { new Guid("9e3765bc-6588-44f2-8f57-618412474deb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("52cda552-3ee6-4bd3-9c1d-f9aa9df4b660"), "SystemMngmt.LogMngmt", null, "日志管理", 1, 4, null, null },
                    { new Guid("ed281247-b146-46b9-9e9b-1e078a6e2332"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("faf35762-96ec-4edf-9575-d87c632cb2fe"), "PlatformMngmt.ResourceMngmt", null, "资源管理", 1, 1, null, null },
                    { new Guid("b591b07a-c116-4340-8905-fef63ce1030c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("faf35762-96ec-4edf-9575-d87c632cb2fe"), "PlatformMngmt.TenantMngmt", null, "租户管理", 1, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("23ffc1d4-7f8a-47de-bf72-db0329e46b83"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("09daed1f-6028-4977-90d5-7a552ffd35e6"), "ProductMngmt.Add.AddBtn", null, "添加按钮", 3, 1, null, null },
                    { new Guid("8ef840bf-6ba4-4b69-b7e5-3cd4a92942fd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("61f0aeff-e6ac-465d-8a44-6db8d53d7e6a"), "SystemMngmt.PermissionMngmt.RoleMngmt", null, "角色管理", 1, 1, null, null },
                    { new Guid("b8e13a80-4f5d-4a2e-8f1f-604905a77253"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("61f0aeff-e6ac-465d-8a44-6db8d53d7e6a"), "SystemMngmt.PermissionMngmt.ScopeMngmt", null, "范围管理", 1, 2, null, null },
                    { new Guid("b28025e0-c948-44a8-9f9d-060d5814a2e0"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("61f0aeff-e6ac-465d-8a44-6db8d53d7e6a"), "SystemMngmt.PermissionMngmt.AssignmnentMngmt", null, "授权管理", 1, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1bb55302-660c-408b-acf0-31b79879f706"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("8ef840bf-6ba4-4b69-b7e5-3cd4a92942fd"), "SystemMngmt.PermissionMngmt.RoleMngmt.Read", null, "查看", 2, 1, null, null },
                    { new Guid("18c63528-b090-49f3-8268-d254e34c520d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("8ef840bf-6ba4-4b69-b7e5-3cd4a92942fd"), "SystemMngmt.PermissionMngmt.RoleMngmt.Update", null, "更改", 2, 2, null, null }
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
