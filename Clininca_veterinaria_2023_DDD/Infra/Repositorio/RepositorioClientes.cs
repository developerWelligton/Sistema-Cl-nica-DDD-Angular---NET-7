using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IClientes;
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
    public class RepositorioClientes : RepositoryGenerics<Cliente>, InterfaceClientes
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioClientes()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task AtualizarEndereco(int idCliente, string novoEndereco)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var cliente = await banco.Clientes.FindAsync(idCliente);
                if (cliente != null)
                {
                    cliente.Endereco = novoEndereco;
                    banco.Entry(cliente).State = EntityState.Modified;
                    await banco.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("Cliente not found");
                }
            }
        }

       

        public async Task<Cliente> BuscarPorEmail(string email)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var cliente = await banco.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
                if (cliente == null)
                {
                    throw new KeyNotFoundException("No Cliente found with the provided email");
                }
                return cliente;
            }
        }

        public async Task<IList<Cliente>> BuscarPorNome(string nome)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Clientes.AsNoTracking().Where(c => c.Nome.Contains(nome)).ToListAsync();
            }
        }

        public async Task<IList<Cliente>> BuscarPorTelefone(string telefone)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Clientes.AsNoTracking().Where(c => c.TelefoneMovel == telefone).ToListAsync();
            }
        }

        public async Task<int> ContarTotalClientes()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Clientes.CountAsync();
            }
        }
         

        public async Task<IEnumerable<Cliente>> SearchByName(string term)
        {


            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Clientes.Where(a => a.Nome.Contains(term))
                .ToListAsync();
            };
        }



        public async Task<Cliente> BuscarClientePorIdUsuarioSistema(int idUsuarioSistema)
        {
            using (var context = new ContextBase(_optionsBuilder))
            {
                var cliente = await context.Clientes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.ID_Usuario == idUsuarioSistema);

                if (cliente == null)
                {
                    throw new KeyNotFoundException($"No Cliente associated with ID_Usuario: {idUsuarioSistema} was found.");
                }

                return cliente;
            }
        }
        /*
        public async Task<IEnumerable<Cliente>> ListarClientesComAnimais()
        {
            using (var context = new ContextBase(_optionsBuilder))
            {
                return await context.Clientes
                    .Include(c => c.Animais)  // Aqui você faz o Eager Loading dos animais
                    .AsNoTracking()
                    .ToListAsync();
            }
        }*/

    }
}
