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

        /*ASSAAS*/
        [Required]
        [StringLength(14)]
        public string CPF_CNPJ { get; set; }

        [StringLength(255)]
        public string? Endereco { get; set; }

        [StringLength(20)]
        public string? TelefoneFixo { get; set; }

        [StringLength(20)]
        public string? TelefoneMovel { get; set; }

        // Assuming a postal code is a string to account for leading zeros and/or hyphens
        [StringLength(100)]
        public string? CEP { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? Bairro { get; set; }

        [StringLength(100)]
        public string? Cidade { get; set; }

        [StringLength(100)]
        public string? UF { get; set; } // Assuming UF stands for "Unidade Federativa" (State)

        [StringLength(100)]
        public string? Complemento { get; set; }

        [StringLength(100)]
        public string? InscricaoMunicipal { get; set; }

        [StringLength(100)]
        public string? InscricaoEstadual { get; set; }


        // Additional properties based on the form screenshot
        [StringLength(255)]
        public string? Observacoes { get; set; }

        [StringLength(100)]
        public string? Grupo { get; set; }

        [StringLength(255)]
        public string? Empresa { get; set; }

        // Fields related to notifications and emails
        public bool NotificacaoDesabilitada { get; set; }
        public string? EmailsAdicionais { get; set; }




        /*ASSAAS*/
        [Required]
        public int ID_Usuario { get; set; }

        [JsonIgnore]
        [ForeignKey("ID_Usuario")]
        public UsuarioSistemaClinica UsuarioSistemaClinica { get; set; }
       
        // Lista de exames associados a este cliente.
        //public virtual ICollection<Exame> Exames { get; set; }

        //public virtual ICollection<Animal> Animais { get; set; }

    }
}
