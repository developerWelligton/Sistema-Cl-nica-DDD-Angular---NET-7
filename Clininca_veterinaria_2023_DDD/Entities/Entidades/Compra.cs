using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("COMPRAS")]
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdCompra { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? Total { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataCompra { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        // Relacionamento com UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica? Usuario { get; set; }

        // Relacionamento com Fornecedor
        public long IdFornecedor { get; set; }
        [ForeignKey("IdFornecedor")]
        public virtual Fornecedor? Fornecedor { get; set; }
    }
}