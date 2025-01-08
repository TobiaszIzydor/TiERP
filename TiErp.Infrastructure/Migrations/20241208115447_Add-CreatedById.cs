using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiErp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ProductionLines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ProductionItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionLines_CreatedById",
                table: "ProductionLines",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionItems_CreatedById",
                table: "ProductionItems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedById",
                table: "Orders",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionItems_AspNetUsers_CreatedById",
                table: "ProductionItems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionLines_AspNetUsers_CreatedById",
                table: "ProductionLines",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedById",
                table: "Products",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionItems_AspNetUsers_CreatedById",
                table: "ProductionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionLines_AspNetUsers_CreatedById",
                table: "ProductionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductionLines_CreatedById",
                table: "ProductionLines");

            migrationBuilder.DropIndex(
                name: "IX_ProductionItems_CreatedById",
                table: "ProductionItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductionLines");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductionItems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Orders");
        }
    }
}
