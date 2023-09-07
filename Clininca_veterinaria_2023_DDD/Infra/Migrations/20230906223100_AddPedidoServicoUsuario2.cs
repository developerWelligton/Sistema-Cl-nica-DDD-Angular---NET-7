using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPedidoServicoUsuario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_ITENS_SERVICOS_PRESTADO_IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.RenameColumn(
                name: "TotalServicoPrestados",
                table: "ITENS_SERVICOS_PRESTADO",
                newName: "TotalServicoPrestado");

            migrationBuilder.AlterColumn<string>(
                name: "StatusPagamento",
                table: "ITENS_SERVICOS_PRESTADO",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdPedidoServicos",
                table: "ITENS_SERVICOS_PRESTADO",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PEDIDO_SERVICOS",
                columns: table => new
                {
                    IdPedidoServicos = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPedido = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusPagamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalPedido = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO_SERVICOS", x => x.IdPedidoServicos);
                    table.ForeignKey(
                        name: "FK_PEDIDO_SERVICOS_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_SERVICOS_PRESTADO_IdPedidoServicos",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "IdPedidoServicos");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_SERVICOS_ID_Usuario",
                table: "PEDIDO_SERVICOS",
                column: "ID_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_PEDIDO_SERVICOS_IdPedidoServicos",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "IdPedidoServicos",
                principalTable: "PEDIDO_SERVICOS",
                principalColumn: "IdPedidoServicos");

            migrationBuilder.AddForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdItemServicoPrestado",
                principalTable: "PEDIDO_SERVICOS",
                principalColumn: "IdPedidoServicos",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_SERVICOS_PRESTADO_PEDIDO_SERVICOS_IdPedidoServicos",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.DropForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_PEDIDO_SERVICOS_IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.DropTable(
                name: "PEDIDO_SERVICOS");

            migrationBuilder.DropIndex(
                name: "IX_ITENS_SERVICOS_PRESTADO_IdPedidoServicos",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.DropColumn(
                name: "IdPedidoServicos",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.RenameColumn(
                name: "TotalServicoPrestado",
                table: "ITENS_SERVICOS_PRESTADO",
                newName: "TotalServicoPrestados");

            migrationBuilder.AlterColumn<string>(
                name: "StatusPagamento",
                table: "ITENS_SERVICOS_PRESTADO",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "IdCliente",
                table: "ITENS_SERVICOS_PRESTADO",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "ITENS_SERVICOS_PRESTADO",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VENDA_SERVICO_PAGAMENTO_ITENS_SERVICOS_PRESTADO_IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdItemServicoPrestado",
                principalTable: "ITENS_SERVICOS_PRESTADO",
                principalColumn: "IdItemServicoPrestado",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
