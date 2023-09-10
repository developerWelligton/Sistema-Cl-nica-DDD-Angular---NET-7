using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("ITENS_PRODUTOS_COMPRA")]
    public class ItemProdutoCompra
    {
        [Column(TypeName = "datetime")]
        public DateTime? DataEntrada { get; set; }

        public int? QuantidadeTotal { get; set; }

        [StringLength(10)]
        public string? Lote { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? PrecoTotal { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataValidade { get; set; }

        [StringLength(50)]
        public string? StatusEntrega { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? Desconto { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? Imposto { get; set; }

        [StringLength(255)]
        public string? Observacoes { get; set; }

        // Relacionamento com Compra
        public long IdCompra { get; set; }
        [ForeignKey("IdCompra")]
        public virtual Compra? Compra { get; set; }

        // Relacionamento com Produto
        public long IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public virtual Produto? Produto { get; set; }
    }
}
