using Domain.Interfaces.IAnimal;
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
    public class RepositorioSegmento: RepositoryGenerics<Segmento>, InterfaceSegmento
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositorioSegmento()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();

        }
  
    }
}
