using Infra.Configuracao;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{ 
    // Define a tabela UnspscCodes no banco de dados
    [Table("UnspscCodes")]
    public class UnspscCode
    {
        // Define a chave primária e a geração automática de seu valor
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdUnspsc { get; set; }

        // Define a coluna CodigoSfcm como obrigatória e com tamanho máximo de 20 caracteres
        [Required]
        [StringLength(20)]
        public string? CodigoSfcm { get; set; }

        // Relacionamento com a tabela UsuarioSistemaClinica
        // ID_Usuario é a chave estrangeira que se relaciona com a tabela UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica? Usuario { get; set; }

        // Relacionamento com a tabela Segmento
        // IdSegmento é a chave estrangeira que se relaciona com a tabela Segmento
        public long IdSegmento { get; set; }
        [ForeignKey("IdSegmento")]
        public virtual Segmento? Segmento { get; set; }

        // Relacionamento com a tabela Familia
        // IdFamilia é a chave estrangeira que se relaciona com a tabela Familia
        public long IdFamilia { get; set; }
        [ForeignKey("IdFamilia")]
        public virtual Familia? Familia { get; set; }

        // Relacionamento com a tabela Classe
        // IdClasse é a chave estrangeira que se relaciona com a tabela Classe
        public long IdClasse { get; set; }
        [ForeignKey("IdClasse")]
        public virtual Classe? Classe { get; set; }

        // Relacionamento com a tabela Mercadoria
        // IdMercadoria é a chave estrangeira que se relaciona com a tabela Mercadoria
        public long IdMercadoria { get; set; }
        [ForeignKey("IdMercadoria")]
        public virtual Mercadoria? Mercadoria { get; set; }
    }
}