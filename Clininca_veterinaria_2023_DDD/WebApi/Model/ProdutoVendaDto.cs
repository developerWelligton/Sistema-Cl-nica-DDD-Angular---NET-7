namespace WebApi.Model
{
    public class ProdutoVendaDto
    {
        public long IdProduto { get; set; }
        public long IdVenda { get; set; }
        public decimal? TotalProdutosVendas { get; set; }
        public string? Observacao { get; set; }
        public int? Quantidade { get; set; }
    }
}
