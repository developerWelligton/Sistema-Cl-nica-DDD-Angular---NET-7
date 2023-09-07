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

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarSegmento([FromBody] SegmentoDto segmentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var segmento = new Segmento
            {
                Codigo = segmentoDto.Codigo,
                Descricao = segmentoDto.Descricao,
                ID_Usuario = segmentoDto.ID_Usuario
            };

            await _interfaceSegmentos.Add(segmento);

            return CreatedAtAction(nameof(CriarSegmento), new { id = segmento.IdSegmento }, segmento);
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> ExcluirSegmento(int id)
        {
            var segmento = await _interfaceSegmentos.GetEntityById(id);

            if (segmento == null)
            {
                return NotFound();
            }

            await _interfaceSegmentos.Delete(segmento);

            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Segmento>> ObterSegmentoPorId(long id)
        {
            var segmento = await _interfaceSegmentos.GetEntityById(id);
            if (segmento == null)
            {
                return NotFound();
            }

            return Ok(segmento);
        }



    }
}
