using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio.DTO
{
    public class UnspscCodeDto
    {
        public int ID_Usuario { get; set; }
        public long IdUnspsc { get; set; }
        public string? CodigoSfcm { get; set; }
        public string? DescricaoSegmento { get; set; }
        public string? DescricaoFamilia { get; set; }
        public string? DescricaoClasse { get; set; }
        public string? DescricaoMercadoria { get; set; }
    }
}
