using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiWms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addmade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Made",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Made",
                table: "OrderItems");
        }
    }
}
