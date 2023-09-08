namespace WebApi.Model
{
    public class EstoqueDto
    {
        public long IdEstoque { get; set; }
        public string Sala { get; set; }
        public string Prateleira { get; set; }
        public int? Quantidade { get; set; }
        public int ID_Usuario { get; set; } 
    }
}
