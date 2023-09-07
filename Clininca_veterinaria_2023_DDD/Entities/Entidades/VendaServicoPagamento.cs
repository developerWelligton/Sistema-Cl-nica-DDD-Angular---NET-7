using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("VENDA_SERVICO_PAGAMENTO")]
    public class VendaServicoPagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdVendaServicoPagamento { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataPagamento { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? Total { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string FormaPagamento { get; set; }

        // Relacionamento com UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica Usuario { get; set; }

        // Relacionamento com ItemServicoPrestado (opcional)
        public long? IdPedidoServicos { get; set; }  // Tornou-se opcional
        [ForeignKey("IdPedidoServicos")]
        public virtual PedidoServicos PedidoServico { get; set; }

        // Relacionamento com Venda (opcional)
        public long? IdVenda { get; set; }  // Tornou-se opcional
        [ForeignKey("IdVenda")]
        public virtual Venda Venda { get; set; }
    }
}