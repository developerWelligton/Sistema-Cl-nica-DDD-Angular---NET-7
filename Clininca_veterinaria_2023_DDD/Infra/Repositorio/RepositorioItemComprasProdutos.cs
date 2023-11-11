using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IiTemCompraProduto;
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
    public class RepositorioItemComprasProdutos : RepositoryGenerics<ItemProdutoCompra>, InterfaceItemCompraProduto
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioItemComprasProdutos()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }

        
        public async Task<List<ItemProdutoCompra>> GetAllProdutoByBuy(int idCompra)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                // Realizar consulta LINQ para buscar itens de produto associados à compra
                var query = from item in banco.ItensProdutoCompras
                            where item.IdCompra == idCompra
                            select item;

                return await query.ToListAsync();
            }
        }
    }
}
