    using Domain.Interfaces.Generics;
    using Entities.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Domain.Interfaces.IiTemCompraProduto
    {
    public interface InterfaceItemCompraProduto : InterfaceGeneric<ItemProdutoCompra>
    { 
        Task<List<ItemProdutoCompra>> GetAllProdutoByBuy(int idCompra);
    }
}
