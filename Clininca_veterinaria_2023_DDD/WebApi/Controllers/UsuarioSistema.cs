using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Domain.Interfaces.IClientes;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller para adicionar novos usuários à clínica.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSistemaController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaClinica _interfaceUsuarioSistemaClinica;
        private readonly IUsuarioSistemaClinicaServico _isuarioSistemaClinicaServico;
        private readonly InterfaceClientes _interfaceClientes;
        public UsuarioSistemaController(
            InterfaceUsuarioSistemaClinica interfaceUsuarioSistemaClinica, 
            IUsuarioSistemaClinicaServico isuarioSistemaClinicaServico,
             InterfaceClientes interfaceClientes)
        {
            _interfaceUsuarioSistemaClinica = interfaceUsuarioSistemaClinica;
            _isuarioSistemaClinicaServico = isuarioSistemaClinicaServico;
            _interfaceClientes = interfaceClientes; // Atribuir a interface
        }

        [HttpGet("/api/BuscarPorNome")]
        [Produces("application/json")]
        public async Task<object> buscarPorNome(string nome)
        {
            return await _interfaceUsuarioSistemaClinica.BuscarPorNome(nome);
        }

        /// <summary>
        /// Adiciona um novo usuário ao sistema da clínica.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /api/UsuarioClinica
        ///     {
        ///         "nome": "Nome do Usuário",
        ///         "cpf": "123.456.789-10",
        ///         "email": "usuario@exemplo.com",
        ///         "role": "cliente" // Role do usuário (veterinario, cliente, secretaria, admin, etc.)
        ///     }
        ///     
        /// Retorna o novo usuário adicionado no corpo da resposta.
        /// </remarks>
        /// <param name="usuarioSistemaClinica">Dados do novo usuário.</param>
        /// <returns>O novo usuário adicionado.</returns>
        /// <response code="201">Retorna o novo usuário adicionado com sucesso.</response>
        /// <response code="400">Retorna um erro de validação se o modelo de dados não for válido.</response>
        [HttpPost("/api/UsuarioClinica")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UsuarioSistemaClinica), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UsuarioSistemaClinica>> AdicionarUsuarioClinica([FromBody] UsuarioSistemaClinica usuarioSistemaClinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _interfaceUsuarioSistemaClinica.Add(usuarioSistemaClinica);

            if (usuarioSistemaClinica.Role.ToLower() == "cliente")
            {
                var cliente = new Cliente
                {
                    Nome = usuarioSistemaClinica.Nome,
                    Email = usuarioSistemaClinica.Email,
                    // Adicione outros campos conforme necessário.
                    ID_Usuario = usuarioSistemaClinica.ID_Usuario
                };

                await _interfaceClientes.Add(cliente);
            }

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
