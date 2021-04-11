using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class EmployeeRegisterDiscountStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisterEmployeeId",
                table: "TB_DiscountProduct",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_DiscountProduct_RegisterEmployeeId",
                table: "TB_DiscountProduct",
                column: "RegisterEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_DiscountProduct_TB_Employee_RegisterEmployeeId",
                table: "TB_DiscountProduct",
                column: "RegisterEmployeeId",
                principalTable: "TB_Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_DiscountProduct_TB_Employee_RegisterEmployeeId",
                table: "TB_DiscountProduct");

            migrationBuilder.DropIndex(
                name: "IX_TB_DiscountProduct_RegisterEmployeeId",
                table: "TB_DiscountProduct");

            migrationBuilder.DropColumn(
                name: "RegisterEmployeeId",
                table: "TB_DiscountProduct");
        }
    }
}
