using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IEspecie;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly InterfaceEspecie _InterfaceEspecie;
        private readonly IEspecieServico _IEspecieServico;
        public EspecieController(InterfaceEspecie interfaceEspecie, IEspecieServico iEspecieServico)
        {
            _InterfaceEspecie = interfaceEspecie;
            _IEspecieServico = iEspecieServico;
        }

        [HttpPost("/api/Especie")]
        [Produces("application/json")]
        public async Task<ActionResult<EspecieDto>> AdicionarEspecie([FromBody] EspecieDto especieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especie = new Especie
            {
                Nome = especieDto.Nome
            };

            await _InterfaceEspecie.Add(especie);

            return CreatedAtAction(nameof(AdicionarEspecie), new { id = especie.ID_Especie }, especieDto);
        }

        [HttpGet("/api/Especies")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Especie>>> ListarEspecies()
        {
            return Ok(await _InterfaceEspecie.List());
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarEspecie(int id, [FromBody] EspecieDto especieDto)
        {
            var especie = await _InterfaceEspecie.GetEntityById(id);
            if (especie == null)
            {
                return NotFound();
            }

            especie.Nome = especieDto.Nome;

            await _InterfaceEspecie.Update(especie);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarEspecie(int id)
        {
            var especie = await _InterfaceEspecie.GetEntityById(id);
            if (especie == null)
            {
                return NotFound();
            }

            await _InterfaceEspecie.Delete(especie);

            return NoContent();
        }
    }
}
