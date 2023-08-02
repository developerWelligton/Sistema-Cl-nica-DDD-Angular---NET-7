using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSistemaController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaClinica _interfaceUsuarioSistemaClinica;
        private readonly IUsuarioSistemaClinicaServico _isuarioSistemaClinicaServico;
        public UsuarioSistemaController(InterfaceUsuarioSistemaClinica interfaceUsuarioSistemaClinica, IUsuarioSistemaClinicaServico isuarioSistemaClinicaServico)
        {
            _interfaceUsuarioSistemaClinica = interfaceUsuarioSistemaClinica;
            _isuarioSistemaClinicaServico = isuarioSistemaClinicaServico;
        }

        [HttpGet("/api/BuscarPorNome")]
        [Produces("application/json")]
        public async Task<object> buscarPorNome(string nome)
        {
            return await _interfaceUsuarioSistemaClinica.BuscarPorNome(nome);
        }

        [HttpPost("/api/UsuarioClinica")]
        [Produces("application/json")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UsuarioSistemaClinica>> AdicionarUsuarioClinica([FromBody] UsuarioSistemaClinica usuarioSistemaClinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _interfaceUsuarioSistemaClinica.Add(usuarioSistemaClinica);

            return CreatedAtAction(nameof(AdicionarUsuarioClinica), new { id = usuarioSistemaClinica.ID_Usuario }, usuarioSistemaClinica);
        }

        [HttpGet("/api/UsuariosClinica")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UsuarioSistemaClinica>>> ListarUsuarioClinica()
        {
            return Ok(await _interfaceUsuarioSistemaClinica.List());
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarUsuarioClinica(int id, [FromBody] UsuarioSistemaClinicaDto usuarioSistemaClinicaDto)
        {
            var userFromDb = await _interfaceUsuarioSistemaClinica.GetEntityById(id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            userFromDb.Nome = usuarioSistemaClinicaDto.Nome;
            userFromDb.Email = usuarioSistemaClinicaDto.Email; 
            userFromDb.Senha = usuarioSistemaClinicaDto.Senha;
            // Adicione mais campos conforme necessário

            await _interfaceUsuarioSistemaClinica.Update(userFromDb);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarUsuarioClinica(int id)
        {
            var userFromDb = await _interfaceUsuarioSistemaClinica.GetEntityById(id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            await _interfaceUsuarioSistemaClinica.Delete(userFromDb);

            return NoContent();
        }
    }
}
