namespace WebApi.Model
{
    public class PedidoServicoDto
    {
        public long IdPedidoServicos { get; set; }
        public DateTime DataPedido { get; set; }
        public string StatusPagamento { get; set; }
        public decimal? TotalPedido { get; set; }
        public int ID_Usuario { get; set; }
    }
}
