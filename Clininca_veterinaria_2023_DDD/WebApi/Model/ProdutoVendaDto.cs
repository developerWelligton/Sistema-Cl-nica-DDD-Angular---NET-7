namespace WebApi.Model
{
    public class ProdutoVendaDto
    {
        public long IdEstoque { get; set; }
        public long IdProduto { get; set; }
        public long IdVenda { get; set; }
   
        public string? Observacao { get; set; }
        public int? Quantidade { get; set; }
        public decimal? TotalProdutosVendas { get; set; }
        
         
    }
}
