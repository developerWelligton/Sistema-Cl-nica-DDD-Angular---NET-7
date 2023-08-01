using Entities.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Animal")]
    public class Animal  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Animal { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int ID_Especie { get; set; }

        [ForeignKey("ID_Especie")]
        public Especie Especie { get; set; }

        [Required]
        public int ID_Cliente { get; set; }

        [ForeignKey("ID_Cliente")]
        public Cliente Cliente { get; set; }
    }
}
