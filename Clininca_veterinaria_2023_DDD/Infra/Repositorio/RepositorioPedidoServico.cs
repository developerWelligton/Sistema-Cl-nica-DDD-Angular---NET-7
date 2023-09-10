using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IPedidoServico;
using Domain.Interfaces.IVeterinario;
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
    public class RepositorioPedidoServico : RepositoryGenerics<PedidoServicos>, InterfacePedidoServico
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioPedidoServico()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
    }
}
