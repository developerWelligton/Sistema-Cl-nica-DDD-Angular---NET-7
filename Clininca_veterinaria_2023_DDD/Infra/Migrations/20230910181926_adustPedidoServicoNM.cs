using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class adustPedidoServicoNM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_PRODUTOS_COMPRA_PRODUTOS_ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropTable(
                name: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.DropIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropColumn(
                name: "ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ITENS_SERVICOS_PRESTADO",
                columns: table => new
                {
                    IdItemServicoPrestado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    IdPedidoServicos = table.Column<long>(type: "bigint", nullable: true),
                    IdServico = table.Column<long>(type: "bigint", nullable: false),
                    DataServicoPrestado = table.Column<DateTime>(type: "datetime", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    StatusPagamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalServicoPrestado = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITENS_SERVICOS_PRESTADO", x => x.IdItemServicoPrestado);
                    table.ForeignKey(
                        name: "FK_ITENS_SERVICOS_PRESTADO_PEDIDO_SERVICOS_IdPedidoServicos",
                        column: x => x.IdPedidoServicos,
                        principalTable: "PEDIDO_SERVICOS",
                        principalColumn: "IdPedidoServicos");
                    table.ForeignKey(
                        name: "FK_ITENS_SERVICOS_PRESTADO_SERVICOS_IdServico",
                        column: x => x.IdServico,
                        principalTable: "SERVICOS",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITENS_SERVICOS_PRESTADO_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_SERVICOS_PRESTADO_ID_Usuario",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_SERVICOS_PRESTADO_IdPedidoServicos",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "IdPedidoServicos");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_SERVICOS_PRESTADO_IdServico",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "IdServico");

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_PRODUTOS_COMPRA_PRODUTOS_ProdutoIdProduto",
                table: "ITENS_PRODUTOS_COMPRA",
                column: "ProdutoIdProduto",
                principalTable: "PRODUTOS",
                principalColumn: "IdProduto");
        }
    }
}
