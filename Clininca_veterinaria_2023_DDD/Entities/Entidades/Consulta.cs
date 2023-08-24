using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    public enum StatusConsulta
    {
        Pendente,
        Concluido
    }

    [Table("Consulta")]
    public class Consulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Consulta { get; set; }

        [Required]
        public DateTime DataMarcacao { get; set; } // Data em que a consulta foi marcada

        [Required]
        public DateTime InicioConsulta { get; set; }

        [Required]
        public DateTime FimConsulta { get; set; }

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

        [Required]
        public StatusConsulta Status { get; set; }
    }
}
