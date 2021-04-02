using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class ProductAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RegisterEmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Category_TB_Employee_RegisterEmployeeId",
                        column: x => x.RegisterEmployeeId,
                        principalTable: "TB_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    RegisterEmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Product_TB_Employee_RegisterEmployeeId",
                        column: x => x.RegisterEmployeeId,
                        principalTable: "TB_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_CategoryProduct",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CategoryProduct", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_TB_CategoryProduct_TB_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TB_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_CategoryProduct_TB_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TB_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Category_RegisterEmployeeId",
                table: "TB_Category",
                column: "RegisterEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CategoryProduct_ProductId",
                table: "TB_CategoryProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Product_RegisterEmployeeId",
                table: "TB_Product",
                column: "RegisterEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CategoryProduct");

            migrationBuilder.DropTable(
                name: "TB_Category");

            migrationBuilder.DropTable(
                name: "TB_Product");
        }
    }
}
