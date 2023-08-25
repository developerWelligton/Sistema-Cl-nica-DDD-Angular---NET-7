using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class addIdUserInConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_Usuario",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ID_Usuario",
                table: "Consulta",
                column: "ID_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_UsuarioSistemaClinica_ID_Usuario",
                table: "Consulta",
                column: "ID_Usuario",
                principalTable: "UsuarioSistemaClinica",
                principalColumn: "ID_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_UsuarioSistemaClinica_ID_Usuario",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_ID_Usuario",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "ID_Usuario",
                table: "Consulta");
        }
    }
}
