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
    public class FamiliaController : ControllerBase
    {
        private readonly InterfaceFamilia _interfaceFamilias;
        private readonly IFamiliaServico _familiaServico;
        public FamiliaController(InterfaceFamilia interfaceFamilia, IFamiliaServico familiaServico)
        {
            _interfaceFamilias = interfaceFamilia;
            _familiaServico = familiaServico;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Familia>>> ListarFamilias()
        {
            return Ok(await _interfaceFamilias.List());
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarFamilia([FromBody] FamiliaDto familiaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var familia = new Familia
            {
                Codigo = familiaDto.Codigo,
                Descricao = familiaDto.Descricao,
                ID_Usuario = familiaDto.ID_Usuario
            };

            await _interfaceFamilias.Add(familia);

            return CreatedAtAction(nameof(CriarFamilia), new { id = familia.IdFamilia }, familia);
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> ExcluirFamilia(int id)
        {
            var familia = await _interfaceFamilias.GetEntityById(id);

            if (familia == null)
            {
                return NotFound();
            }

            await _interfaceFamilias.Delete(familia);

            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Familia>> ObterFamiliaPorId(long id)
        {
            var familia = await _interfaceFamilias.GetEntityById(id);
            if (familia == null)
            {
                return NotFound();
            }

            return Ok(familia);
        }

         

    }
}
