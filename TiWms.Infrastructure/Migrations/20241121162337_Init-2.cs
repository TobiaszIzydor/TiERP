using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiWms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactInfo_Id",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactInfo_Id",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
