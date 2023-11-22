﻿        using Domain.Interfaces.IAnimal;
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
                    Quantidade_Estoque = r.Quantidade_Estoque,
                    Produto = new Produto { Nome = r.Nome }  // Setting the 'Nome' value in the navigation property
                }).ToList();
            }
        }

        public async Task<List<ItemProdutoEstoque>> GetEstoquesByProdutos(int idProduto)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var result = await (from produto in banco.Produtos
                                    join itemEstoque in banco.ItensProdutoEstoques
                                    on produto.IdProduto equals itemEstoque.IdProduto
                                    where itemEstoque.IdProduto == idProduto
                                    select new
                                    {
                                        IdProduto = produto.IdProduto,
                                        IdEstoque = itemEstoque.IdEstoque,
                                        Nome = produto.Nome,  // Accessing 'Nome' using the navigation property
                                        Status = produto.Status,
                                        Quantidade_Estoque = itemEstoque.Quantidade_Estoque
                                    }).ToListAsync();

                return result.Select(r => new ItemProdutoEstoque
                {
                    IdProduto = r.IdProduto,
                    IdEstoque = r.IdEstoque,
                    Quantidade_Estoque = r.Quantidade_Estoque,
                    Produto = new Produto { Nome = r.Nome }  // Setting the 'Nome' value in the navigation property
                }).ToList();
            }
        }

        public async Task<IEnumerable<ItemProdutoEstoque>> GetByProdutoId(int idProduto)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var result = await banco.ItensProdutoEstoques
                                        .Where(item => item.IdProduto == idProduto)
                                        .ToListAsync();

                return result;
            }
        }

        public async Task UpdateStatusByProdutoId(int produtoId, int idEstoque)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                // Update all items with IdProduto = produtoId to Status = 0
                var itemsToUpdate = await banco.ItensProdutoEstoques
                                              .Where(i => i.IdProduto == produtoId)
                                              .ToListAsync();

                itemsToUpdate.ForEach(i => i.Status = "0");

                // Update the specific item with IdEstoque = 1 and IdProduto = 1 to Status = 1
                var specificItem = itemsToUpdate.FirstOrDefault(i => i.IdEstoque == idEstoque);
                if (specificItem != null)
                {
                    specificItem.Status = "1";
                }

                // Save the changes to the database
                await banco.SaveChangesAsync();
            }
        }
    }
}
