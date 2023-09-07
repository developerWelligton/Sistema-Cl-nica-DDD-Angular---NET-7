using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddItemCompraByUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITENS_PRODUTOS_COMPRA",
                columns: table => new
                {
                    DataEntrada = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    QuantidadeTotal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IdCompra = table.Column<long>(type: "bigint", nullable: false),
                    IdProduto = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ITENS_PRODUTOS_COMPRA_COMPRAS_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "COMPRAS",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENS_PRODUTOS_COMPRA_PRODUTOS_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "PRODUTOS",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_IdCompra",
                table: "ITENS_PRODUTOS_COMPRA",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_IdProduto",
                table: "ITENS_PRODUTOS_COMPRA",
                column: "IdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITENS_PRODUTOS_COMPRA");
        }
    }
}
