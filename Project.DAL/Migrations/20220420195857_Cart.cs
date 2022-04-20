using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 4, 20, 22, 58, 56, 81, DateTimeKind.Local).AddTicks(8452));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 4, 18, 20, 59, 55, 471, DateTimeKind.Local).AddTicks(8064));
        }
    }
}
