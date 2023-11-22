using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFamilia
{
    public interface InterfaceItemProdutoEstoque: InterfaceGeneric<ItemProdutoEstoque>
    {
        Task UpdateQuantidadeEstoque(int idEstoque, int idProduto, int novaQuantidade);

        Task UpdateQuantidadeEstoqueCompra(int estoqueId, int produtoId, int novaQuantidade);
        Task<int>  GetEstoqueByProduto(int idProduto);

        Task<List<ItemProdutoEstoque>> GetAllProdutoByStock(int idStock);

        Task<List<ItemProdutoEstoque>> GetEstoquesByProdutos(int idProduct);
        Task<IEnumerable<ItemProdutoEstoque>> GetByProdutoId(int idProduto);

        // toogle para alterar estoque/venda/compra
        Task UpdateStatusByProdutoId(int produtoId, int status);
    }
}
