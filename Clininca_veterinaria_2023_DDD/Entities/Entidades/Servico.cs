using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("SERVICOS")]
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdServico { get; set; }

        [Required]
        [StringLength(255)]
        public string? Nome { get; set; }

        [StringLength(255)]
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal Preco { get; set; }

        // Relacionamento com UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica? Usuario { get; set; }

        // Relacionamento com UnspscCode
        public long IdUnspsc { get; set; }
        [ForeignKey("IdUnspsc")]
        public virtual UnspscCode? UnspscCode { get; set; }
    }
}