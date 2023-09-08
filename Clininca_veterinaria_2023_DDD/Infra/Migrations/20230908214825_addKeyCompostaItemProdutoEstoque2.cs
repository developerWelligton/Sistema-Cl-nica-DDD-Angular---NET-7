using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class addKeyCompostaItemProdutoEstoque2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ITENS_PRODUTO_ESTOQUES_IdProduto",
                table: "ITENS_PRODUTO_ESTOQUES");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ITENS_PRODUTO_ESTOQUES",
                table: "ITENS_PRODUTO_ESTOQUES",
                columns: new[] { "IdProduto", "IdEstoque" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ITENS_PRODUTO_ESTOQUES",
                table: "ITENS_PRODUTO_ESTOQUES");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTO_ESTOQUES_IdProduto",
                table: "ITENS_PRODUTO_ESTOQUES",
                column: "IdProduto");
        }
    }
}
