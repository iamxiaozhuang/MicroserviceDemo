using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductService.Domain.Migrations
{
    public partial class _20191205 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantCode = table.Column<string>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerScopeCode = table.Column<string>(nullable: true),
                    CategoryCode = table.Column<string>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => new { x.TenantCode, x.ID });
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
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantCode = table.Column<string>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerScopeCode = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    ProductAmount = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ProductProfile = table.Column<string>(type: "json", nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => new { x.TenantCode, x.ID });
                    table.ForeignKey(
                        name: "FK_Product_Category_TenantCode_CategoryId",
                        columns: x => new { x.TenantCode, x.CategoryId },
                        principalTable: "Category",
                        principalColumns: new[] { "TenantCode", "ID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AttachmentName = table.Column<string>(nullable: false),
                    AttachmentUrl = table.Column<string>(nullable: false),
                    AttachmentSort = table.Column<int>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: true),
                    ProductTenantCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attachment_Product_ProductTenantCode_ProductID",
                        columns: x => new { x.ProductTenantCode, x.ProductID },
                        principalTable: "Product",
                        principalColumns: new[] { "TenantCode", "ID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "TenantCode", "ID", "CategoryCode", "CategoryName", "CreateIn", "CreatedBy", "OwnerScopeCode", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("c01487e5-2e75-40c8-98f9-2a3b06ae5dae"), "cate1", "商品类别1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", null, null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "TenantCode", "ID", "CategoryId", "CreateIn", "CreatedBy", "OwnerScopeCode", "ProductAmount", "ProductCode", "ProductName", "ProductPrice", "ProductProfile", "UpdateIn", "UpdatedBy" },
                values: new object[] { "SYSTEM", new Guid("27b91419-3ae9-430a-8309-948fa94007a7"), new Guid("c01487e5-2e75-40c8-98f9-2a3b06ae5dae"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "", 100, "product1", "商品1", 60m, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ProductTenantCode_ProductID",
                table: "Attachment",
                columns: new[] { "ProductTenantCode", "ProductID" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_TenantCode",
                table: "Category",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_Category_TenantCode_CategoryCode",
                table: "Category",
                columns: new[] { "TenantCode", "CategoryCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_TenantCode",
                table: "Product",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TenantCode_CategoryId",
                table: "Product",
                columns: new[] { "TenantCode", "CategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_TenantCode_ProductCode",
                table: "Product",
                columns: new[] { "TenantCode", "ProductCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recycle_TenantCode",
                table: "Recycle",
                column: "TenantCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Recycle");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
