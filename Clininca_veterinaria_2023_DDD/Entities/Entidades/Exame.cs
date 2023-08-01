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
    [Table("Exame")]
    public class Exame: Notifica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Exame { get; set; }

       
        public string Nome { get; set; }
         
        public string Detalhes { get; set; }
         
        public decimal Custo { get; set; }

        // Chave estrangeira para Cliente.
        public int ClienteId { get; set; }

        // Navegação propriedade.
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
    }
}
