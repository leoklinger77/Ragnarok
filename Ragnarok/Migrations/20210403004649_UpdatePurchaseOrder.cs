using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class UpdatePurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PurchaseOrder_TB_Employee_EmployeeId",
                table: "TB_PurchaseOrder");

            migrationBuilder.DropIndex(
                name: "IX_TB_PurchaseOrder_EmployeeId",
                table: "TB_PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TB_PurchaseOrder");

            migrationBuilder.AddColumn<int>(
                name: "RegisterEmployeeId",
                table: "TB_PurchaseOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PurchaseOrder_RegisterEmployeeId",
                table: "TB_PurchaseOrder",
                column: "RegisterEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PurchaseOrder_TB_Employee_RegisterEmployeeId",
                table: "TB_PurchaseOrder",
                column: "RegisterEmployeeId",
                principalTable: "TB_Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PurchaseOrder_TB_Employee_RegisterEmployeeId",
                table: "TB_PurchaseOrder");

            migrationBuilder.DropIndex(
                name: "IX_TB_PurchaseOrder_RegisterEmployeeId",
                table: "TB_PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "RegisterEmployeeId",
                table: "TB_PurchaseOrder");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "TB_PurchaseOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PurchaseOrder_EmployeeId",
                table: "TB_PurchaseOrder",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PurchaseOrder_TB_Employee_EmployeeId",
                table: "TB_PurchaseOrder",
                column: "EmployeeId",
                principalTable: "TB_Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
