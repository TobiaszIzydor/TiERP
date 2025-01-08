using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiErp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByIdCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Customers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Customers");
        }
    }
}
