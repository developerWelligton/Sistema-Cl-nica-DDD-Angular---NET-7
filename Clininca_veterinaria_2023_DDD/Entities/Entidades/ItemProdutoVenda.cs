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
        public int? Quantidade { get; set; }

        // Relacionamento com Estoque (agora opcional)
        public long? IdEstoque { get; set; } // Permite valores nulos com '?'
        [ForeignKey("IdEstoque")]
        public virtual Estoque? Estoque { get; set; } // A entidade Estoque é opcional

        [StringLength(50)]
        public string? Status { get; set; } // 'string' já é um tipo de referência, então é opcional por padrão


    }
}