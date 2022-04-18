using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class Comment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogID",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPNo",
                table: "Comment",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 4, 18, 20, 59, 55, 471, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BlogID",
                table: "Comment",
                column: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Blog_BlogID",
                table: "Comment",
                column: "BlogID",
                principalTable: "Blog",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Blog_BlogID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_BlogID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "BlogID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "IPNo",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "RecDate",
                table: "Comment");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 4, 18, 16, 27, 24, 738, DateTimeKind.Local).AddTicks(5148));
        }
    }
}
