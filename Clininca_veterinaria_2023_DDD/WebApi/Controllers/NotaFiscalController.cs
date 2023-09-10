using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IVeterinario;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.INotaFiscal;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaFiscalController : ControllerBase
    {
        private readonly InterfaceNotaFiscal _InterfaceNotaFiscal;
        private readonly INotaFiscalServico _INotaFiscalServico;
        public NotaFiscalController(InterfaceNotaFiscal interfaceNotaFiscal, INotaFiscalServico iNotaFiscalServico)
        {
            _InterfaceNotaFiscal = interfaceNotaFiscal;
            _INotaFiscalServico = iNotaFiscalServico;
        }


        [HttpPost("/api/NotaFiscal")]
        [Produces("application/json")]
        public async Task<ActionResult<NotaFiscalDto>> AdicionarNotaFiscal([FromBody] NotaFiscalDto notaFiscalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create a new NotaFiscal entity from the DTO
            var notaFiscal = new NotaFiscal
            {
                IdNotaFiscal = notaFiscalDto.IdNotaFiscal,
                DataEmissao = notaFiscalDto.DataEmissao,
                ClienteNome = notaFiscalDto.ClienteNome,
                ClienteEndereco = notaFiscalDto.ClienteEndereco,
                ClienteCnpjCpf = notaFiscalDto.ClienteCnpjCpf,
                ValorTotal = notaFiscalDto.ValorTotal,
                ID_Usuario = notaFiscalDto.ID_Usuario,
                IdVendaServicoPagamento = notaFiscalDto.IdVendaServicoPagamento
            };

            // Assuming _InterfaceNotaFiscal.Add is the method to add a new NotaFiscal
            await _InterfaceNotaFiscal.Add(notaFiscal);

            // Return the created NotaFiscalDto
            return CreatedAtAction(nameof(AdicionarNotaFiscal), new { id = notaFiscal.IdNotaFiscal }, notaFiscalDto);
        }

        [HttpPut("/api/NotaFiscal/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarNotaFiscal(int id, [FromBody] NotaFiscalDto notaFiscalDto)
        {
            var notaFiscalFromDb = await _InterfaceNotaFiscal.GetEntityById(id);
            if (notaFiscalFromDb == null)
            {
                return NotFound();
            }

            notaFiscalFromDb.DataEmissao = notaFiscalDto.DataEmissao;
            notaFiscalFromDb.ClienteNome = notaFiscalDto.ClienteNome;
            notaFiscalFromDb.ClienteEndereco = notaFiscalDto.ClienteEndereco;
            notaFiscalFromDb.ClienteCnpjCpf = notaFiscalDto.ClienteCnpjCpf;
            notaFiscalFromDb.ValorTotal = notaFiscalDto.ValorTotal;
            notaFiscalFromDb.ID_Usuario = notaFiscalDto.ID_Usuario;
            notaFiscalFromDb.IdVendaServicoPagamento = notaFiscalDto.IdVendaServicoPagamento;

            await _InterfaceNotaFiscal.Update(notaFiscalFromDb);

            return NoContent();
        }

        [HttpDelete("/api/NotaFiscal/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarNotaFiscal(int id)
        {
            var notaFiscalFromDb = await _InterfaceNotaFiscal.GetEntityById(id);
            if (notaFiscalFromDb == null)
            {
                return NotFound();
            }

            await _InterfaceNotaFiscal.Delete(notaFiscalFromDb);

            return NoContent();
        }


        [HttpGet("/api/NotaFiscalById/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<NotaFiscal>> NotaFiscalById(int id)
        {
            var notaFiscalFromDb = await _InterfaceNotaFiscal.GetEntityById(id);
            if (notaFiscalFromDb == null)
            {
                return NotFound();
            }
            return Ok(notaFiscalFromDb);
        }

        [HttpGet("/api/NotaFiscal")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<NotaFiscal>>> ListarNotaFiscal()
        {
            var notasFiscais = await _InterfaceNotaFiscal.List();
            if (notasFiscais == null || !notasFiscais.Any())
            {
                return NotFound();
            }
            return Ok(notasFiscais);
        }

    }
}
