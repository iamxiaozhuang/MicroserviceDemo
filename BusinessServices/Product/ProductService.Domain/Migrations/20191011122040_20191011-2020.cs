using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductService.Domain.Migrations
{
    public partial class _201910112020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AttachmentSort",
                table: "Attachment",
                nullable: false,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AttachmentSort",
                table: "Attachment",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
