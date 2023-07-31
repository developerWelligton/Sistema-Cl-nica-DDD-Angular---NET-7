using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class UsuarioSistemaClinicaServico : IUsuarioSistemaClinicaServico
    {
        private readonly InterfaceUsuarioSistemaClinica _interfaceUsuarioSistemaClinica;
        public UsuarioSistemaClinicaServico(InterfaceUsuarioSistemaClinica interfaceUsuarioSistemaClinica)
        {
            _interfaceUsuarioSistemaClinica = interfaceUsuarioSistemaClinica;
        }
        public async Task CadastraUsuarioNoSistema(UsuarioSistemaClinica usuarioSistemaClinica)
        {
            var valido = usuarioSistemaClinica.ValidaPropriedadeString(usuarioSistemaClinica.Nome, "Nome");
            if (valido)
                await _interfaceUsuarioSistemaClinica.Add(usuarioSistemaClinica);
        }
    }
}
