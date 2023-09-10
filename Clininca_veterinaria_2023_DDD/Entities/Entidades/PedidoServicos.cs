using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("PEDIDO_SERVICOS")]
    public class PedidoServicos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdPedidoServicos { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataPedido { get; set; }

        [StringLength(50)]
        public string StatusPagamento { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? TotalPedido { get; set; }

        // Relacionamento com UsuarioSistemaClinica
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica Usuario { get; set; }

        
        // Relação com PedidoServicosRelacao
        public virtual ICollection<PedidoServicosRelacao> PedidoServicosRelacoes { get; set; }
    }
}