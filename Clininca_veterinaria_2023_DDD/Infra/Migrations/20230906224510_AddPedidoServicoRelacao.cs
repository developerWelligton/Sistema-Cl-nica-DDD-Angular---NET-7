using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPedidoServicoRelacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PEDIDO_SERVICOS_RELACAO",
                columns: table => new
                {
                    IdPedidoServicos = table.Column<long>(type: "bigint", nullable: false),
                    IdServico = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO_SERVICOS_RELACAO", x => new { x.IdPedidoServicos, x.IdServico });
                    table.ForeignKey(
                        name: "FK_PEDIDO_SERVICOS_RELACAO_PEDIDO_SERVICOS_IdPedidoServicos",
                        column: x => x.IdPedidoServicos,
                        principalTable: "PEDIDO_SERVICOS",
                        principalColumn: "IdPedidoServicos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PEDIDO_SERVICOS_RELACAO_SERVICOS_IdServico",
                        column: x => x.IdServico,
                        principalTable: "SERVICOS",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_SERVICOS_RELACAO_IdServico",
                table: "PEDIDO_SERVICOS_RELACAO",
                column: "IdServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PEDIDO_SERVICOS_RELACAO");
        }
    }
}
