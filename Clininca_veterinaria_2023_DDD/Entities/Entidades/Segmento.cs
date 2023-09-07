using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("Segmentos")]
    public class Segmento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdSegmento { get; set; }

        [Required]
        [StringLength(20)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(255)]
        public string Descricao { get; set; }

        // Relacionamento com UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica Usuario { get; set; }
    }
}