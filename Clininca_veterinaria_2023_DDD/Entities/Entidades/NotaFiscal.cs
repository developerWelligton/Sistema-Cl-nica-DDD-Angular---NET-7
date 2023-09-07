using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("NOTA_FISCAL")]
    public class NotaFiscal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdNotaFiscal { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataEmissao { get; set; }

        [StringLength(100)]
        public string? ClienteNome { get; set; }

        [StringLength(255)]
        public string? ClienteEndereco { get; set; }

        [StringLength(20)]
        public string? ClienteCnpjCpf { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? ValorTotal { get; set; }

        // Relacionamento com UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica? Usuario { get; set; }

        // Relacionamento com VendaServicoPagamento
        public long? IdVendaServicoPagamento { get; set; }
        [ForeignKey("IdVendaServicoPagamento")]
        public virtual VendaServicoPagamento? VendaServicoPagamento { get; set; }
    }
}