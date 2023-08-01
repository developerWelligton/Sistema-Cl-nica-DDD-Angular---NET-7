using Domain.Interfaces.IExame;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly InterfaceExame _InterfaceExame;
        private readonly IExameServico _IExameServico;

        public ExameController(InterfaceExame interfaceExame, IExameServico iExameServico)
        {
            _InterfaceExame = interfaceExame;
            _IExameServico = iExameServico;
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<ExameDto>> AdicionarExame([FromBody] ExameDto exameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exame = new Exame
            {
                Nome = exameDto.Nome,
                Detalhes = exameDto.Detalhes,
                Custo = exameDto.Custo,
                ClienteId = exameDto.ClienteId
            };

            await _InterfaceExame.Add(exame);

            return CreatedAtAction(nameof(AdicionarExame), new { id = exame.ID_Exame }, exameDto);
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Exame>>> ListarExames()
        {
            return Ok(await _InterfaceExame.List());
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Exame>> ObterExamePorId(int id)
        {
            var exame = await _InterfaceExame.GetEntityById(id);
            if (exame == null)
            {
                return NotFound();
            }

            return Ok(exame);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarExame(int id, [FromBody] ExameDto exameDto)
        {
            var exame = await _InterfaceExame.GetEntityById(id);
            if (exame == null)
            {
                return NotFound();
            }

            exame.Nome = exameDto.Nome;
            exame.Detalhes = exameDto.Detalhes;
            exame.Custo = exameDto.Custo;

            await _InterfaceExame.Update(exame);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarExame(int id)
        {
            var exame = await _InterfaceExame.GetEntityById(id);
            if (exame == null)
            {
                return NotFound();
            }

            await _InterfaceExame.Delete(exame);

            return NoContent();
        }
    }
}
