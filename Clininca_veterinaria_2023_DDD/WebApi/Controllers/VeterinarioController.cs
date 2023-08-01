using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IVeterinario;
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
    public class VeterinarioController : ControllerBase
    {
        private readonly InterfaceVeterinario _InterfaceVeterinario;
        private readonly IVeterinarioServico _IVeterinarioServico;
        public VeterinarioController(InterfaceVeterinario interfaceVeterinario, IVeterinarioServico iVeterinarioServico)
        {
            _InterfaceVeterinario = interfaceVeterinario;
            _IVeterinarioServico = iVeterinarioServico;
        }


        [HttpPost("/api/Veterinario")]
        [Produces("application/json")]
        public async Task<ActionResult<VeterinarioDto>> AdicionarVeterinario([FromBody] VeterinarioDto veterinarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var veterinario = new Veterinario
            {
                Nome = veterinarioDto.Nome,
                Especializacao = veterinarioDto.Especializacao,
                Email = veterinarioDto.Email,
                Telefone = veterinarioDto.Telefone,
                ID_Usuario = veterinarioDto.ID_Usuario
            };

            await _InterfaceVeterinario.Add(veterinario);

            return CreatedAtAction(nameof(AdicionarVeterinario), new { id = veterinario.ID_Veterinario }, veterinarioDto);
        }

        [HttpGet("/api/Veterinarios")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Veterinario>>> ListarVeterinario()
        {
            return Ok(await _InterfaceVeterinario.List());
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarVeterinario(int id, [FromBody] VeterinarioDto veterinarioDto)
        {
            var vetFromDb = await _InterfaceVeterinario.GetEntityById(id);
            if (vetFromDb == null)
            {
                return NotFound();
            }

            vetFromDb.Nome = veterinarioDto.Nome;
            vetFromDb.Especializacao = veterinarioDto.Especializacao;
            vetFromDb.Email = veterinarioDto.Email;
            vetFromDb.Telefone = veterinarioDto.Telefone;
            vetFromDb.ID_Usuario = veterinarioDto.ID_Usuario;

            await _InterfaceVeterinario.Update(vetFromDb);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarVeterinario(int id)
        {
            var vetFromDb = await _InterfaceVeterinario.GetEntityById(id);
            if (vetFromDb == null)
            {
                return NotFound();
            }

            await _InterfaceVeterinario.Delete(vetFromDb);

            return NoContent();
        }
    }
}
