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
    [Table("UsuarioSistemaClinica")]
    public class UsuarioSistemaClinica 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Usuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }
          
        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        [Required]
        [StringLength(14)]
        public string CPF { get; set; }
    }

} 
