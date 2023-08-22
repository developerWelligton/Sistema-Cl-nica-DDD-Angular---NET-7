
using Domain.Interfaces.Generics;
using Entities;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IClientes
{
    public interface InterfaceClientes : InterfaceGeneric<Cliente>
    {
        // Método personalizado para buscar clientes por seu nome
        Task<IList<Cliente>> BuscarPorNome(string nome);

        // Método personalizado para buscar clientes por seu endereço de e-mail
        Task<Cliente> BuscarPorEmail(string email);

        // Método personalizado para buscar clientes por seu número de telefone
        Task<IList<Cliente>> BuscarPorTelefone(string telefone);

        // Método personalizado para atualizar o endereço de um cliente
        Task AtualizarEndereco(int idCliente, string novoEndereco);

        // Método personalizado para obter o total de clientes registrados
        Task<int> ContarTotalClientes();

        // Outros métodos personalizados conforme as necessidades do sistema...

        // Nota: Lembre-se de que você pode adicionar mais métodos aqui para ações específicas 
        // relacionadas aos clientes na sua aplicação.
        Task<IEnumerable<Cliente>> SearchByName(string term);
         
        Task<Cliente> BuscarClientePorIdUsuarioSistema(int idUsuarioSistema);
        Task<IEnumerable<Cliente>> ListarClientesComAnimais();
    }
}
