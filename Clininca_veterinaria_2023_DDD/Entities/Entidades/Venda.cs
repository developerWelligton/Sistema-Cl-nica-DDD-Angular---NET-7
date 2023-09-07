using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("VENDA")]
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdVenda { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataVenda { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        // Relacionamento com UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica? Usuario { get; set; }
    }
}