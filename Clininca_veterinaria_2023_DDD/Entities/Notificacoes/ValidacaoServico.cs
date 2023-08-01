using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notificacoes
{
    public class ValidacaoServico
    {
        public bool ValidaPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                // Aqui você pode retornar uma lista de erros ou lançar uma exceção,
                // dependendo de como você quer lidar com os erros de validação.
                return false;
            }

            return true;
        }
    }
}
