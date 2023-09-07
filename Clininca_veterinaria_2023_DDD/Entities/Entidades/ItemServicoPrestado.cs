using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    [Table("ITENS_SERVICOS_PRESTADO")]
    public class ItemServicoPrestado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdItemServicoPrestado { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataServicoPrestado { get; set; }

        public int? Quantidade { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        public decimal? TotalServicoPrestado { get; set; } // Removed the 's' to make it singular

        [StringLength(50)]
        public string StatusPagamento { get; set; }

        // Consider making foreign keys nullable if they are optional.
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public virtual UsuarioSistemaClinica Usuario { get; set; }

        public long IdServico { get; set; }
        [ForeignKey("IdServico")]
        public virtual Servico Servico { get; set; }

        public long? IdPedidoServicos { get; set; }
        [ForeignKey("IdPedidoServicos")]
        public virtual PedidoServicos PedidoServicos { get; set; }
    }
}