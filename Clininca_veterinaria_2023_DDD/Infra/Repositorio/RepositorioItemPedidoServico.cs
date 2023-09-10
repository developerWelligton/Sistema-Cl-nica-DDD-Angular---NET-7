using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IFamilia;
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
    public class RepositorioItemPedidoServico : RepositoryGenerics<PedidoServicosRelacao>, InterfaceItemPedidoServico
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioItemPedidoServico()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
        
    }
}
