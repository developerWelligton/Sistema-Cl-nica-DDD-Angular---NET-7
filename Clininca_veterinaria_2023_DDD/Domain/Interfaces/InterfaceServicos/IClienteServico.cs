using Entities;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IClienteServico
    {
        public Task AdicionarCliente(Cliente cliente);
        public Task AtualizaCliente(Cliente cliente);
    }
}
