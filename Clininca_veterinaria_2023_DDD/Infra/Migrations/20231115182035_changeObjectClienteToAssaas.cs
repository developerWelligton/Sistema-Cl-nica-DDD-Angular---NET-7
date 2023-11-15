using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class changeObjectClienteToAssaas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Clientes",
                newName: "TelefoneMovel");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Clientes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF_CNPJ",
                table: "Clientes",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailsAdicionais",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Clientes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoMunicipal",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NotificacaoDesabilitada",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Clientes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefoneFixo",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Clientes",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CPF_CNPJ",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EmailsAdicionais",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "InscricaoMunicipal",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "NotificacaoDesabilitada",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TelefoneFixo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "TelefoneMovel",
                table: "Clientes",
                newName: "Telefone");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
