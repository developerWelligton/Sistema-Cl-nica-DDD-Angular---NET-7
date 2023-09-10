namespace WebApi.Model
{
    public class VendaDto
    {
        public long IdVenda { get; set; }
        public DateTime? DataVenda { get; set; }
        public string Status { get; set; }
        public int ID_Usuario { get; set; }
    }
}
