using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPedidoServicoPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PEDIDO_SERVICOS_UsuarioSistemaClinica_ID_Usuario",
                table: "PEDIDO_SERVICOS");

            migrationBuilder.DropForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_VENDA_SERVICO_PAGAMENTO_IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.RenameColumn(
                name: "IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO",
                newName: "IdPedidoServico");

            migrationBuilder.AddColumn<long>(
                name: "IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_SERVICO_PAGAMENTO_IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdPedidoServicos");

            migrationBuilder.AddForeignKey(
                name: "FK_PEDIDO_SERVICOS_UsuarioSistemaClinica_ID_Usuario",
                table: "PEDIDO_SERVICOS",
                column: "ID_Usuario",
                principalTable: "UsuarioSistemaClinica",
                principalColumn: "ID_Usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdPedidoServicos",
                principalTable: "PEDIDO_SERVICOS",
                principalColumn: "IdPedidoServicos",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PEDIDO_SERVICOS_UsuarioSistemaClinica_ID_Usuario",
                table: "PEDIDO_SERVICOS");

            migrationBuilder.DropForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_VENDA_SERVICO_PAGAMENTO_IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.DropColumn(
                name: "IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.RenameColumn(
                name: "IdPedidoServico",
                table: "VENDA_SERVICO_PAGAMENTO",
                newName: "IdItemServicoPrestado");

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_SERVICO_PAGAMENTO_IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdItemServicoPrestado");

            migrationBuilder.AddForeignKey(
                name: "FK_PEDIDO_SERVICOS_UsuarioSistemaClinica_ID_Usuario",
                table: "PEDIDO_SERVICOS",
                column: "ID_Usuario",
                principalTable: "UsuarioSistemaClinica",
                principalColumn: "ID_Usuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdItemServicoPrestado",
                principalTable: "PEDIDO_SERVICOS",
                principalColumn: "IdPedidoServicos",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
