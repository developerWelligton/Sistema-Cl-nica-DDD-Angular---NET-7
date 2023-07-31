using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ISecretarias
{
    public interface InterfaceSecretarias : InterfaceGeneric<Secretaria>
    {
        Task<Secretaria> BuscarPorNome(string nome);

        // Método personalizado para buscar uma secretária pelo endereço de e-mail
        Task<Secretaria> BuscarPorEmail(string email);

        // Método personalizado para buscar todas as secretárias que possuem consultas associadas
        Task<IList<Secretaria>> BuscarSecretariasComConsultas();

        // Método personalizado para buscar todas as secretárias que não possuem consultas associadas
        Task<IList<Secretaria>> BuscarSecretariasSemConsultas();

        // Método personalizado para atualizar o endereço de uma secretária
        Task AtualizarEndereco(int idSecretaria, string novoEndereco);

        // Outros métodos personalizados conforme as necessidades do sistema...

        // Nota: Lembre-se de que você pode adicionar mais métodos aqui para ações específicas 
        // relacionadas a secretárias na sua aplicação.
    }
}
