using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Consulta_Exame")]
    public class Consulta_Exame
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Consulta")]
        public int ID_Consulta { get; set; }
        public virtual Consulta Consulta { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Exame")]
        public int ID_Exame { get; set; }
        public virtual Exame Exame { get; set; }

        [Required]
        public DateTime DataExame { get; set; }
    }
}
