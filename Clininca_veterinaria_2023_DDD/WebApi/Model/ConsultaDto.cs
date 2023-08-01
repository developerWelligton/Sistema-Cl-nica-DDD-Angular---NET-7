 
namespace WebApi.Model
{
    public class ConsultaDto
    {
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }
        public int ID_Veterinario { get; set; }
        public int ID_Animal { get; set; }
    }
}