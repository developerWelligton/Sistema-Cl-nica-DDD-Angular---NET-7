using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdjustQuantidadeItensEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ESTOQUES");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade_Estoque",
                table: "ITENS_PRODUTO_ESTOQUES",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Altura",
                table: "Exame",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade_Estoque",
                table: "ITENS_PRODUTO_ESTOQUES");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Exame");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ESTOQUES",
                type: "int",
                nullable: true);
        }
    }
}
