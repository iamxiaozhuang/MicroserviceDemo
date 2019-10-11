using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductService.Domain.Migrations
{
    public partial class _20191011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateIn",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "TenantCode",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "UpdateIn",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Attachment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateIn",
                table: "Attachment",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Attachment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantCode",
                table: "Attachment",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateIn",
                table: "Attachment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Attachment",
                nullable: true);
        }
    }
}
