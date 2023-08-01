using Domain.Interfaces.IClientes;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Entities.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly InterfaceClientes _interfaceClientes;
        private readonly ValidacaoServico _validacaoServico;

        public ClienteServico(InterfaceClientes interfaceClientes, ValidacaoServico validacaoServico)
        {
            _interfaceClientes = interfaceClientes;
            _validacaoServico = validacaoServico;
        }

        public async Task AdicionarCliente(Cliente cliente)
        {
            var valido = _validacaoServico.ValidaPropriedadeString(cliente.Nome, "Nome");
            if (valido)
                await _interfaceClientes.Add(cliente);
        }

        public async Task AtualizaCliente(Cliente cliente)
        {
            var valido = _validacaoServico.ValidaPropriedadeString(cliente.Nome, "Nome");
            if (valido)
                await _interfaceClientes.Update(cliente);
        }
    }
}
