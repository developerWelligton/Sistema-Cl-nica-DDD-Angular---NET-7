using Domain.Interfaces.IClientes;
using Domain.Interfaces.IConsulta_Exame;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ConsultaExameServico : IConsultaExameServico
    {
        private readonly InterfaceConsultaExame _InterfaceConsultaExame;

        public ConsultaExameServico(InterfaceConsultaExame InterfaceConsultaExame)
        {
            _InterfaceConsultaExame = InterfaceConsultaExame;
        }

        public Task AdicionarExame(Exame exame)
        {
            throw new NotImplementedException();
        }

        public Task AtualizaExame(Exame exame)
        {
            throw new NotImplementedException();
        }
    }
}
