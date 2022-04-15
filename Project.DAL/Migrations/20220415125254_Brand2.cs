using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class Brand2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Brand");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Brand",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 4, 15, 15, 52, 54, 376, DateTimeKind.Local).AddTicks(1642));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Brand");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Brand",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 4, 15, 15, 17, 30, 187, DateTimeKind.Local).AddTicks(5370));
        }
    }
}
