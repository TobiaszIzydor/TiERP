using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiWms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLiderID2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LineLiderId",
                table: "ProductionLines",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionLines_LineLiderId",
                table: "ProductionLines",
                column: "LineLiderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionLines_Employees_LineLiderId",
                table: "ProductionLines",
                column: "LineLiderId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionLines_Employees_LineLiderId",
                table: "ProductionLines");

            migrationBuilder.DropIndex(
                name: "IX_ProductionLines_LineLiderId",
                table: "ProductionLines");

            migrationBuilder.AlterColumn<string>(
                name: "LineLiderId",
                table: "ProductionLines",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionLines_LineLiderId",
                table: "ProductionLines",
                column: "LineLiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionLines_AspNetUsers_LineLiderId",
                table: "ProductionLines",
                column: "LineLiderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
