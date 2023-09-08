namespace WebApi.Model
{
    public class ProdutoEstoqueDto
    {
        public long IdProduto { get; set; }
        public int ID_Usuario { get; set; }
        public long IdEstoque { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public string? Status { get; set; }
    }
}
