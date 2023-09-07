using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
     [Table("PEDIDO_SERVICOS_RELACAO")]
    public class PedidoServicosRelacao
    {
        [Key, Column(Order = 0)]
        [ForeignKey("PedidoServicos")]
        public long IdPedidoServicos { get; set; }
        public virtual PedidoServicos PedidoServicos { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Servico")]
        public long IdServico { get; set; }
        public virtual Servico Servico { get; set; }
    }
}