using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class Cart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceCargo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCargo", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 4, 20, 23, 0, 58, 129, DateTimeKind.Local).AddTicks(4633));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceCargo");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2022, 4, 20, 22, 58, 56, 81, DateTimeKind.Local).AddTicks(8452));
        }
    }
}
