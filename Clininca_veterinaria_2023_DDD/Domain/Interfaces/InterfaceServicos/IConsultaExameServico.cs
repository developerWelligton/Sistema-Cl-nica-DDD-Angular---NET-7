using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IConsultaExameServico
    {
        public Task AdicionarExame(Exame exame);
        public Task AtualizaExame(Exame exame);
    }
}
