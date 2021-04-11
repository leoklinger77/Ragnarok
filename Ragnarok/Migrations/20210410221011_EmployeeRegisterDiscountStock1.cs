using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class EmployeeRegisterDiscountStock1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_DiscountProduct_TB_Employee_RegisterEmployeeId",
                table: "TB_DiscountProduct");

            migrationBuilder.AlterColumn<int>(
                name: "RegisterEmployeeId",
                table: "TB_DiscountProduct",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "RegisterEmployeeId",
                table: "TB_DiscountProduct",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TB_DiscountProduct_TB_Employee_RegisterEmployeeId",
                table: "TB_DiscountProduct",
                column: "RegisterEmployeeId",
                principalTable: "TB_Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
