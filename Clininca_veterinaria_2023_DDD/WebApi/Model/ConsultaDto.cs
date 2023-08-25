namespace WebApi.Model
{
    public enum StatusConsultaDto
    {
        Pendente,
        Concluido
    }

    public class ConsultaDto
    {
        public int ID_Usuario { get; set; }
        public DateTime DataMarcacao { get; set; } // Data em que a consulta foi marcada
        public DateTime InicioConsulta { get; set; }
        public DateTime FimConsulta { get; set; }
        public string Descricao { get; set; }
        public int ID_Veterinario { get; set; }
        public int ID_Animal { get; set; }
        public StatusConsultaDto Status { get; set; }

      
    }
}
