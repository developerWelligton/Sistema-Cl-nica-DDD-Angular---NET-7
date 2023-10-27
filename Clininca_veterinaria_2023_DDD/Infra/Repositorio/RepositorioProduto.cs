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
    public class RepositorioProduto: RepositoryGenerics<Produto>, InterfaceProduto
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioProduto()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }

        public async Task<IList<Produto>> GetAllProductWithInspsc()
        {
            using (var context = new ContextBase(_optionsBuilder))
            {
                var result = await context.Produtos
                    .Include(p => p.UnspscCode)
                    .Select(p => new
                    {
                        Produto = p,
                        CodigoSfcm = p.UnspscCode.CodigoSfcm
                    })
                    .ToListAsync();

                result.ForEach(r => r.Produto.CodigoSfcm = r.CodigoSfcm);

                return result.Select(r => r.Produto).ToList();
            }
        }

        public async Task<Produto> GetProductById(long productId)
        {
            using (var context = new ContextBase(_optionsBuilder))
            {
                return await context.Produtos.FindAsync(productId);
            }
        }
    }
}
