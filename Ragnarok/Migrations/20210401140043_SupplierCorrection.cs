using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class SupplierCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierPhysical_FullName",
                table: "TB_Supplier");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TB_Supplier",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "TB_Supplier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierPhysical_FantasyName",
                table: "TB_Supplier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "TB_Supplier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TB_Supplier");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "TB_Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierPhysical_FantasyName",
                table: "TB_Supplier");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "TB_Supplier");

            migrationBuilder.AddColumn<string>(
                name: "SupplierPhysical_FullName",
                table: "TB_Supplier",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
