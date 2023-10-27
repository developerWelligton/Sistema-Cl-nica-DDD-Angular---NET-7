using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IFamilia;
using Domain.Interfaces.ISegmento;
using Domain.Interfaces.IUnspscCode;
using Domain.Interfaces.IVeterinario;
using Entities;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.DTO;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioUnspscCode : RepositoryGenerics<UnspscCode>, InterfaceUnspscCode
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioUnspscCode()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }

        public async Task<bool> CheckIfUnspscCodeExists(string codigoSfcm)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.UnspscCodes.AnyAsync(u => u.CodigoSfcm == codigoSfcm);
            }
        }

        public async Task<UnspscCode> GetNamesUnspscByCode(long id)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var unspscCode = await banco.UnspscCodes
                    .Include(u => u.Segmento)
                    .Include(u => u.Familia)
                    .Include(u => u.Classe)
                    .Include(u => u.Mercadoria)
                    .FirstOrDefaultAsync(u => u.IdUnspsc == id);

                return unspscCode;
            }
        }

        async Task<IList<UnspscCode>> InterfaceUnspscCode.GetAllUnspscCodeDetails()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.UnspscCodes
                    .Include(u => u.Segmento)
                    .Include(u => u.Familia)
                    .Include(u => u.Classe)
                    .Include(u => u.Mercadoria)
                    .ToListAsync();
            }
        }
    }
}
