using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemService.Domain.Migrations
{
    public partial class _20191205 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("17c7f6f9-0d34-4b16-9e6a-3b05638b8afe"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("253e85e9-35ac-459e-bb5c-662c3e680c3f"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("2ce185a5-8095-4276-90b8-d4554682851e"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("340baee6-c56e-4b47-8f32-0445a9c3331d"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("3e1ac31b-2459-43ad-b4b7-65c409ac527a"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("58ff99ee-1ad9-4cfe-8407-74fbb494fff7"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("7d64baf8-43a0-4c02-bf66-c13a91fb0198"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("7ed38fa3-6314-43f4-a3c3-9f2a1b4f96ad"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("85312b0a-fc1f-43a2-8dc6-50266fc99cc1"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("8c0debaa-33a9-421e-b29a-a2da0cb4ce78"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("ab427912-168e-42d7-8ace-a99b4f3b0e9c"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("c4a3567b-bc52-4406-88dd-eac55a31e891"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("d0c9d91d-145d-4941-9a8f-f75083feaf66"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("e1a98928-e0d3-413a-b516-c1b9021316e2"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("fd10e54b-2e87-4abc-becd-3b39882413bd"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("fd87a982-d757-44b6-a2e4-6bba177f2448"));

            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "ID",
                keyValue: new Guid("52695b8c-6033-4e22-b177-a70838a5f69c"));

            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "ID",
                keyValue: new Guid("b11547c4-8dd7-4184-b3a8-96a9f3a7b955"));

            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "ID",
                keyValue: new Guid("b6abe819-c9f8-48ed-8fa2-d28faf7557b4"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("22f7aaeb-8a5e-448d-a53c-ab8bc11aba79"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("ab944839-be7d-4184-98dd-1292011c1a1e"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("3c9a3c21-daf2-4653-8034-88ec946d36ca"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("3feae607-8c67-4870-ad7b-9f7a685d4db8"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("eee46887-62a2-4d55-b8cf-77c096339d14"));

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("577e036b-575b-4d69-a010-d2f5e7d9b4a5"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "Permission.GetUserMenus", null, "获取用户菜单", 2, 0, null, null },
                    { new Guid("6978bb6e-5228-4dda-a482-5f9400d32c7b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "ProductMngmt", null, "产品管理", 1, 1, null, null },
                    { new Guid("8e0f2af2-8ec5-4c38-8eca-7006d7e83442"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "OrderingMngmt", null, "订单管理", 1, 2, null, null },
                    { new Guid("8013948f-4ac9-4d26-ac99-7267919c650b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "PaymentMngmt", null, "支付管理", 1, 3, null, null },
                    { new Guid("3bc345c7-481a-4c28-a1b7-3577ad49744c"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("88888888-8888-8888-8888-888888888888"), "SystemMngmt", null, "系统管理", 1, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "SortNO", "TenantCode", "TenantDesc", "TenantLogo", "TenantName", "TenantUrl", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("aae4c778-f81d-4298-9976-ecf6c393cd5f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, "SYSTEM", null, "", "SYSTEM", "www.system.com", null, null },
                    { new Guid("3c94b4fc-bbe4-49ba-bb76-5fdef43d6189"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, "MSFT", null, "", "Microsoft", "www.microsoft.com", null, null },
                    { new Guid("e0a3cd12-060c-4f70-aaab-577fd0758ada"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, "GOOG", null, "", "Google", "www.Google.com", null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("a1543d7c-f8fe-4b7f-886c-99d2d3972dd4"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("6978bb6e-5228-4dda-a482-5f9400d32c7b"), "ProductMngmt.Read", null, "查看", 2, 1, null, null },
                    { new Guid("1efb53a5-f4e7-4eff-ac08-95e38a281338"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("6978bb6e-5228-4dda-a482-5f9400d32c7b"), "ProductMngmt.Add", null, "添加", 2, 2, null, null },
                    { new Guid("11c255af-1df9-4859-90ae-0afbc612de0b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("6978bb6e-5228-4dda-a482-5f9400d32c7b"), "ProductMngmt.Edit", null, "修改", 2, 3, null, null },
                    { new Guid("830748de-9845-4d16-ac28-0b3038c95611"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("6978bb6e-5228-4dda-a482-5f9400d32c7b"), "ProductMngmt.Delete", null, "删除", 2, 4, null, null },
                    { new Guid("038246ef-76bd-49a1-a7a3-34058e2c188e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("6978bb6e-5228-4dda-a482-5f9400d32c7b"), "basket.createorder", null, "购物车下单", 2, 5, null, null },
                    { new Guid("8d1f1875-55bb-410d-866a-569fcd38b335"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("8e0f2af2-8ec5-4c38-8eca-7006d7e83442"), "ordering.add", null, "新增订单", 2, 1, null, null },
                    { new Guid("7f8622f8-5bcf-409c-b5ce-a25e5dcca686"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3bc345c7-481a-4c28-a1b7-3577ad49744c"), "SystemMngmt.PermissionMngmt", null, "权限管理", 1, 1, null, null },
                    { new Guid("ae31e978-5945-4875-b323-bb985f820cc8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3bc345c7-481a-4c28-a1b7-3577ad49744c"), "SystemMngmt.JobMngmt", null, "任务管理", 1, 2, null, null },
                    { new Guid("40ae4f08-8f14-469f-abf9-f7ea5ec820cc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3bc345c7-481a-4c28-a1b7-3577ad49744c"), "SystemMngmt.MessageMngmt", null, "消息管理", 1, 3, null, null },
                    { new Guid("691d77d0-27bf-45da-97ed-88eb120404da"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3bc345c7-481a-4c28-a1b7-3577ad49744c"), "SystemMngmt.CacheMngmt", null, "缓存管理", 1, 3, null, null },
                    { new Guid("3b32412c-5926-4bb1-9e18-87200887b739"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("3bc345c7-481a-4c28-a1b7-3577ad49744c"), "SystemMngmt.LogMngmt", null, "日志管理", 1, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("830f0974-b564-4530-97c4-705842861885"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("1efb53a5-f4e7-4eff-ac08-95e38a281338"), "ProductMngmt.Add.AddBtn", null, "添加按钮", 3, 1, null, null },
                    { new Guid("7560fc1f-6eae-4497-be4b-7f30414e6d74"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7f8622f8-5bcf-409c-b5ce-a25e5dcca686"), "SystemMngmt.PermissionMngmt.RoleMngmt", null, "角色管理", 1, 1, null, null },
                    { new Guid("319f4ff1-8d7d-465b-9a57-3d143c168c13"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7f8622f8-5bcf-409c-b5ce-a25e5dcca686"), "SystemMngmt.PermissionMngmt.ScopeMngmt", null, "范围管理", 1, 2, null, null },
                    { new Guid("a5906456-8f34-47a1-ae26-1c5d1f13862f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7f8622f8-5bcf-409c-b5ce-a25e5dcca686"), "SystemMngmt.PermissionMngmt.UserMngmt", null, "用户管理", 1, 2, null, null },
                    { new Guid("731cd4e1-67c5-448f-bd96-2d50f4fcfce1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7f8622f8-5bcf-409c-b5ce-a25e5dcca686"), "SystemMngmt.PermissionMngmt.AssignmnentMngmt", null, "授权管理", 1, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "Resource",
                columns: new[] { "ID", "CreateIn", "CreatedBy", "ParentResourceID", "ResourceCode", "ResourceDesc", "ResourceName", "ResourceType", "SortNO", "UpdateIn", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("fbb9c4a1-c91f-4a75-b629-2cbcb5c1afda"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7560fc1f-6eae-4497-be4b-7f30414e6d74"), "SystemMngmt.PermissionMngmt.RoleMngmt.Read", null, "查看", 2, 1, null, null },
                    { new Guid("027a07bd-6458-42d2-bef2-ae1210f345d6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7560fc1f-6eae-4497-be4b-7f30414e6d74"), "SystemMngmt.PermissionMngmt.RoleMngmt.Update", null, "更改", 2, 2, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("027a07bd-6458-42d2-bef2-ae1210f345d6"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("038246ef-76bd-49a1-a7a3-34058e2c188e"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("11c255af-1df9-4859-90ae-0afbc612de0b"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("319f4ff1-8d7d-465b-9a57-3d143c168c13"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("3b32412c-5926-4bb1-9e18-87200887b739"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("40ae4f08-8f14-469f-abf9-f7ea5ec820cc"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("577e036b-575b-4d69-a010-d2f5e7d9b4a5"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("691d77d0-27bf-45da-97ed-88eb120404da"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("731cd4e1-67c5-448f-bd96-2d50f4fcfce1"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("8013948f-4ac9-4d26-ac99-7267919c650b"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("830748de-9845-4d16-ac28-0b3038c95611"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("830f0974-b564-4530-97c4-705842861885"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("8d1f1875-55bb-410d-866a-569fcd38b335"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("a1543d7c-f8fe-4b7f-886c-99d2d3972dd4"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("a5906456-8f34-47a1-ae26-1c5d1f13862f"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("ae31e978-5945-4875-b323-bb985f820cc8"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("fbb9c4a1-c91f-4a75-b629-2cbcb5c1afda"));

            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "ID",
                keyValue: new Guid("3c94b4fc-bbe4-49ba-bb76-5fdef43d6189"));

            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "ID",
                keyValue: new Guid("aae4c778-f81d-4298-9976-ecf6c393cd5f"));

            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "ID",
                keyValue: new Guid("e0a3cd12-060c-4f70-aaab-577fd0758ada"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("1efb53a5-f4e7-4eff-ac08-95e38a281338"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("7560fc1f-6eae-4497-be4b-7f30414e6d74"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("8e0f2af2-8ec5-4c38-8eca-7006d7e83442"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("6978bb6e-5228-4dda-a482-5f9400d32c7b"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("7f8622f8-5bcf-409c-b5ce-a25e5dcca686"));

            migrationBuilder.DeleteData(
                table: "Resource",
                keyColumn: "ID",
                keyValue: new Guid("3bc345c7-481a-4c28-a1b7-3577ad49744c"));

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
        }
    }
}
