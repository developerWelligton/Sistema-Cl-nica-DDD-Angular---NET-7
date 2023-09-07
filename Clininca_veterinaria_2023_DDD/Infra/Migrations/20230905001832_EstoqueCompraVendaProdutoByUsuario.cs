using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class EstoqueCompraVendaProdutoByUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    IdClasse = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.IdClasse);
                    table.ForeignKey(
                        name: "FK_Classes_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ESTOQUES",
                columns: table => new
                {
                    IdEstoque = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sala = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prateleira = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTOQUES", x => x.IdEstoque);
                    table.ForeignKey(
                        name: "FK_ESTOQUES_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    IdFamilia = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.IdFamilia);
                    table.ForeignKey(
                        name: "FK_Familias_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FORNECEDORES",
                columns: table => new
                {
                    IdFornecedor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDORES", x => x.IdFornecedor);
                    table.ForeignKey(
                        name: "FK_FORNECEDORES_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercadorias",
                columns: table => new
                {
                    IdMercadoria = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercadorias", x => x.IdMercadoria);
                    table.ForeignKey(
                        name: "FK_Mercadorias_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Segmentos",
                columns: table => new
                {
                    IdSegmento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmentos", x => x.IdSegmento);
                    table.ForeignKey(
                        name: "FK_Segmentos_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VENDA",
                columns: table => new
                {
                    IdVenda = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVenda = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDA", x => x.IdVenda);
                    table.ForeignKey(
                        name: "FK_VENDA_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPRAS",
                columns: table => new
                {
                    IdCompra = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    DataCompra = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    IdFornecedor = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPRAS", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_COMPRAS_FORNECEDORES_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "FORNECEDORES",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMPRAS_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnspscCodes",
                columns: table => new
                {
                    IdUnspsc = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoSfcm = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    IdSegmento = table.Column<long>(type: "bigint", nullable: false),
                    IdFamilia = table.Column<long>(type: "bigint", nullable: false),
                    IdClasse = table.Column<long>(type: "bigint", nullable: false),
                    IdMercadoria = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnspscCodes", x => x.IdUnspsc);
                    table.ForeignKey(
                        name: "FK_UnspscCodes_Classes_IdClasse",
                        column: x => x.IdClasse,
                        principalTable: "Classes",
                        principalColumn: "IdClasse");
                    table.ForeignKey(
                        name: "FK_UnspscCodes_Familias_IdFamilia",
                        column: x => x.IdFamilia,
                        principalTable: "Familias",
                        principalColumn: "IdFamilia");
                    table.ForeignKey(
                        name: "FK_UnspscCodes_Mercadorias_IdMercadoria",
                        column: x => x.IdMercadoria,
                        principalTable: "Mercadorias",
                        principalColumn: "IdMercadoria");
                    table.ForeignKey(
                        name: "FK_UnspscCodes_Segmentos_IdSegmento",
                        column: x => x.IdSegmento,
                        principalTable: "Segmentos",
                        principalColumn: "IdSegmento");
                    table.ForeignKey(
                        name: "FK_UnspscCodes_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    IdProduto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PrecoCompra = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    PrecoVenda = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    DataValidade = table.Column<DateTime>(type: "date", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    IdUnspsc = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_UnspscCodes_IdUnspsc",
                        column: x => x.IdUnspsc,
                        principalTable: "UnspscCodes",
                        principalColumn: "IdUnspsc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SERVICOS",
                columns: table => new
                {
                    IdServico = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    IdUnspsc = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICOS", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_SERVICOS_UnspscCodes_IdUnspsc",
                        column: x => x.IdUnspsc,
                        principalTable: "UnspscCodes",
                        principalColumn: "IdUnspsc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SERVICOS_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ITENS_PRODUTO_ESTOQUES",
                columns: table => new
                {
                    IdProduto = table.Column<long>(type: "bigint", nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    IdEstoque = table.Column<long>(type: "bigint", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "date", nullable: true),
                    DataSaida = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ITENS_PRODUTO_ESTOQUES_ESTOQUES_IdEstoque",
                        column: x => x.IdEstoque,
                        principalTable: "ESTOQUES",
                        principalColumn: "IdEstoque",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITENS_PRODUTO_ESTOQUES_PRODUTOS_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "PRODUTOS",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITENS_PRODUTO_ESTOQUES_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ITENS_SERVICOS_PRESTADO",
                columns: table => new
                {
                    IdItemServicoPrestado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataServicoPrestado = table.Column<DateTime>(type: "datetime", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    TotalServicoPrestados = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    StatusPagamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    IdServico = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITENS_SERVICOS_PRESTADO", x => x.IdItemServicoPrestado);
                    table.ForeignKey(
                        name: "FK_ITENS_SERVICOS_PRESTADO_SERVICOS_IdServico",
                        column: x => x.IdServico,
                        principalTable: "SERVICOS",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENS_SERVICOS_PRESTADO_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VENDA_SERVICO_PAGAMENTO",
                columns: table => new
                {
                    IdVendaServicoPagamento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPagamento = table.Column<DateTime>(type: "date", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    IdItemServicoPrestado = table.Column<long>(type: "bigint", nullable: false),
                    IdVenda = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDA_SERVICO_PAGAMENTO", x => x.IdVendaServicoPagamento);
                    table.ForeignKey(
                        name: "FK_VENDA_SERVICO_PAGAMENTO_ITENS_SERVICOS_PRESTADO_IdItemServicoPrestado",
                        column: x => x.IdItemServicoPrestado,
                        principalTable: "ITENS_SERVICOS_PRESTADO",
                        principalColumn: "IdItemServicoPrestado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDA_SERVICO_PAGAMENTO_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDA_SERVICO_PAGAMENTO_VENDA_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "VENDA",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTA_FISCAL",
                columns: table => new
                {
                    IdNotaFiscal = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEmissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClienteNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClienteEndereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClienteCnpjCpf = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    IdVendaServicoPagamento = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTA_FISCAL", x => x.IdNotaFiscal);
                    table.ForeignKey(
                        name: "FK_NOTA_FISCAL_UsuarioSistemaClinica_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "UsuarioSistemaClinica",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTA_FISCAL_VENDA_SERVICO_PAGAMENTO_IdVendaServicoPagamento",
                        column: x => x.IdVendaServicoPagamento,
                        principalTable: "VENDA_SERVICO_PAGAMENTO",
                        principalColumn: "IdVendaServicoPagamento");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ID_Usuario",
                table: "Classes",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAS_ID_Usuario",
                table: "COMPRAS",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAS_IdFornecedor",
                table: "COMPRAS",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_ESTOQUES_ID_Usuario",
                table: "ESTOQUES",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Familias_ID_Usuario",
                table: "Familias",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDORES_ID_Usuario",
                table: "FORNECEDORES",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTO_ESTOQUES_ID_Usuario",
                table: "ITENS_PRODUTO_ESTOQUES",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTO_ESTOQUES_IdEstoque",
                table: "ITENS_PRODUTO_ESTOQUES",
                column: "IdEstoque");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_PRODUTO_ESTOQUES_IdProduto",
                table: "ITENS_PRODUTO_ESTOQUES",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_SERVICOS_PRESTADO_ID_Usuario",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_SERVICOS_PRESTADO_IdServico",
                table: "ITENS_SERVICOS_PRESTADO",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_ID_Usuario",
                table: "Mercadorias",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_NOTA_FISCAL_ID_Usuario",
                table: "NOTA_FISCAL",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_NOTA_FISCAL_IdVendaServicoPagamento",
                table: "NOTA_FISCAL",
                column: "IdVendaServicoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_ID_Usuario",
                table: "PRODUTOS",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_IdUnspsc",
                table: "PRODUTOS",
                column: "IdUnspsc");

            migrationBuilder.CreateIndex(
                name: "IX_Segmentos_ID_Usuario",
                table: "Segmentos",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICOS_ID_Usuario",
                table: "SERVICOS",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICOS_IdUnspsc",
                table: "SERVICOS",
                column: "IdUnspsc");

            migrationBuilder.CreateIndex(
                name: "IX_UnspscCodes_ID_Usuario",
                table: "UnspscCodes",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_UnspscCodes_IdClasse",
                table: "UnspscCodes",
                column: "IdClasse");

            migrationBuilder.CreateIndex(
                name: "IX_UnspscCodes_IdFamilia",
                table: "UnspscCodes",
                column: "IdFamilia");

            migrationBuilder.CreateIndex(
                name: "IX_UnspscCodes_IdMercadoria",
                table: "UnspscCodes",
                column: "IdMercadoria");

            migrationBuilder.CreateIndex(
                name: "IX_UnspscCodes_IdSegmento",
                table: "UnspscCodes",
                column: "IdSegmento");

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_ID_Usuario",
                table: "VENDA",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_SERVICO_PAGAMENTO_ID_Usuario",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_SERVICO_PAGAMENTO_IdItemServicoPrestado",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdItemServicoPrestado");

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_SERVICO_PAGAMENTO_IdVenda",
                table: "VENDA_SERVICO_PAGAMENTO",
                column: "IdVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMPRAS");

            migrationBuilder.DropTable(
                name: "ITENS_PRODUTO_ESTOQUES");

            migrationBuilder.DropTable(
                name: "NOTA_FISCAL");

            migrationBuilder.DropTable(
                name: "FORNECEDORES");

            migrationBuilder.DropTable(
                name: "ESTOQUES");

            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "VENDA_SERVICO_PAGAMENTO");

            migrationBuilder.DropTable(
                name: "ITENS_SERVICOS_PRESTADO");

            migrationBuilder.DropTable(
                name: "VENDA");

            migrationBuilder.DropTable(
                name: "SERVICOS");

            migrationBuilder.DropTable(
                name: "UnspscCodes");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Familias");

            migrationBuilder.DropTable(
                name: "Mercadorias");

            migrationBuilder.DropTable(
                name: "Segmentos");
        }
    }
}
