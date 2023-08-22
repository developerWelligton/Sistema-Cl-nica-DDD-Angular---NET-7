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

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly InterfaceClientes _interfaceClientes;
        private readonly IClienteServico _clienteServico;
        public ClienteController(InterfaceClientes interfaceClientes, IClienteServico clienteServico)
        {
            _interfaceClientes = interfaceClientes;
            _clienteServico = clienteServico;
        }

        [HttpPost("/api/Cliente")]
        [Produces("application/json")]
        public async Task<ActionResult<ClienteDto>> AdicionarCliente([FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = new Cliente
            {
                Nome = clienteDto.Nome,
                Endereco = clienteDto.Endereco,
                Email = clienteDto.Email,
                Telefone = clienteDto.Telefone,
                ID_Usuario = clienteDto.ID_Usuario
            };

            // Mapear os animais, se fornecidos
            if (clienteDto.Animais != null && clienteDto.Animais.Any())
            {
                cliente.Animais = clienteDto.Animais.Select(a => new Animal { Nome = a.Nome }).ToList();
            }

            await _interfaceClientes.Add(cliente);

            return CreatedAtAction(nameof(AdicionarCliente), new { id = cliente.ID_Cliente }, clienteDto);
        }

        //GET ALL CLIENTE E SEUS ANIMAIS
        [HttpGet("/api/Clientes")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ListarClientes()
        {
            var clientes = await _interfaceClientes.ListarClientesComAnimais();

            var clientesDto = clientes.Select(c => new ClienteDto
            {
                ID_Cliente = c.ID_Cliente, // Mapeie o ID_Cliente aqui
                Nome = c.Nome,
                Endereco = c.Endereco,
                Email = c.Email,
                Telefone = c.Telefone,
                ID_Usuario = c.ID_Usuario,
                Animais = c.Animais.Select(a => new AnimalDto
                {
                    Nome = a.Nome
                    // Mapeie outras propriedades do Animal aqui, se necessário.
                }).ToList()
            }).ToList();

            return Ok(clientesDto);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarCliente(int id, [FromBody] ClienteDto clienteDto)
        {
            var cliente = await _interfaceClientes.GetEntityById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nome = clienteDto.Nome;
            cliente.Endereco = clienteDto.Endereco;
            cliente.Email = clienteDto.Email;
            cliente.Telefone = clienteDto.Telefone;
            cliente.ID_Usuario = clienteDto.ID_Usuario;

            await _interfaceClientes.Update(cliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _interfaceClientes.GetEntityById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _interfaceClientes.Delete(cliente);

            return NoContent();
        }

        [HttpGet("search/{term}")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Cliente>>> SearchCliente(string term)
        {
            var vets = await _interfaceClientes.SearchByName(term);
            if (vets == null)
            {
                return NotFound();
            }

            return Ok(vets);
        }
    }
}
