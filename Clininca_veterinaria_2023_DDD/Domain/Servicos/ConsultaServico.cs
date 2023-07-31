using Domain.Interfaces.IConsulta;
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
    public class ConsultaServico : IConsultaServico
    {
        private readonly InterfaceConsulta _interfaceConsulta;

        public ConsultaServico(InterfaceConsulta interfaceConsulta)
        {
            _interfaceConsulta = interfaceConsulta;
        }
        public Task AdicionarConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public Task AtualizaConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }
    }
}
