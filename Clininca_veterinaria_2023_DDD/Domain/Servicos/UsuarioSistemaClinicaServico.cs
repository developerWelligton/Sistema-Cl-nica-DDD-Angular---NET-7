using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Entities.Entidades;
using Entities.Notificacoes;
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
        private readonly ValidacaoServico _validacaoServico;

        public UsuarioSistemaClinicaServico(InterfaceUsuarioSistemaClinica interfaceUsuarioSistemaClinica, ValidacaoServico validacaoServico)
        {
            _interfaceUsuarioSistemaClinica = interfaceUsuarioSistemaClinica;
            _validacaoServico = validacaoServico;
        }

        public async Task CadastraUsuarioNoSistema(UsuarioSistemaClinica usuarioSistemaClinica)
        {
            var valido = _validacaoServico.ValidaPropriedadeString(usuarioSistemaClinica.Nome, "Nome");
            if (valido)
                await _interfaceUsuarioSistemaClinica.Add(usuarioSistemaClinica);
        }
    }

}
