using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IAnimalServico
    {
        public Task AdicionarAnimal(Animal animal);
        public Task AtualizaAnimal(Animal animal);
    }
}
