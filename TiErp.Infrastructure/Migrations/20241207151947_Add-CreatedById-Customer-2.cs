using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiErp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByIdCustomer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedById",
                table: "Customers",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_CreatedById",
                table: "Customers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_CreatedById",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CreatedById",
                table: "Customers");
        }
    }
}
