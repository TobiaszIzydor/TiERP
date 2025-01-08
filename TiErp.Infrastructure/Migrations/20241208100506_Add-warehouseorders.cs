using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TiErp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addwarehouseorders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayrolls_Employees_EmployeeId",
                table: "EmployeePayrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionItems_Products_ProductID",
                table: "ProductionItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductionItems_ProductID",
                table: "ProductionItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePayrolls",
                table: "EmployeePayrolls");

            migrationBuilder.RenameTable(
                name: "EmployeePayrolls",
                newName: "EmployeePayroll");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePayrolls_EmployeeId",
                table: "EmployeePayroll",
                newName: "IX_EmployeePayroll_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePayroll",
                table: "EmployeePayroll",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductProductionItem",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductionItemsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductionItem", x => new { x.ProductId, x.ProductionItemsId });
                    table.ForeignKey(
                        name: "FK_ProductProductionItem_ProductionItems_ProductionItemsId",
                        column: x => x.ProductionItemsId,
                        principalTable: "ProductionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductionItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeliveryToLineId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseOrders_ProductionLines_DeliveryToLineId",
                        column: x => x.DeliveryToLineId,
                        principalTable: "ProductionLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseOrdersItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    WarehouseOrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseOrdersItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseOrdersItems_ProductionItems_ProductionItemId",
                        column: x => x.ProductionItemId,
                        principalTable: "ProductionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehouseOrdersItems_WarehouseOrders_WarehouseOrderId",
                        column: x => x.WarehouseOrderId,
                        principalTable: "WarehouseOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductionItem_ProductionItemsId",
                table: "ProductProductionItem",
                column: "ProductionItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseOrders_DeliveryToLineId",
                table: "WarehouseOrders",
                column: "DeliveryToLineId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseOrdersItems_ProductionItemId",
                table: "WarehouseOrdersItems",
                column: "ProductionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseOrdersItems_WarehouseOrderId",
                table: "WarehouseOrdersItems",
                column: "WarehouseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayroll_Employees_EmployeeId",
                table: "EmployeePayroll",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayroll_Employees_EmployeeId",
                table: "EmployeePayroll");

            migrationBuilder.DropTable(
                name: "ProductProductionItem");

            migrationBuilder.DropTable(
                name: "WarehouseOrdersItems");

            migrationBuilder.DropTable(
                name: "WarehouseOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePayroll",
                table: "EmployeePayroll");

            migrationBuilder.RenameTable(
                name: "EmployeePayroll",
                newName: "EmployeePayrolls");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePayroll_EmployeeId",
                table: "EmployeePayrolls",
                newName: "IX_EmployeePayrolls_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePayrolls",
                table: "EmployeePayrolls",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionItems_ProductID",
                table: "ProductionItems",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayrolls_Employees_EmployeeId",
                table: "EmployeePayrolls",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionItems_Products_ProductID",
                table: "ProductionItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
