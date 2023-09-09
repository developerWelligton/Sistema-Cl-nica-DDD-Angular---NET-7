namespace WebApi.Model
{
    public class CompraDto
    {
        public long IdCompra { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DataCompra { get; set; }
        public string? Status { get; set; }
        public int ID_Usuario { get; set; }
        public long IdFornecedor { get; set; }
    }
}
