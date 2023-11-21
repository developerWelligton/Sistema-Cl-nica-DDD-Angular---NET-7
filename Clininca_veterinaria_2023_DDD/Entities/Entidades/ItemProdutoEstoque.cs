using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("ITENS_PRODUTO_ESTOQUES")]
    public class ItemProdutoEstoque
    {
        [Key, Column(Order = 0)]
        public long? IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public virtual Produto? Produto { get; set; }
 

        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica? Usuario { get; set; }

        [Key, Column(Order = 1)]
        public long IdEstoque { get; set; }
        [ForeignKey("IdEstoque")]
        public virtual Estoque? Estoque { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataEntrada { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataSaida { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        public int? Quantidade_Estoque { get; set; }


    }
}