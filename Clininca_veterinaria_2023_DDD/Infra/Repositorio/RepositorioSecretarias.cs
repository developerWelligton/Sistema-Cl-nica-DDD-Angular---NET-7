using Domain.Interfaces.IAnimal;
using Domain.Interfaces.ISecretarias;
using Entities;
using Entities.Entidades;
using Infra.Repositorio.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioSecretarias : RepositoryGenerics<Secretaria>, InterfaceSecretarias
    {
    }
}
