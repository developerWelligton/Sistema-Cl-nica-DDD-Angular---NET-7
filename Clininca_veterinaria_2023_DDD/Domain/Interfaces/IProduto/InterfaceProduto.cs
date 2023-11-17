using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFamilia
{
    public interface InterfaceProduto: InterfaceGeneric<Produto>
    {
        Task<IList<Produto>> GetAllProductWithInspsc();

        Task<IList<Produto>> GetAllProductFromInspsc(int idUnspsc);

        Task<Produto> GetProductById(long productId);
    }
}
