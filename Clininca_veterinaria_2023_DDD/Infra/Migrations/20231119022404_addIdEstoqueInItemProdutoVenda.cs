using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class addIdEstoqueInItemProdutoVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdEstoque",
                table: "ITENS_PRODUTOS_VENDAS",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ITENS_PRODUTOS_VENDAS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_VENDAS_IdEstoque",
                table: "ITENS_PRODUTOS_VENDAS",
                column: "IdEstoque");

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_PRODUTOS_VENDAS_ESTOQUES_IdEstoque",
                table: "ITENS_PRODUTOS_VENDAS",
                column: "IdEstoque",
                principalTable: "ESTOQUES",
                principalColumn: "IdEstoque");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_PRODUTOS_VENDAS_ESTOQUES_IdEstoque",
                table: "ITENS_PRODUTOS_VENDAS");

            migrationBuilder.DropIndex(
                name: "IX_ITENS_PRODUTOS_VENDAS_IdEstoque",
                table: "ITENS_PRODUTOS_VENDAS");

            migrationBuilder.DropColumn(
                name: "IdEstoque",
                table: "ITENS_PRODUTOS_VENDAS");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ITENS_PRODUTOS_VENDAS");
        }
    }
}
