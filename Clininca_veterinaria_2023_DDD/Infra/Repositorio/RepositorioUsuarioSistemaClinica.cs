using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IUsuarioSistemaClinica;
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
    public class RepositorioUsuarioSistemaClinica : RepositoryGenerics<UsuarioSistemaClinica>, InterfaceUsuarioSistemaClinica

    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioUsuarioSistemaClinica()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task<UsuarioSistemaClinica> BuscarPorEmail(string email)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.UsuarioSistemaClinicas.FirstOrDefaultAsync(u => u.Email == email);
            }
        }

        public async Task<UsuarioSistemaClinica> BuscarPorNome(string nome)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.UsuarioSistemaClinicas.FirstOrDefaultAsync(u => u.Nome == nome);
            }
        }

        public async Task<IList<UsuarioSistemaClinica>> BuscarPorPapel(string papel)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.UsuarioSistemaClinicas.Where(u => u.Role == papel).ToListAsync();
            }
        }

        public async Task<UsuarioSistemaClinica> BuscarUsuarioPorIdUsuarioSistema(int idUsuario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var usuarioSistema = await banco.UsuarioSistemaClinicas.FindAsync(idUsuario);
                if (usuarioSistema == null)
                {
                    throw new NotImplementedException();
                }
                return usuarioSistema;
            }
        }

        public Task DeleteByUsuarioId(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerificarPermissao(int idUsuario, string acao)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var usuario = await banco.UsuarioSistemaClinicas.FindAsync(idUsuario);
                if (usuario != null)
                {
                    // Assuming Role is the field representing the user's permissions
                    // and "acao" is the exact string representing the required permission
                    // This would need to be adjusted based on the actual structure of your permission system
                    return usuario.Role.Contains(acao);
                }
                return false;
            }
        }
    }
}
