using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IVeterinario;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.ICompra;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly InterfaceCompra _InterfaceCompra;
        private readonly ICompraServico _ICompraServico;
        public CompraController(InterfaceCompra interfaceCompra, ICompraServico iCompraServico)
        {
            _InterfaceCompra = interfaceCompra;
            _ICompraServico = iCompraServico;
        }


        [HttpPost("/api/Compra")]
        [Produces("application/json")]
        public async Task<ActionResult<CompraDto>> AdicionarCompra([FromBody] CompraDto compraDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var compra = new Compra
            {
                Total = compraDto.Total,
                DataCompra = compraDto.DataCompra,
                Status = compraDto.Status,
                ID_Usuario = compraDto.ID_Usuario,
                IdFornecedor = compraDto.IdFornecedor
            };

            await _InterfaceCompra.Add(compra);

            return CreatedAtAction(nameof(AdicionarCompra), new { id = compra.IdCompra }, compraDto);
        }

        [HttpGet("/api/Compras")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Compra>>> ListarCompra()
        {
            return Ok(await _InterfaceCompra.List());
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarCompra(int id, [FromBody] CompraDto compraDto)
        {
            var compraFromDb = await _InterfaceCompra.GetEntityById(id);
            if (compraFromDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            compraFromDb.Total = compraDto.Total;
            compraFromDb.DataCompra = compraDto.DataCompra;
            compraFromDb.Status = compraDto.Status;
            compraFromDb.ID_Usuario = compraDto.ID_Usuario;
            compraFromDb.IdFornecedor = compraDto.IdFornecedor;

            await _InterfaceCompra.Update(compraFromDb);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarCompra(int id)
        {
            var vetFromDb = await _InterfaceCompra.GetEntityById(id);
            if (vetFromDb == null)
            {
                return NotFound();
            }

            await _InterfaceCompra.Delete(vetFromDb);

            return NoContent();
        }

       

        [HttpGet("/api/CompraById/{userId}")]
        [Produces("application/json")]
        public async Task<ActionResult<Veterinario>> GetCompraById(int userId)
        {
            var compra = await _InterfaceCompra.GetEntityById(userId);
            if (compra == null)
            {
                return NotFound();
            }
            return Ok(compra);
        }


    }
}
