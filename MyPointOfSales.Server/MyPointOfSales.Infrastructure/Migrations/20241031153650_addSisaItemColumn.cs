using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPointOfSales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSisaItemColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SisaItem",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SisaItem",
                table: "Transactions");
        }
    }
}
