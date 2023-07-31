using Domain.Interfaces.IAnimal;
using Domain.Interfaces.ISecretarias;
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
    public class RepositorioSecretarias : RepositoryGenerics<Secretaria>, InterfaceSecretarias
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioSecretarias()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task AtualizarEndereco(int idSecretaria, string novoEndereco)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var secretaria = await banco.Secretarias.FindAsync(idSecretaria);
                if (secretaria != null)
                {
                    secretaria.Endereco = novoEndereco;
                    banco.Secretarias.Update(secretaria);
                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task<Secretaria> BuscarPorEmail(string email)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Secretarias.FirstOrDefaultAsync(s => s.Email == email);
            }
        }

        public async Task<Secretaria> BuscarPorNome(string nome)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Secretarias.FirstOrDefaultAsync(s => s.Nome == nome);
            }
        }

        public async Task<IList<Secretaria>> BuscarSecretariasComConsultas()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                // Please update this query according to your exact database structure
                // Currently, it's not clear from the code or database structure 
                // how Secretarias and Consultas are related.
                throw new NotImplementedException();
            }
        }

        public async Task<IList<Secretaria>> BuscarSecretariasSemConsultas()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                // Please update this query according to your exact database structure
                // Currently, it's not clear from the code or database structure 
                // how Secretarias and Consultas are related.
                throw new NotImplementedException();
            }
        }
    }
}
