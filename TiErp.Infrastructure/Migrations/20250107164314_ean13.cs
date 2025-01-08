using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiErp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ean13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EAN11",
                table: "ProductionItems",
                newName: "EAN13");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EAN13",
                table: "ProductionItems",
                newName: "EAN11");
        }
    }
}
