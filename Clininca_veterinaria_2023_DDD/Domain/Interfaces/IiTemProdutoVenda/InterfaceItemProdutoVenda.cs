using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFamilia
{
    public interface InterfaceItemProdutoVenda: InterfaceGeneric<ItemProdutoVenda>
    {
        Task<IEnumerable<ItemProdutoVenda>> GetVendaDetailsAsync(string vendaId);

        // Método para deletar um item de produto por venda
        Task DeleteItemProdutoPorVendaAsync(int idProduto, int idVenda);
    }
}
