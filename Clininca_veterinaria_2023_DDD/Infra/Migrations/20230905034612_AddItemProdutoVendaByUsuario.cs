using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddItemProdutoVendaByUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITENS_PRODUTOS_VENDAS",
                columns: table => new
                {
                    IdProduto = table.Column<long>(type: "bigint", nullable: false),
                    IdVenda = table.Column<long>(type: "bigint", nullable: false),
                    TotalProdutosVendas = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Quantidade = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ITENS_PRODUTOS_VENDAS_PRODUTOS_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "PRODUTOS",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENS_PRODUTOS_VENDAS_VENDA_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "VENDA",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_VENDAS_IdProduto",
                table: "ITENS_PRODUTOS_VENDAS",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_VENDAS_IdVenda",
                table: "ITENS_PRODUTOS_VENDAS",
                column: "IdVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITENS_PRODUTOS_VENDAS");
        }
    }
}
