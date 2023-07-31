using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Consulta")]
    public class Consulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Consulta { get; set; }

        [Required]
        public DateTime DataConsulta { get; set; }

        [Required]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Required]
        public int ID_Veterinario { get; set; }

        [ForeignKey("ID_Veterinario")]
        public Veterinario Veterinario { get; set; }

        [Required]
        public int ID_Animal { get; set; }

        [ForeignKey("ID_Animal")]
        public Animal Animal { get; set; }
    }
}
