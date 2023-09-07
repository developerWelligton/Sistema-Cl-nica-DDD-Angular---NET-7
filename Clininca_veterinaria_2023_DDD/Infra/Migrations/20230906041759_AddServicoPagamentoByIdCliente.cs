using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddServicoPagamentoByIdCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_SERVICOS_IdServico",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_UsuarioSistemaClinica_ID_Usuario",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.AlterColumn<long>(
                name: "IdVenda",
                table: "VENDA_SERVICO_PAGAMENTO",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_SERVICOS_IdServico",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "IdServico",
                principalTable: "SERVICOS",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_UsuarioSistemaClinica_ID_Usuario",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "ID_Usuario",
                principalTable: "UsuarioSistemaClinica",
                principalColumn: "ID_Usuario",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_SERVICOS_IdServico",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_UsuarioSistemaClinica_ID_Usuario",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.AlterColumn<long>(
                name: "IdVenda",
                table: "VENDA_SERVICO_PAGAMENTO",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_SERVICOS_IdServico",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "IdServico",
                principalTable: "SERVICOS",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_UsuarioSistemaClinica_ID_Usuario",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "ID_Usuario",
                principalTable: "UsuarioSistemaClinica",
                principalColumn: "ID_Usuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
