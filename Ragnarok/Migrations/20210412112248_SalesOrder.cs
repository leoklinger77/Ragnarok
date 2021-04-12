using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class SalesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_SalesOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    RegisterEmployeeId = table.Column<int>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SalesOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_SalesOrder_TB_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TB_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_SalesOrder_TB_Employee_RegisterEmployeeId",
                        column: x => x.RegisterEmployeeId,
                        principalTable: "TB_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_SalesItem",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SalesItem", x => new { x.StockId, x.SalesOrderId });
                    table.ForeignKey(
                        name: "FK_TB_SalesItem_TB_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "TB_SalesOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_SalesItem_TB_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "TB_Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_SalesItem_SalesOrderId",
                table: "TB_SalesItem",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SalesOrder_ClientId",
                table: "TB_SalesOrder",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SalesOrder_RegisterEmployeeId",
                table: "TB_SalesOrder",
                column: "RegisterEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_SalesItem");

            migrationBuilder.DropTable(
                name: "TB_SalesOrder");
        }
    }
}
