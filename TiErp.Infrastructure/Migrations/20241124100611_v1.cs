using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TiErp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayroll_Employees_EmployeeId",
                table: "EmployeePayroll");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Employees_EmployeeId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePayroll",
                table: "EmployeePayroll");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "EmployeePayroll",
                newName: "EmployeePayrolls");

            migrationBuilder.RenameIndex(
                name: "IX_User_EmployeeId",
                table: "Users",
                newName: "IX_Users_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePayroll_EmployeeId",
                table: "EmployeePayrolls",
                newName: "IX_EmployeePayrolls_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserRole",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ProductionLineId",
                table: "Employees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "EmployeePayrolls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePayrolls",
                table: "EmployeePayrolls",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LineLiderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionLines_Users_LineLiderId",
                        column: x => x.LineLiderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeadLine = table.Column<DateOnly>(type: "date", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    ProductionLineId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ProductionLines_ProductionLineId",
                        column: x => x.ProductionLineId,
                        principalTable: "ProductionLines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProductionLineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductionLines_ProductionLineId",
                        column: x => x.ProductionLineId,
                        principalTable: "ProductionLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EAN11 = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    WareHouseLocationCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProductionLineId",
                table: "Employees",
                column: "ProductionLineId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductionLineId",
                table: "Orders",
                column: "ProductionLineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionItems_ProductID",
                table: "ProductionItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionLines_LineLiderId",
                table: "ProductionLines",
                column: "LineLiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductionLineId",
                table: "Products",
                column: "ProductionLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayrolls_Employees_EmployeeId",
                table: "EmployeePayrolls",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ProductionLines_ProductionLineId",
                table: "Employees",
                column: "ProductionLineId",
                principalTable: "ProductionLines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayrolls_Employees_EmployeeId",
                table: "EmployeePayrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ProductionLines_ProductionLineId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductionItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductionLines");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProductionLineId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePayrolls",
                table: "EmployeePayrolls");

            migrationBuilder.DropColumn(
                name: "ProductionLineId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "EmployeePayrolls");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "EmployeePayrolls",
                newName: "EmployeePayroll");

            migrationBuilder.RenameIndex(
                name: "IX_Users_EmployeeId",
                table: "User",
                newName: "IX_User_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePayrolls_EmployeeId",
                table: "EmployeePayroll",
                newName: "IX_EmployeePayroll_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserRole",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePayroll",
                table: "EmployeePayroll",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayroll_Employees_EmployeeId",
                table: "EmployeePayroll",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Employees_EmployeeId",
                table: "User",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
