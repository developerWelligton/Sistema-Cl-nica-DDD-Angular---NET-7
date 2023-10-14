using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{

    [Table("PRODUTOS")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdProduto { get; set; }
        public virtual ICollection<ItemProdutoCompra> ItemProdutoCompras { get; set; } = new List<ItemProdutoCompra>();
        public virtual ICollection<ItemProdutoVenda> ItemProdutoVendas { get; set; } = new List<ItemProdutoVenda>();

        [Required]
        [StringLength(255)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? PrecoCompra { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? PrecoVenda { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataValidade { get; set; }

        public int? Quantidade { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        // Relacionamento com UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica? Usuario { get; set; }

        // Relacionamento com UnspscCode
        public long IdUnspsc { get; set; }
        [ForeignKey("IdUnspsc")]
        public virtual UnspscCode? UnspscCode { get; set; }

        [NotMapped] // Evita que o EF tente mapear esta propriedade para um campo na tabela
        public string CodigoSfcm { get; set; }

    }
}