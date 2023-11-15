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
                CPF_CNPJ = clienteDto.CPF_CNPJ, // Added property
                Endereco = clienteDto.Endereco,
                Email = clienteDto.Email,
                TelefoneFixo = clienteDto.TelefoneFixo, // Adjusted property
                TelefoneMovel = clienteDto.TelefoneMovel, // Adjusted property
                CEP = clienteDto.CEP, // Added property
                Bairro = clienteDto.Bairro, // Added property
                Cidade = clienteDto.Cidade, // Added property
                UF = clienteDto.UF, // Added property
                Complemento = clienteDto.Complemento, // Added property
                InscricaoMunicipal = clienteDto.InscricaoMunicipal, // Added property
                InscricaoEstadual = clienteDto.InscricaoEstadual, // Added property
                ID_Usuario = clienteDto.ID_Usuario,
                Observacoes = clienteDto.Observacoes, // Added property
                Grupo = clienteDto.Grupo, // Added property
                Empresa = clienteDto.Empresa, // Added property
                NotificacaoDesabilitada = clienteDto.NotificacaoDesabilitada, // Added property
                EmailsAdicionais = clienteDto.EmailsAdicionais // Added property
            };

            // Mapear os animais, se fornecidos
            if (clienteDto.Animais != null && clienteDto.Animais.Any())
            {
                cliente.Animais = clienteDto.Animais.Select(a => new Animal
                {
                    // Map the properties of AnimalDto to Animal
                }).ToList();
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
                ID_Cliente = c.ID_Cliente,
                Nome = c.Nome,
                CPF_CNPJ = c.CPF_CNPJ, // Added property
                Endereco = c.Endereco,
                Email = c.Email,
                TelefoneFixo = c.TelefoneFixo, // Changed to TelefoneFixo
                TelefoneMovel = c.TelefoneMovel, // Added property
                CEP = c.CEP, // Added property
                Bairro = c.Bairro, // Added property
                Cidade = c.Cidade, // Added property
                UF = c.UF, // Added property
                Complemento = c.Complemento, // Added property
                InscricaoMunicipal = c.InscricaoMunicipal, // Added property
                InscricaoEstadual = c.InscricaoEstadual, // Added property
                ID_Usuario = c.ID_Usuario,
                Animais = c.Animais.Select(a => new AnimalDto
                {
                    // Map properties of Animal to AnimalDto
                }).ToList(),
                Observacoes = c.Observacoes, // Added property
                Grupo = c.Grupo, // Added property
                Empresa = c.Empresa, // Added property
                NotificacaoDesabilitada = c.NotificacaoDesabilitada, // Added property
                EmailsAdicionais = c.EmailsAdicionais // Added property
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

            // Update properties
            cliente.Nome = clienteDto.Nome;
            cliente.CPF_CNPJ = clienteDto.CPF_CNPJ; // Added property
            cliente.Endereco = clienteDto.Endereco;
            cliente.Email = clienteDto.Email;
            cliente.TelefoneFixo = clienteDto.TelefoneFixo; // Adjusted property
            cliente.TelefoneMovel = clienteDto.TelefoneMovel; // Adjusted property
            cliente.CEP = clienteDto.CEP; // Added property
            cliente.Bairro = clienteDto.Bairro; // Added property
            cliente.Cidade = clienteDto.Cidade; // Added property
            cliente.UF = clienteDto.UF; // Added property
            cliente.Complemento = clienteDto.Complemento; // Added property
            cliente.InscricaoMunicipal = clienteDto.InscricaoMunicipal; // Added property
            cliente.InscricaoEstadual = clienteDto.InscricaoEstadual; // Added property
            cliente.ID_Usuario = clienteDto.ID_Usuario; // Existing property
            cliente.Observacoes = clienteDto.Observacoes; // Added property
            cliente.Grupo = clienteDto.Grupo; // Added property
            cliente.Empresa = clienteDto.Empresa; // Added property
            cliente.NotificacaoDesabilitada = clienteDto.NotificacaoDesabilitada; // Added property
            cliente.EmailsAdicionais = clienteDto.EmailsAdicionais; // Added property

            // Assuming _interfaceClientes.Update handles the update operation and saves changes.
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
