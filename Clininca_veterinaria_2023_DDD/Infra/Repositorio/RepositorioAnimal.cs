using Infra.Repositorio.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entidades;
using Entities;
using Domain.Interfaces.IAnimal;

namespace Infra.Repositorio
{
    public class RepositorioAnimal : RepositoryGenerics<Animal>, InterfaceAnimal
    {
    }
}
