using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPointOfSales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeTransactionJumlahItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JumlahItem",
                table: "Transactions",
                newName: "JumlahItemDiJual");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JumlahItemDiJual",
                table: "Transactions",
                newName: "JumlahItem");
        }
    }
}
