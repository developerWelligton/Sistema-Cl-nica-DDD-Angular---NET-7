using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddItensProdutosNaCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompraIdCompra",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_CompraIdCompra",
                table: "ITENS_PRODUTOS_COMPRA",
                column: "CompraIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA",
                column: "ProdutoIdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_PRODUTOS_COMPRA_COMPRAS_CompraIdCompra",
                table: "ITENS_PRODUTOS_COMPRA",
                column: "CompraIdCompra",
                principalTable: "COMPRAS",
                principalColumn: "IdCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_PRODUTOS_COMPRA_PRODUTOS_ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA",
                column: "ProdutoIdProduto",
                principalTable: "PRODUTOS",
                principalColumn: "IdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_PRODUTOS_COMPRA_COMPRAS_CompraIdCompra",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_PRODUTOS_COMPRA_PRODUTOS_ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_CompraIdCompra",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropColumn(
                name: "CompraIdCompra",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropColumn(
                name: "ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA");
        }
    }
}
