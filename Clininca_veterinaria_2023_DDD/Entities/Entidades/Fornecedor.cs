using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("FORNECEDORES")]
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdFornecedor { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(255)]
        public string? Endereco { get; set; }

        [Required]
        [StringLength(20)]
        public string? CNPJ { get; set; }

        // Relacionamento com UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica? Usuario { get; set; }
    }
}