    using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IFamilia;
using Domain.Interfaces.ISegmento;
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
    public class RepositorioItemProdutosVendas : RepositoryGenerics<ItemProdutoVenda>, InterfaceItemProdutoVenda
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioItemProdutosVendas()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }




        public async Task<IEnumerable<ItemProdutoVenda>> GetVendaDetailsAsync(string vendaId)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var query = from v in banco.Vendas
                            join ipv in banco.ItensPordutoVendas on v.IdVenda equals ipv.IdVenda
                            where v.IdVenda.ToString() == vendaId.ToString()
                            select ipv;

                return await query.ToListAsync();
            }
        }
    }
}
