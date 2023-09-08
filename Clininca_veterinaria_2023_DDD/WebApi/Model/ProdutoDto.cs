namespace WebApi.Model
{
    public class ProdutoDto
    {
        public long IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public string Status { get; set; }
        public int ID_Usuario { get; set; }
        public long IdUnspsc { get; set; }
    }
}
