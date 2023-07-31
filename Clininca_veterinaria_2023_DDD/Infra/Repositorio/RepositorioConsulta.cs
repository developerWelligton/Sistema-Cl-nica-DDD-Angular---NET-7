using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IConsulta;
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
    public class RepositorioConsulta : RepositoryGenerics<Consulta>, InterfaceConsulta
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioConsulta()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
        public async Task<IList<Consulta>> BuscarConsultasComExames()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await (from consulta in banco.Consultas
                              join consulta_exame in banco.Consulta_Exames on consulta.ID_Consulta equals consulta_exame.ID_Consulta
                              select consulta).Distinct().ToListAsync();
            }
        }


        public async Task<IList<Consulta>> BuscarConsultasPorAnimal(int idAnimal)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consultas
                            .Where(c => c.ID_Animal == idAnimal)
                            .ToListAsync();
            }
        }

        public async Task<IList<Consulta>> BuscarConsultasPorData(DateTime dataConsulta)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consultas
                            .Where(c => c.DataConsulta.Date == dataConsulta.Date)
                            .ToListAsync();
            }
        }

        public async Task<IList<Consulta>> BuscarConsultasPorVeterinario(int idVeterinario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consultas
                            .Where(c => c.ID_Veterinario == idVeterinario)
                            .ToListAsync();
            }
        }

        public async Task<Exame> BuscarExamePorConsulta(int idConsulta)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var consultaExame = await banco.Consulta_Exames
                                        .Include(ce => ce.Exame)
                                        .Where(ce => ce.ID_Consulta == idConsulta)
                                        .FirstOrDefaultAsync();
                return consultaExame?.Exame;
            }
        }
    }
} 
