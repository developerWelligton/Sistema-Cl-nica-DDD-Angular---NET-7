namespace WebApi.Model
{
    public class ClienteDto
    {
        public int ID_Cliente { get; set; } // Adicione esta linha
        public string Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int ID_Usuario { get; set; }
         public List<AnimalDto> Animais { get; set; }
    }

}
