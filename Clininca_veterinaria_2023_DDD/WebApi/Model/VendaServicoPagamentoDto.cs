namespace WebApi.Model
{
    public class VendaServicoPagamentoDto
    {
        public long IdVendaServicoPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal? Total { get; set; }
        public string Status { get; set; }
        public string FormaPagamento { get; set; }
        public int ID_Usuario { get; set; }
        public long? IdPedidoServicos { get; set; }
        public long? IdVenda { get; set; }

    }
}
