namespace WebApi.Model
{
    public class NotaFiscalDto
    {
        public long IdNotaFiscal { get; set; }
        public DateTime? DataEmissao { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteEndereco { get; set; }
        public string ClienteCnpjCpf { get; set; }
        public decimal? ValorTotal { get; set; }
        public int ID_Usuario { get; set; }
        public long? IdVendaServicoPagamento { get; set; }
    }
}
