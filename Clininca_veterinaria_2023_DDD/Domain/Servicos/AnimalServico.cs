﻿using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class AnimalServico : IAnimalServico
    {
        private readonly InterfaceAnimal _interfaceAnimal;
        public AnimalServico(InterfaceAnimal interfaceAnimal)
        {
            _interfaceAnimal = interfaceAnimal;
        }

        public async Task AdicionarAnimal(Animal animal)
        {
            var valido = animal.ValidaPropriedadeString(animal.Nome, "Nome");
            if (valido)
                await _interfaceAnimal.Add(animal);
        }

        public async Task AtualizaAnimal(Animal animal)
        {
            var valido = animal.ValidaPropriedadeString(animal.Nome, "Nome");
            if (valido)
                await _interfaceAnimal.Update(animal);
        }
    }
}
