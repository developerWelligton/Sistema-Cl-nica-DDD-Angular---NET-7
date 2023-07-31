using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IClientes;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISecretarias;
using Entities.Entidades;
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

        public ClienteServico(InterfaceClientes interfaceClientes)
        {
            _interfaceClientes = interfaceClientes;
        }

        public async Task AdicionarCliente(Cliente cliente)
        {
            var valido = cliente.ValidaPropriedadeString(cliente.Nome, "Nome");
            if (valido)
                await _interfaceClientes.Add(cliente);
        }

        public async Task AtualizaCliente(Cliente cliente)
        {
            var valido = cliente.ValidaPropriedadeString(cliente.Nome, "Nome");
            if (valido)
                await _interfaceClientes.Update(cliente);
        }
    }
}
