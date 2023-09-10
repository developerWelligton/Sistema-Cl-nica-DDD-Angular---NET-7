using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdjustTypeDataItemProdutoCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_IdCompra",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeTotal",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrada",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ITENS_PRODUTOS_COMPRA",
                table: "ITENS_PRODUTOS_COMPRA",
                columns: new[] { "IdCompra", "IdProduto" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ITENS_PRODUTOS_COMPRA",
                table: "ITENS_PRODUTOS_COMPRA");

            migrationBuilder.AlterColumn<string>(
                name: "QuantidadeTotal",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataEntrada",
                table: "ITENS_PRODUTOS_COMPRA",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTOS_COMPRA_IdCompra",
                table: "ITENS_PRODUTOS_COMPRA",
                column: "IdCompra");
        }
    }
}
