using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Notificacoes;
using System.Text.Json.Serialization;

namespace Entities.Entidades
{

    public class Cliente 
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Cliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Required]
        public int ID_Usuario { get; set; }

        [JsonIgnore]
        [ForeignKey("ID_Usuario")]
        public UsuarioSistemaClinica UsuarioSistemaClinica { get; set; }

    }
}
