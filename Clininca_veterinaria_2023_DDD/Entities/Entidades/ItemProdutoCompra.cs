using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("ITENS_PRODUTOS_COMPRA")]
    public class ItemProdutoCompra
    {  
        [StringLength(10)]
        public string? DataEntrada { get; set; }  // Considere usar DateTime se apropriado

        [StringLength(10)]
        public string? QuantidadeTotal { get; set; }  // Considere usar int se apropriado

        [StringLength(10)]
        public string? Lote { get; set; }

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