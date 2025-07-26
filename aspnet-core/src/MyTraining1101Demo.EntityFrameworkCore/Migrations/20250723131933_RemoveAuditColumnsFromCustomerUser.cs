using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraining1101Demo.Migrations
{
    public partial class RemoveAuditColumnsFromCustomerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "CustomerUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "CustomerUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "CustomerUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "CustomerUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "CustomerUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
