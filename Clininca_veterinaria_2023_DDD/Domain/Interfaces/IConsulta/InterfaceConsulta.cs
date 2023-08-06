using Domain.Interfaces.Generics;
using Entities;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IConsulta
{
    public interface InterfaceConsulta : InterfaceGeneric<Consulta>
    {
        // Método personalizado para buscar consultas de um determinado animal
        Task<IList<Consulta>> BuscarConsultasPorAnimal(int idAnimal);

        // Método personalizado para buscar consultas de um determinado veterinário
        Task<IList<Consulta>> BuscarConsultasPorVeterinario(int idVeterinario);

        // Método personalizado para buscar consultas marcadas para uma data específica
        Task<IList<Consulta>> BuscarConsultasPorData(DateTime dataConsulta);

        // Método personalizado para buscar consultas com seus exames associados
        Task<IList<Consulta>> BuscarConsultasComExames();

        // Método personalizado para buscar detalhes de um exame de uma consulta específica
        Task<Exame> BuscarExamePorConsulta(int idConsulta);

        // Outros métodos personalizados conforme as necessidades do sistema...

        // Nota: Lembre-se de que você pode adicionar mais métodos aqui para ações específicas 
        // relacionadas às consultas na sua aplicação.

        Task<int> CountAsync();

        // Novo método para listar com filtros
        Task<IList<Consulta>> ListWithFilters(
         string clienteNome = null,
         string animalNome = null,
         string veterinarioNome = null,
         DateTime? dataConsulta = null);

    }
}
