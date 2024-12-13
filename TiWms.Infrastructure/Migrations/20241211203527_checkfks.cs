using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiWms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class checkfks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductionLines_ProductionLineId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductionLineId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductionLineId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionLineId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductionLineId",
                table: "Orders",
                column: "ProductionLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductionLines_ProductionLineId",
                table: "Orders",
                column: "ProductionLineId",
                principalTable: "ProductionLines",
                principalColumn: "Id");
        }
    }
}
