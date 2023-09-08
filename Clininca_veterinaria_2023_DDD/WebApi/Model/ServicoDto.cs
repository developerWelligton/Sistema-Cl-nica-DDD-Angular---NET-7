namespace WebApi.Model
{
    public class ServicoDto
    {
        public long IdServico { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int ID_Usuario { get; set; }
        public long IdUnspsc { get; set; }
    }
}
