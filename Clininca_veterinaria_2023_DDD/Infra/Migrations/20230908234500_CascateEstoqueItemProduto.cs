using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class CascateEstoqueItemProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_PRODUTO_ESTOQUES_ESTOQUES_IdEstoque",
                table: "ITENS_PRODUTO_ESTOQUES");

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_PRODUTO_ESTOQUES_ESTOQUES_IdEstoque",
                table: "ITENS_PRODUTO_ESTOQUES",
                column: "IdEstoque",
                principalTable: "ESTOQUES",
                principalColumn: "IdEstoque",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_PRODUTO_ESTOQUES_ESTOQUES_IdEstoque",
                table: "ITENS_PRODUTO_ESTOQUES");

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_PRODUTO_ESTOQUES_ESTOQUES_IdEstoque",
                table: "ITENS_PRODUTO_ESTOQUES",
                column: "IdEstoque",
                principalTable: "ESTOQUES",
                principalColumn: "IdEstoque",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
