using Domain.Interfaces.IEspecie; 
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Entities.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class EspecieServico : IEspecieServico
    {
        private readonly InterfaceEspecie _interfaceEspecies;
        private readonly ValidacaoServico _validacaoServico;

        public EspecieServico(InterfaceEspecie interfaceEspecies, ValidacaoServico validacaoServico)
        {
            _interfaceEspecies = interfaceEspecies;
            _validacaoServico = validacaoServico;
        }

        public async Task AdicionarEspecie(Especie especie)
        {
            var valido = _validacaoServico.ValidaPropriedadeString(especie.Nome, "Nome");
            if (valido)
                await _interfaceEspecies.Add(especie);
        }

        public async Task AtualizaEspecie(Especie especie)
        {
            var valido = _validacaoServico.ValidaPropriedadeString(especie.Nome, "Nome");
            if (valido)
                await _interfaceEspecies.Update(especie);
        }
    }
}
