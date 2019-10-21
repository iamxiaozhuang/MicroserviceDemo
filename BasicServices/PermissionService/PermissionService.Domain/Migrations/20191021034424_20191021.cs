using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionService.Domain.Migrations
{
    public partial class _20191021 : Migration
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
                name: "Resource",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TenantCode = table.Column<string>(nullable: false),
                    CreateIn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdateIn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    OwnerScopeCode = table.Column<string>(nullable: true),
                    ResourceCode = table.Column<string>(nullable: false),
                    FullResourceCode = table.Column<string>(nullable: false),
                    ResourceName = table.Column<string>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    ParentResourceID = table.Column<Guid>(nullable: false),
                    SortNo = table.Column<int>(nullable: false),
                    ResourceDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => new { x.TenantCode, x.ID });
                    table.ForeignKey(
                        name: "FK_Resource_Resource_TenantCode_ParentResourceID",
                        columns: x => new { x.TenantCode, x.ParentResourceID },
                        principalTable: "Resource",
                        principalColumns: new[] { "TenantCode", "ID" },
                        onDelete: ReferentialAction.Cascade);
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
                    SortNo = table.Column<int>(nullable: false),
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
                    FullScopeCode = table.Column<string>(nullable: false),
                    ScopeName = table.Column<string>(nullable: false),
                    ParentScopeID = table.Column<Guid>(nullable: false),
                    SortNo = table.Column<int>(nullable: false),
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
                    ResourceID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.TenantCode, x.ID });
                    table.ForeignKey(
                        name: "FK_RolePermission_Resource_TenantCode_ResourceID",
                        columns: x => new { x.TenantCode, x.ResourceID },
                        principalTable: "Resource",
                        principalColumns: new[] { "TenantCode", "ID" },
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Resource_TenantCode",
                table: "Resource",
                column: "TenantCode");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_TenantCode_ParentResourceID",
                table: "Resource",
                columns: new[] { "TenantCode", "ParentResourceID" });

            migrationBuilder.CreateIndex(
                name: "IX_Resource_TenantCode_ResourceCode",
                table: "Resource",
                columns: new[] { "TenantCode", "ResourceCode" },
                unique: true);

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
                name: "IX_RolePermission_TenantCode_ResourceID",
                table: "RolePermission",
                columns: new[] { "TenantCode", "ResourceID" });

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
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
