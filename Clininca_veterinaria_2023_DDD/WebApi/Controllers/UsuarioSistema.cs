using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Entidades;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSistema  : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaClinica _interfaceUsuarioSistemaClinica;
        private readonly IUsuarioSistemaClinicaServico _isuarioSistemaClinicaServico;
        public UsuarioSistema(InterfaceUsuarioSistemaClinica interfaceUsuarioSistemaClinica, IUsuarioSistemaClinicaServico isuarioSistemaClinicaServico)
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

        [HttpPost("/api/AdicionarUsuarioClinica")]
        [Produces("application/json")]
        public async Task<ActionResult<UsuarioSistemaClinica>> AdicionarUsuarioClinica([FromBody] UsuarioSistemaClinica usuarioSistemaClinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _interfaceUsuarioSistemaClinica.Add(usuarioSistemaClinica);

            // se a ID é gerada pelo banco de dados e você pode recuperá-la após a inserção, use-a aqui
            return CreatedAtAction(nameof(AdicionarUsuarioClinica), new { id = usuarioSistemaClinica.ID_Usuario }, usuarioSistemaClinica);
        }


        [HttpGet("/api/ListarUsuarioClinica")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UsuarioSistemaClinica>>> ListarUsuarioClinica()
        {
            return Ok(await _interfaceUsuarioSistemaClinica.List());
        }
    }
}
