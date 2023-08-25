using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUsuarioSistemaClinica
{
    public interface InterfaceUsuarioSistemaClinica : InterfaceGeneric<UsuarioSistemaClinica>
    {


        // Método personalizado para buscar um usuário pelo nome
        Task<UsuarioSistemaClinica> BuscarPorNome(string nome);

        // Método personalizado para buscar um usuário pelo endereço de e-mail
        Task<UsuarioSistemaClinica> BuscarPorEmail(string email);

        // Método personalizado para buscar todos os usuários com um determinado papel (role)
        Task<IList<UsuarioSistemaClinica>> BuscarPorPapel(string papel);

        // Método personalizado para verificar se o usuário tem permissão para uma determinada ação
        Task<bool> VerificarPermissao(int idUsuario, string acao);
        Task DeleteByUsuarioId(int idUsuario);
        Task<UsuarioSistemaClinica> BuscarUsuarioPorIdUsuarioSistema(int id);

        // Outros métodos personalizados conforme as necessidades do sistema...
         
        // Método para buscar o usuário pelo CPF usando SQL nativo
        Task<UsuarioSistemaClinica> GetUserByCPFAsync(string cpf);

    }
}
