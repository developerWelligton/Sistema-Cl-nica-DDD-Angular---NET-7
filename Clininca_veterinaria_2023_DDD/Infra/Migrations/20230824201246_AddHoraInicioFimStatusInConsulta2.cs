using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddHoraInicioFimStatusInConsulta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFim",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "DataConsulta",
                table: "Consulta",
                newName: "InicioConsulta");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Consulta",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMarcacao",
                table: "Consulta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FimConsulta",
                table: "Consulta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataMarcacao",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "FimConsulta",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "InicioConsulta",
                table: "Consulta",
                newName: "DataConsulta");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Consulta",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFim",
                table: "Consulta",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraInicio",
                table: "Consulta",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
