using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IEspecie;
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
    public class RepositorioEspecie : RepositoryGenerics<Especie>, InterfaceEspecie
    {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioEspecie()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task<IList<Especie>> BuscarEspeciesComAnimais()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var especiesComAnimais = await (from e in banco.Especies
                                                join a in banco.Animais on e.ID_Especie equals a.ID_Especie
                                                select e).Distinct().ToListAsync();

                return especiesComAnimais;
            }
        }
        public async Task<IList<Especie>> BuscarEspeciesSemAnimais()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var especiesComAnimais = await (from e in banco.Especies
                                                join a in banco.Animais on e.ID_Especie equals a.ID_Especie into ea
                                                from animal in ea.DefaultIfEmpty()
                                                where animal == null
                                                select e).Distinct().ToListAsync();

                return especiesComAnimais;
            }
        }

        public async Task<Especie> BuscarPorNome(string nome)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Especies.FirstOrDefaultAsync(e => e.Nome == nome);
            }
        }

        public async Task<int> ContarAnimaisPorEspecie(int idEspecie)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Animais.CountAsync(a => a.ID_Especie == idEspecie);
            }
        }
    }
}
