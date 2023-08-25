    using Domain.Interfaces.Generics;
    using Entities.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Domain.Interfaces.IVeterinario
    {
        public interface InterfaceVeterinario : InterfaceGeneric<Veterinario>
        {
        // Método personalizado para buscar um veterinário pelo nome
        Task<Veterinario> BuscarPorNome(string nome);

        // Método personalizado para buscar um veterinário pelo endereço de e-mail
        Task<Veterinario> BuscarPorEmail(string email);

        // Método personalizado para buscar todos os veterinários que possuem consultas associadas
        Task<IList<Veterinario>> BuscarVeterinariosComConsultas();

        // Método personalizado para buscar todos os veterinários que não possuem consultas associadas
        Task<IList<Veterinario>> BuscarVeterinariosSemConsultas();

        // Método personalizado para buscar veterinários por especialização
        Task<IList<Veterinario>> BuscarPorEspecializacao(string especializacao);

        // Outros métodos personalizados conforme as necessidades do sistema...

        // Nota: Lembre-se de que você pode adicionar mais métodos aqui para ações específicas 
        // relacionadas aos veterinários na sua aplicação.

        Task<IEnumerable<Veterinario>> SearchByName(string term);

        //buscar veterinario por usuario Id
        Task<Veterinario> GetVeterinarioByUserId(int userId);
    }
}
