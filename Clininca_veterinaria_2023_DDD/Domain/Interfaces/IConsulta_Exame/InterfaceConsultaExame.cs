using Domain.Interfaces.Generics;
using Entities;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IConsulta_Exame
{
    public interface InterfaceConsultaExame : InterfaceGeneric<Consulta_Exame>
    {
        // Método personalizado para buscar todas as consultas com os exames associados
        Task<IList<Consulta_Exame>> BuscarConsultasComExames();

        // Método personalizado para buscar todas as consultas de um determinado exame
        Task<IList<Consulta_Exame>> BuscarConsultasPorExame(int idExame);

        // Método personalizado para buscar todos os exames de uma determinada consulta
        Task<IList<Consulta_Exame>> BuscarExamesPorConsulta(int idConsulta);

        // Método personalizado para buscar consultas com exames em uma data específica
        Task<IList<Consulta_Exame>> BuscarConsultasComExamesPorData(DateTime dataExame);
        Task Add(Exame exame);

        // Outros métodos personalizados conforme as necessidades do sistema...

        // Nota: Lembre-se de que você pode adicionar mais métodos aqui para ações específicas 
        // relacionadas a consultas e exames na sua aplicação.
    }
}
