using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class ExameToCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Exame",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Detalhes",
                table: "Exame",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Exame",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exame_ClienteId",
                table: "Exame",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exame_Clientes_ClienteId",
                table: "Exame",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ID_Cliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exame_Clientes_ClienteId",
                table: "Exame");

            migrationBuilder.DropIndex(
                name: "IX_Exame_ClienteId",
                table: "Exame");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Exame");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Exame",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Detalhes",
                table: "Exame",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
