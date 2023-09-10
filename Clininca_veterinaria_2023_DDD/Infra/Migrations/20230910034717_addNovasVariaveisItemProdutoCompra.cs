using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class addNovasVariaveisItemProdutoCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataValidade",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Desconto",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "decimal(15,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Imposto",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "decimal(15,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoTotal",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "decimal(15,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusEntrega",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataValidade",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropColumn(
                name: "Desconto",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropColumn(
                name: "Imposto",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropColumn(
                name: "PrecoTotal",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.DropColumn(
                name: "StatusEntrega",
                table: "ITENS_PRODUTOS_COMPRA");
        }
    }
}
