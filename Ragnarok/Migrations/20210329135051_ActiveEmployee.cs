using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class ActiveEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "TB_Employee");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TB_Employee",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TB_Employee");

            migrationBuilder.AddColumn<bool>(
                name: "Action",
                table: "TB_Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
