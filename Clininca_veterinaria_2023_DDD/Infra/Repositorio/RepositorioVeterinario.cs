using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IVeterinario;
using Entities;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioVeterinario : RepositoryGenerics<Veterinario>, InterfaceVeterinario
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioVeterinario()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task<Veterinario> BuscarPorEmail(string email)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Veterinarios.FirstOrDefaultAsync(v => v.Email == email);
            }
        }

        public async Task<IList<Veterinario>> BuscarPorEspecializacao(string especializacao)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Veterinarios.Where(v => v.Especializacao == especializacao).ToListAsync();
            }
        }

        public async Task<Veterinario> BuscarPorNome(string nome)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Veterinarios.FirstOrDefaultAsync(v => v.Nome == nome);
            }
        }

        public Task<IList<Veterinario>> BuscarVeterinariosComConsultas()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Veterinario>> BuscarVeterinariosSemConsultas()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Animal>> SearchByName(string term)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Veterinario>> InterfaceVeterinario.SearchByName(string term)
        {
            throw new NotImplementedException();
        }
    }
}
