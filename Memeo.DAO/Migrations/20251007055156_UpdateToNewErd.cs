using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Memeo.DAO.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToNewErd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductSizes",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductSizes",
                newName: "ProductSizesID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSizes",
                newName: "IX_ProductSizes_ProductID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductID",
                table: "ProductSizes",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductID",
                table: "ProductSizes");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductSizes",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductSizesID",
                table: "ProductSizes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizes_ProductID",
                table: "ProductSizes",
                newName: "IX_ProductSizes_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Products",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
