using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ragnarok.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DiscountProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountAmount = table.Column<double>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DiscountProduct", x => x.Id);
                });

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
                    Name = table.Column<string>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Complement = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Address_TB_City_CityId",
                        column: x => x.CityId,
                        principalTable: "TB_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    PositionNameId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    RegisterEmployeeId = table.Column<int>(nullable: true),
                    PathImage = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Employee_TB_PositionName_PositionNameId",
                        column: x => x.PositionNameId,
                        principalTable: "TB_PositionName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Employee_TB_Employee_RegisterEmployeeId",
                        column: x => x.RegisterEmployeeId,
                        principalTable: "TB_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "TB_Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    RegisterEmployeeId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    FantasyName = table.Column<string>(nullable: true),
                    OpeningDate = table.Column<DateTime>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Sexo = table.Column<int>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    CPF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Client_TB_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TB_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Client_TB_Employee_RegisterEmployeeId",
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
                    Name = table.Column<string>(nullable: false),
                    BarCode = table.Column<string>(maxLength: 13, nullable: false),
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
                name: "TB_Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    RegisterEmployeeId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    FantasyName = table.Column<string>(nullable: true),
                    OpeningDate = table.Column<DateTime>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    Sexo = table.Column<int>(nullable: true),
                    CPF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Supplier_TB_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TB_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Supplier_TB_Employee_RegisterEmployeeId",
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

            migrationBuilder.CreateTable(
                name: "TB_Stock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ValidationDate = table.Column<DateTime>(nullable: true),
                    SalesPrice = table.Column<double>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Stock_TB_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TB_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeNumber = table.Column<int>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    ClientId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    DDD = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
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
                        name: "FK_TB_Contact_TB_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TB_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Contact_TB_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TB_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Contact_TB_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TB_Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    RegisterEmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PurchaseOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PurchaseOrder_TB_Employee_RegisterEmployeeId",
                        column: x => x.RegisterEmployeeId,
                        principalTable: "TB_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_PurchaseOrder_TB_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TB_Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_DiscontStock",
                columns: table => new
                {
                    StockId = table.Column<int>(nullable: false),
                    DiscountProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DiscontStock", x => new { x.StockId, x.DiscountProductId });
                    table.ForeignKey(
                        name: "FK_TB_DiscontStock_TB_DiscountProduct_DiscountProductId",
                        column: x => x.DiscountProductId,
                        principalTable: "TB_DiscountProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_DiscontStock_TB_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "TB_Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_PurchaseItemOrder",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    PurchasePrice = table.Column<double>(nullable: false),
                    SalesPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    ValidationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PurchaseItemOrder", x => new { x.ProductId, x.PurchaseOrderId });
                    table.ForeignKey(
                        name: "FK_TB_PurchaseItemOrder_TB_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TB_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_PurchaseItemOrder_TB_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "TB_PurchaseOrder",
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
                name: "IX_TB_Category_RegisterEmployeeId",
                table: "TB_Category",
                column: "RegisterEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CategoryProduct_ProductId",
                table: "TB_CategoryProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_City_StateId",
                table: "TB_City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Client_AddressId",
                table: "TB_Client",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Client_RegisterEmployeeId",
                table: "TB_Client",
                column: "RegisterEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Contact_BusinessId",
                table: "TB_Contact",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Contact_ClientId",
                table: "TB_Contact",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Contact_EmployeeId",
                table: "TB_Contact",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Contact_SupplierId",
                table: "TB_Contact",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DiscontStock_DiscountProductId",
                table: "TB_DiscontStock",
                column: "DiscountProductId");

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
                name: "IX_TB_Employee_RegisterEmployeeId",
                table: "TB_Employee",
                column: "RegisterEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PositionName_BusinessId",
                table: "TB_PositionName",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Product_RegisterEmployeeId",
                table: "TB_Product",
                column: "RegisterEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PurchaseItemOrder_PurchaseOrderId",
                table: "TB_PurchaseItemOrder",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PurchaseOrder_RegisterEmployeeId",
                table: "TB_PurchaseOrder",
                column: "RegisterEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PurchaseOrder_SupplierId",
                table: "TB_PurchaseOrder",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Stock_ProductId",
                table: "TB_Stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Supplier_AddressId",
                table: "TB_Supplier",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Supplier_RegisterEmployeeId",
                table: "TB_Supplier",
                column: "RegisterEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CategoryProduct");

            migrationBuilder.DropTable(
                name: "TB_Contact");

            migrationBuilder.DropTable(
                name: "TB_DiscontStock");

            migrationBuilder.DropTable(
                name: "TB_PurchaseItemOrder");

            migrationBuilder.DropTable(
                name: "TB_Category");

            migrationBuilder.DropTable(
                name: "TB_Client");

            migrationBuilder.DropTable(
                name: "TB_DiscountProduct");

            migrationBuilder.DropTable(
                name: "TB_Stock");

            migrationBuilder.DropTable(
                name: "TB_PurchaseOrder");

            migrationBuilder.DropTable(
                name: "TB_Product");

            migrationBuilder.DropTable(
                name: "TB_Supplier");

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
