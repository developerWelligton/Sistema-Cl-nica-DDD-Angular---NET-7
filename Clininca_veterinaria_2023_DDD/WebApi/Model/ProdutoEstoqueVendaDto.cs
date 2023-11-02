namespace WebApi.Model
{
    public class ProdutoEstoqueVendaDTO
    {
        public long IdProduto { get; set; } 
        public long IdEstoque { get; set; }
        public int QuantidadeVendida { get; set; }
    }
}
