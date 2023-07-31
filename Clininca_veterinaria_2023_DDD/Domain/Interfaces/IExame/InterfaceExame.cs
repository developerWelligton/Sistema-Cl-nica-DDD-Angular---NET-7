using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IExame
{
    public interface InterfaceExame : InterfaceGeneric<Exame>
    {
        // Método personalizado para buscar um exame pelo nome
        Task<Exame> BuscarPorNome(string nome);

        // Método personalizado para buscar todos os exames com suas consultas associadas
        Task<IList<Exame>> BuscarExamesComConsultas();

        // Método personalizado para buscar todos os exames que não possuem consultas associadas
        Task<IList<Exame>> BuscarExamesSemConsultas();

        // Método personalizado para calcular o custo total de todos os exames
        Task<decimal> CalcularCustoTotal();

        // Outros métodos personalizados conforme as necessidades do sistema...

        // Nota: Lembre-se de que você pode adicionar mais métodos aqui para ações específicas 
        // relacionadas a exames na sua aplicação.
    }
}
