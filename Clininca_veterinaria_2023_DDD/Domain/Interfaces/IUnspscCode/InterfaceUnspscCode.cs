using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUnspscCode
{
    public interface InterfaceUnspscCode : InterfaceGeneric<UnspscCode>
    {
         
        Task<IList<UnspscCode>> GetAllUnspscCodeDetails();
    }
}
