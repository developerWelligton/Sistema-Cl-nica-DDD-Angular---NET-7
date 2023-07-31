using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Veterinario")]
    public class Veterinario
    {
        
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID_Veterinario { get; set; }

            [Required]
            [StringLength(100)]
            public string Nome { get; set; }

            [Required]
            [StringLength(100)]
            public string Especializacao { get; set; }

            [Required]
            [StringLength(100)]
            public string Email { get; set; }

            [Required]
            [StringLength(20)]
            public string Telefone { get; set; }

            [Required]
            public int ID_Usuario { get; set; }

            [ForeignKey("ID_Usuario")]
            public UsuarioSistemaClinica UsuarioSistemaClinica { get; set; }
        } 
}
