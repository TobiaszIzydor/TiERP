using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TiErp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productitemproductidfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePayroll");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductionItems",
                newName: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductionItems",
                newName: "ProductID");

            migrationBuilder.CreateTable(
                name: "EmployeePayroll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    BaseSallary = table.Column<decimal>(type: "numeric", nullable: false),
                    Bonus = table.Column<decimal>(type: "numeric", nullable: false),
                    PayPeriodEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    PayPeriodStart = table.Column<DateOnly>(type: "date", nullable: false),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayroll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePayroll_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayroll_EmployeeId",
                table: "EmployeePayroll",
                column: "EmployeeId",
                unique: true);
        }
    }
}
