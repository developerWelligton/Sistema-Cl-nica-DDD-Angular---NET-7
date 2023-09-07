using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("ITENS_PRODUTOS_VENDAS")]
    public class ItemProdutoVenda
    {
        // Relacionamento com Produto
        public long IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public virtual Produto? Produto { get; set; }

        // Relacionamento com Venda
        public long IdVenda { get; set; }
        [ForeignKey("IdVenda")]
        public virtual Venda? Venda { get; set; }

        [StringLength(10)]
        public string? TotalProdutosVendas { get; set; }

        [StringLength(10)]
        public string? Observacao { get; set; }

        [StringLength(10)]
        public string? Quantidade { get; set; }
    }
}