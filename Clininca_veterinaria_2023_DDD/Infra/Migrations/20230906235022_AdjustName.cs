using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdjustName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.DropColumn(
                name: "IdPedidoServico",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.AlterColumn<long>(
                name: "IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdPedidoServicos",
                principalTable: "PEDIDO_SERVICOS",
                principalColumn: "IdPedidoServicos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.AlterColumn<long>(
                name: "IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdPedidoServico",
                table: "VENDA_SERVICO_PAGAMENTO",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdPedidoServicos",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdPedidoServicos",
                principalTable: "PEDIDO_SERVICOS",
                principalColumn: "IdPedidoServicos",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
