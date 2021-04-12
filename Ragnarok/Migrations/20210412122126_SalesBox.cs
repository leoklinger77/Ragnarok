using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class SalesBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SalesOrder_TB_Employee_RegisterEmployeeId",
                table: "TB_SalesOrder");

            migrationBuilder.DropIndex(
                name: "IX_TB_SalesOrder_RegisterEmployeeId",
                table: "TB_SalesOrder");

            migrationBuilder.DropColumn(
                name: "RegisterEmployeeId",
                table: "TB_SalesOrder");

            migrationBuilder.AddColumn<int>(
                name: "SaleBoxId",
                table: "TB_SalesOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_SaleBox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opening = table.Column<DateTime>(nullable: false),
                    Clouse = table.Column<DateTime>(nullable: true),
                    ApertureValue = table.Column<double>(nullable: false),
                    ClosingValue = table.Column<double>(nullable: false),
                    RegisterSalesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SaleBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_SaleBox_TB_Employee_RegisterSalesId",
                        column: x => x.RegisterSalesId,
                        principalTable: "TB_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_SalesOrder_SaleBoxId",
                table: "TB_SalesOrder",
                column: "SaleBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SaleBox_RegisterSalesId",
                table: "TB_SaleBox",
                column: "RegisterSalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SalesOrder_TB_SaleBox_SaleBoxId",
                table: "TB_SalesOrder",
                column: "SaleBoxId",
                principalTable: "TB_SaleBox",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SalesOrder_TB_SaleBox_SaleBoxId",
                table: "TB_SalesOrder");

            migrationBuilder.DropTable(
                name: "TB_SaleBox");

            migrationBuilder.DropIndex(
                name: "IX_TB_SalesOrder_SaleBoxId",
                table: "TB_SalesOrder");

            migrationBuilder.DropColumn(
                name: "SaleBoxId",
                table: "TB_SalesOrder");

            migrationBuilder.AddColumn<int>(
                name: "RegisterEmployeeId",
                table: "TB_SalesOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_SalesOrder_RegisterEmployeeId",
                table: "TB_SalesOrder",
                column: "RegisterEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SalesOrder_TB_Employee_RegisterEmployeeId",
                table: "TB_SalesOrder",
                column: "RegisterEmployeeId",
                principalTable: "TB_Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
