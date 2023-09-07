using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddIdClienteByServicoPrestado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "ITENS_SERVICOS_PRESTADO");
        }
    }
}
