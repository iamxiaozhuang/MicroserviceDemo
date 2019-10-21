using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionService.Domain.Migrations
{
    public partial class _201910211757 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SortNo",
                table: "Scope",
                newName: "SortNO");

            migrationBuilder.RenameColumn(
                name: "SortNo",
                table: "Role",
                newName: "SortNO");

            migrationBuilder.RenameColumn(
                name: "SortNo",
                table: "Resource",
                newName: "SortNO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SortNO",
                table: "Scope",
                newName: "SortNo");

            migrationBuilder.RenameColumn(
                name: "SortNO",
                table: "Role",
                newName: "SortNo");

            migrationBuilder.RenameColumn(
                name: "SortNO",
                table: "Resource",
                newName: "SortNo");
        }
    }
}
