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
    public class RepositorioItemProdutosEstoques : RepositoryGenerics<ItemProdutoEstoque>, InterfaceItemProdutoEstoque
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioItemProdutosEstoques()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }


        public async Task UpdateQuantidadeEstoque(int idEstoque, int idProduto, int novaQuantidade)
        {
            // Utilizando o contexto de forma adequada
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var item = await banco.ItensProdutoEstoques.FirstOrDefaultAsync(i => i.IdEstoque == idEstoque && i.IdProduto == idProduto);
                if (item != null)
                {
                    item.Quantidade_Estoque = novaQuantidade;
                    banco.Entry(item).State = EntityState.Modified; // Aqui você deve referenciar o contexto 'banco', não '_optionsBuilder'
                    await banco.SaveChangesAsync();
                }
            }
        }



    }
}
