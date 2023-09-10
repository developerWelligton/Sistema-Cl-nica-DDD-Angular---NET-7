namespace WebApi.Model
{
    public class ItemProdutoCompraDto
    {
        public DateTime? DataEntrada { get; set; }
        public int? QuantidadeTotal { get; set; }
        public string? Lote { get; set; }
        public long IdCompra { get; set; }
        public long IdProduto { get; set; }

    }
}
