using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IExame;
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
    public class RepositorioExame : RepositoryGenerics<Exame>, InterfaceExame
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioExame()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task<IList<Exame>> BuscarExamesComConsultas()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var examesComConsultas = await (from e in banco.Exames
                                                join ce in banco.Consulta_Exames on e.ID_Exame equals ce.ID_Exame
                                                select e).Distinct().ToListAsync();

                return examesComConsultas;
            }
        }

        public async Task<IList<Exame>> BuscarExamesSemConsultas()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var examesSemConsultas = await (from e in banco.Exames
                                                join ce in banco.Consulta_Exames on e.ID_Exame equals ce.ID_Exame into exameConsulta
                                                from ec in exameConsulta.DefaultIfEmpty()
                                                where ec == null
                                                select e).Distinct().ToListAsync();

                return examesSemConsultas;
            }
        }

        public async Task<Exame> BuscarPorNome(string nome)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Exames.FirstOrDefaultAsync(e => e.Nome == nome);
            }
        }

        public async Task<decimal> CalcularCustoTotal()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Exames.SumAsync(e => e.Custo);
            }
        }
    }
}
