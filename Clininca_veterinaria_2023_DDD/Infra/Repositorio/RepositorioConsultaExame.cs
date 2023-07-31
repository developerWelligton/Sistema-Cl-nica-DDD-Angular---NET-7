using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IConsulta_Exame;
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
    public class RepositorioConsultaExame : RepositoryGenerics<Consulta_Exame>, InterfaceConsultaExame
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioConsultaExame()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }


        public async Task<IList<Consulta_Exame>> BuscarConsultasComExames()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consulta_Exames
                            .Include(ce => ce.Consulta)
                            .Include(ce => ce.Exame)
                            .ToListAsync();
            }
        }

        public async Task<IList<Consulta_Exame>> BuscarConsultasComExamesPorData(DateTime dataExame)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consulta_Exames
                            .Include(ce => ce.Consulta)
                            .Include(ce => ce.Exame)
                            .Where(ce => ce.DataExame == dataExame)
                            .ToListAsync();
            }
        }

        public async Task<IList<Consulta_Exame>> BuscarConsultasPorExame(int idExame)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consulta_Exames
                            .Include(ce => ce.Consulta)
                            .Include(ce => ce.Exame)
                            .Where(ce => ce.Exame.ID_Exame == idExame)
                            .ToListAsync();
            }
        }

        public async Task<IList<Consulta_Exame>> BuscarExamesPorConsulta(int idConsulta)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consulta_Exames
                            .Include(ce => ce.Consulta)
                            .Include(ce => ce.Exame)
                            .Where(ce => ce.Consulta.ID_Consulta == idConsulta)
                            .ToListAsync();
            }
        }
    }
} 
