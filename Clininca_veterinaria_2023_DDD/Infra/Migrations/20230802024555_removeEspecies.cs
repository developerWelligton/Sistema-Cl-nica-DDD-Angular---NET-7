using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class removeEspecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Especie_ID_Especie",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropIndex(
                name: "IX_Animal_ID_Especie",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "ID_Especie",
                table: "Animal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_Especie",
                table: "Animal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    ID_Especie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.ID_Especie);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ID_Especie",
                table: "Animal",
                column: "ID_Especie");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Especie_ID_Especie",
                table: "Animal",
                column: "ID_Especie",
                principalTable: "Especie",
                principalColumn: "ID_Especie",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
