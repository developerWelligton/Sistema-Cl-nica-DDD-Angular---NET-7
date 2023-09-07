using Domain.Interfaces.IClientes;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.IVeterinario;
using Domain.Interfaces.ISegmento;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentoController : ControllerBase
    {
        private readonly InterfaceSegmento _interfaceSegmentos;
        private readonly ISegmentoServico _segmentoServico;
        public SegmentoController(InterfaceSegmento interfaceSegmentos, ISegmentoServico segmentoServico)
        {
            _interfaceSegmentos = interfaceSegmentos;
            _segmentoServico = segmentoServico;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Segmento>>> ListarSegmentos()
        {
            return Ok(await _interfaceSegmentos.List());
        }



    }
}
