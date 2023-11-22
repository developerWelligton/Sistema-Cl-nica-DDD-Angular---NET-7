using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IEstoque;
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
    public class RepositorioEstoque : RepositoryGenerics<Estoque>, InterfaceEstoque
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioEstoque()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }

        public async Task<IEnumerable<Estoque>> GetAllStockByProductId(int productId)
        {
            // Exemplo de implementação, ajuste conforme a lógica de seu negócio
            using (var data = new ContextBase(_optionsBuilder))
            {
                // A lógica a seguir é um exemplo e deve ser ajustada de acordo
                // com a estrutura de dados e relacionamento entre estoques e produtos
                var estoques = await data.Estoques
                    // .Where(e => e.ProdutoId == productId) // Exemplo de filtro
                    .ToListAsync();

                return estoques;
            }
        }


    }
}
