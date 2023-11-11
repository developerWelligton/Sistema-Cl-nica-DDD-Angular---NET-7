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
 

        public async Task UpdateQuantidadeEstoque(int idEstoque, int idProduto, int quantidadeASubtrair)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                // Encontrar o item específico com base no IdEstoque e IdProduto
                var item = await banco.ItensProdutoEstoques
                                      .FirstOrDefaultAsync(i => i.IdEstoque == idEstoque && i.IdProduto == idProduto);
                if (item != null)
                {
                    // Subtrair a quantidade especificada da Quantidade_Estoque
                    item.Quantidade_Estoque -= quantidadeASubtrair;

                    // Você pode adicionar uma verificação para garantir que a quantidade não se torne negativa
                    if (item.Quantidade_Estoque < 0)
                    {
                        // Definir para 0 ou lidar com a situação como preferir (ex: lançar uma exceção)
                        item.Quantidade_Estoque = 0;
                    }

                    // Marcar o item como modificado
                    banco.Entry(item).State = EntityState.Modified;
                    // Salvar as mudanças no banco de dados
                    await banco.SaveChangesAsync();
                }
                else
                {
                    // Lidar com o caso onde o item não foi encontrado (ex: lançar uma exceção ou retornar algum erro)
                }
            }
        }
        public async Task UpdateQuantidadeEstoqueCompra(int idEstoque, int idProduto, int quantidadeASubtrair)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                // Encontrar o item específico com base no IdEstoque e IdProduto
                var item = await banco.ItensProdutoEstoques
                                      .FirstOrDefaultAsync(i => i.IdEstoque == idEstoque && i.IdProduto == idProduto);
                if (item != null)
                {
                    // Subtrair a quantidade especificada da Quantidade_Estoque
                    item.Quantidade_Estoque += quantidadeASubtrair;

                    // Você pode adicionar uma verificação para garantir que a quantidade não se torne negativa
                    if (item.Quantidade_Estoque < 0)
                    {
                        // Definir para 0 ou lidar com a situação como preferir (ex: lançar uma exceção)
                        item.Quantidade_Estoque = 0;
                    }

                    // Marcar o item como modificado
                    banco.Entry(item).State = EntityState.Modified;
                    // Salvar as mudanças no banco de dados
                    await banco.SaveChangesAsync();
                }
                else
                {
                    // Lidar com o caso onde o item não foi encontrado (ex: lançar uma exceção ou retornar algum erro)
                }
            }
        }

        public async Task<int> GetEstoqueByProduto(int idProduto)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                // Encontrar o item específico com base no IdProduto
                var item = await banco.ItensProdutoEstoques
                                      .FirstOrDefaultAsync(i => i.IdProduto == idProduto);

                // Se o item for encontrado, retornar o ID_ESTOQUE, caso contrário, retornar nulo.
                return (int)(int?)(item?.IdEstoque);
            }
        }



        public async Task<List<ItemProdutoEstoque>> GetAllProdutoByStock(int idStock)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var result = await (from produto in banco.Produtos
                                    join itemEstoque in banco.ItensProdutoEstoques
                                    on produto.IdProduto equals itemEstoque.IdProduto
                                    where itemEstoque.IdEstoque == idStock
                                    select new
                                    {
                                        IdProduto = produto.IdProduto,
                                        Nome = produto.Nome,  // Accessing 'Nome' using the navigation property
                                        Status = produto.Status,
                                        Quantidade_Estoque = itemEstoque.Quantidade_Estoque
                                    }).ToListAsync();

                return result.Select(r => new ItemProdutoEstoque
                {
                    IdProduto = r.IdProduto,
                    Status = r.Status,
                    Quantidade_Estoque = r.Quantidade_Estoque,
                    Produto = new Produto { Nome = r.Nome }  // Setting the 'Nome' value in the navigation property
                }).ToList();
            }
        }

       

    }
}
