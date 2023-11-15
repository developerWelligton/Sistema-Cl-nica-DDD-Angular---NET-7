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
using Domain.Interfaces.IClasse;

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

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ListarClientes()
        {
            return Ok(await _interfaceClientes.List());
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
 

            await _interfaceClientes.Add(cliente);

            return CreatedAtAction(nameof(AdicionarCliente), new { id = cliente.ID_Cliente }, clienteDto);
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
