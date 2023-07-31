using Infra.Repositorio.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entidades;
using Domain.Interfaces.IAnimal;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioAnimal : RepositoryGenerics<Animal>, InterfaceAnimal
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioAnimal()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>(); 

        }
        public Task AtualizarIdade(string idAnimal, int novaIdade)
        {
            throw new NotImplementedException();
        }

        public async Task<Animal> BuscarPorNome(string nomeAnimal)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var animal = await banco.Animais.AsNoTracking().FirstOrDefaultAsync(a => a.Nome == nomeAnimal);

                if (animal == null)
                {
                    throw new KeyNotFoundException($"No animal found with the name {nomeAnimal}");
                }
                return animal;
            }
        }
        public async Task<int> ContarAnimaisDoCliente(string idCliente)
        {
            int id = int.Parse(idCliente);  // Convert string to integer

            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Animais.CountAsync(a => a.ID_Cliente == id);
            }
        }

        public async Task<IList<Animal>> ListarAnimaisPorCliente(string idCliente)
        {
            int id = int.Parse(idCliente);  // Convert string to integer

            using (var banco = new ContextBase(_optionsBuilder))
            {
                var animais = from a in banco.Animais
                              where a.ID_Cliente == id
                              select a;

                return await animais.ToListAsync();
            }
        }

        public async Task<IList<Animal>> RemoverPorEspecie(string especie)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var animals = await banco.Animais
                                         .Where(a => a.Especie.Nome == especie)
                                         .ToListAsync();
                banco.Animais.RemoveRange(animals);
                await banco.SaveChangesAsync();
                return animals;
            }
        }

    }
}
