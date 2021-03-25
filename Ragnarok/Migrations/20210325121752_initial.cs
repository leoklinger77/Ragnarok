using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Sigle = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_City_TB_State_StateId",
                        column: x => x.StateId,
                        principalTable: "TB_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZipCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Complement = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Address_TB_City_CityId",
                        column: x => x.CityId,
                        principalTable: "TB_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    FantasyName = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    OpeningDate = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Business", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Business_TB_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TB_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PositionName",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PositionName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PositionName_TB_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "TB_Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Action = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    PositionNameId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Employee_TB_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TB_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Employee_TB_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "TB_Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TB_Employee_TB_PositionName_PositionNameId",
                        column: x => x.PositionNameId,
                        principalTable: "TB_PositionName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeNumber = table.Column<int>(nullable: false),
                    DDD = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Contact_TB_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "TB_Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Contact_TB_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TB_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Address_CityId",
                table: "TB_Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Business_AddressId",
                table: "TB_Business",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_City_StateId",
                table: "TB_City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Contact_BusinessId",
                table: "TB_Contact",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Contact_EmployeeId",
                table: "TB_Contact",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Employee_AddressId",
                table: "TB_Employee",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Employee_BusinessId",
                table: "TB_Employee",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Employee_PositionNameId",
                table: "TB_Employee",
                column: "PositionNameId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PositionName_BusinessId",
                table: "TB_PositionName",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Contact");

            migrationBuilder.DropTable(
                name: "TB_Employee");

            migrationBuilder.DropTable(
                name: "TB_PositionName");

            migrationBuilder.DropTable(
                name: "TB_Business");

            migrationBuilder.DropTable(
                name: "TB_Address");

            migrationBuilder.DropTable(
                name: "TB_City");

            migrationBuilder.DropTable(
                name: "TB_State");
        }
    }
}
