using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class adjustItemProdutoCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ITENS_PRODUTOS_VENDAS_IdVenda",
                table: "ITENS_PRODUTOS_VENDAS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ITENS_PRODUTOS_VENDAS",
                table: "ITENS_PRODUTOS_VENDAS",
                columns: new[] { "IdVenda", "IdProduto" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ITENS_PRODUTOS_VENDAS",
                table: "ITENS_PRODUTOS_VENDAS");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_VENDAS_IdVenda",
                table: "ITENS_PRODUTOS_VENDAS",
                column: "IdVenda");
        }
    }
}
