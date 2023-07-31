using Domain.Interfaces.Generics;
using Domain.Interfaces.IConsulta_Exame;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IEspecie
{
    public interface InterfaceEspecie : InterfaceGeneric<Especie>
    {
        // Método personalizado para buscar uma espécie pelo nome
        Task<Especie> BuscarPorNome(string nome);

        // Método personalizado para buscar todas as espécies que possuem animais associados
        Task<IList<Especie>> BuscarEspeciesComAnimais();

        // Método personalizado para buscar todas as espécies que não possuem animais associados
        Task<IList<Especie>> BuscarEspeciesSemAnimais();

        // Método personalizado para contar o número de animais de uma determinada espécie
        Task<int> ContarAnimaisPorEspecie(int idEspecie);

        // Outros métodos personalizados conforme as necessidades do sistema...

        // Nota: Lembre-se de que você pode adicionar mais métodos aqui para ações específicas 
        // relacionadas a espécies na sua aplicação.
    }
}
