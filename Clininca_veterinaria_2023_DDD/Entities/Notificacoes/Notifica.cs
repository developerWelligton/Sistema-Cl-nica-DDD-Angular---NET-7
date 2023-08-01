using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Notificacoes
{
    public class Notifica
    {

        public Notifica()
        {
                notificacoes = new List<Notifica>();
        }
        [JsonIgnore]
        [NotMapped]
        public string NomePropriedade { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string mensagem { get; set;}

        [NotMapped]
        public List<Notifica> notificacoes;

        public bool ValidaPropriedadeString(string valor, string nomePropriedade)
        {
            if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new Notifica
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }

            return false;
        }

        public bool ValidaPropriedadeInt(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new Notifica
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }

            return false;
        }

    }
}
