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

        public Task<IList<Consulta>> BuscarConsultasPorData(DateTime dataConsulta)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Consulta>> BuscarConsultasPorUsuario(int idUsuario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consultas
                            .Include(c => c.Animal)  // Incluir detalhes do Animal 
                            .Where(c => c.ID_Usuario == idUsuario)
                            .ToListAsync();
            }
        }



        /*
        public async Task<IList<Consulta>> BuscarConsultasPorData(DateTime dataConsulta)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consultas
                            .Where(c => c.DataConsulta.Date == dataConsulta.Date)
                            .ToListAsync();
            }
        }*/

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

        public async Task<int> CountAsync()
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Consultas.CountAsync();
            }
        }

        public Task<IList<Consulta>> ListWithFilters(string clienteNome = null, string animalNome = null, string veterinarioNome = null, DateTime? dataConsulta = null)
        {
            throw new NotImplementedException();
        }


        /*
        public async Task<IList<Consulta>> ListWithFilters(
     string clienteNome = null,
     string animalNome = null,
     string veterinarioNome = null,
     DateTime? dataConsulta = null)  // Adicionado parâmetro para filtro por data
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var consultas = banco.Consultas.AsQueryable();

                if (!string.IsNullOrEmpty(clienteNome))
                {
                    consultas = consultas.Where(c => c.Animal.Cliente.Nome == clienteNome);
                }
                if (!string.IsNullOrEmpty(animalNome))
                {
                    consultas = consultas.Where(c => c.Animal.Nome == animalNome);
                }
                if (!string.IsNullOrEmpty(veterinarioNome))
                {
                    consultas = consultas.Where(c => c.Veterinario.Nome == veterinarioNome);
                }

                // Filtro por data:
                if (dataConsulta.HasValue)
                {
                    consultas = consultas.Where(c => c.DataConsulta.Date == dataConsulta.Value.Date);
                }

                return await consultas.ToListAsync();
            }
        }*/

    }
} 
