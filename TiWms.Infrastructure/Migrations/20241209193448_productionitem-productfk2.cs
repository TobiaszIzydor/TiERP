using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiWms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productionitemproductfk2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductionItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductionItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
