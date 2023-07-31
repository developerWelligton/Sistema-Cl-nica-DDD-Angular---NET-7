using Domain.Interfaces.Generics;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IAnimal
{
    public interface InterfaceAnimal: InterfaceGeneric<Animal>
    {
        // Método personalizado para listar animais de um cliente específico
        Task<IList<Animal>> ListarAnimaisPorCliente(string idCliente);

        // Método personalizado para buscar um animal por seu nome
        Task<Animal> BuscarPorNome(string nomeAnimal);

        // Método personalizado para contar a quantidade de animais de um cliente
        Task<int> ContarAnimaisDoCliente(string idCliente);

        // Método personalizado para atualizar a idade de um animal
        Task AtualizarIdade(string idAnimal, int novaIdade);

        // Método personalizado para remover animais com base na espécie
        Task<IList<Animal>> RemoverPorEspecie(string especie);

        // Outros métodos personalizados conforme as necessidades do sistema...

        // Nota: Lembre-se de que você pode adicionar métodos aqui para ações específicas 
        // relacionadas a animais na sua aplicação.
    }
} 
  