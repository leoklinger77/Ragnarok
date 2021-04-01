using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class SupplierCorrectionTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierPhysical_FantasyName",
                table: "TB_Supplier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupplierPhysical_FantasyName",
                table: "TB_Supplier",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
