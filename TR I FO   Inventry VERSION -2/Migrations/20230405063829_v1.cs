using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TR_I_FO___Inventry_VERSION__2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportItems",
                columns: table => new
                {
                    Import = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sProduct_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    d_Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_quantity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportItems", x => x.Import);
                });

            migrationBuilder.CreateTable(
                name: "memo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Shop_prd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sProduct_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buy_Price = table.Column<double>(type: "float", nullable: false),
                    Sell_Price = table.Column<double>(type: "float", nullable: false),
                    profit = table.Column<double>(type: "float", nullable: false),
                    sPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sell_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_mobiler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Shop_prd_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    Ware_prd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buy_Price = table.Column<double>(type: "float", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buy_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouse", x => x.Ware_prd_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportItems");

            migrationBuilder.DropTable(
                name: "memo");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WareHouse");
        }
    }
}
