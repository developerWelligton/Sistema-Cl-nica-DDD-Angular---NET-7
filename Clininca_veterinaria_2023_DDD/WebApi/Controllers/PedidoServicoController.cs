using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IVeterinario;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.IPedidoServico;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoServicoController : ControllerBase
    {
        private readonly InterfacePedidoServico _interfacePedidoServico;
        private readonly IPedidoServicoServico _iPedidoServicoServico;
        public PedidoServicoController(InterfacePedidoServico interfacePedidoServico,
            IPedidoServicoServico iPedidoServicoServico)
        {
            _interfacePedidoServico = interfacePedidoServico;
            _iPedidoServicoServico = iPedidoServicoServico;
        }

        [HttpGet("/api/PedidoServicos")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<PedidoServicos>>> ListarPedidoServicos()
        {
            return Ok(await _interfacePedidoServico.List());
        }

        [HttpPost("/api/PedidoServico")]
        [Produces("application/json")]
        public async Task<ActionResult<PedidoServicoDto>> AdicionarPedidoServico([FromBody] PedidoServicoDto pedidoServicoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crie uma nova instância de PedidoServicos usando os dados do DTO
            var pedidoServico = new PedidoServicos
            {
                DataPedido = pedidoServicoDto.DataPedido,
                StatusPagamento = pedidoServicoDto.StatusPagamento,
                TotalPedido = pedidoServicoDto.TotalPedido,
                ID_Usuario = pedidoServicoDto.ID_Usuario
            };

            // Adicione o novo PedidoServicos ao banco de dados
            await _interfacePedidoServico.Add(pedidoServico);

            // Retorne uma resposta HTTP 201 Created com o DTO
            return CreatedAtAction(nameof(AdicionarPedidoServico), new { id = pedidoServico.IdPedidoServicos }, pedidoServicoDto);
        }

        

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarPedidoServico(long id, [FromBody] PedidoServicoDto pedidoServicoDto)
        {
            var pedidoFromDb = await _interfacePedidoServico.GetEntityById(id);
            if (pedidoFromDb == null)
            {
                return NotFound();
            }

            // Atualize as propriedades do pedidoServico aqui
            pedidoFromDb.DataPedido = pedidoServicoDto.DataPedido;
            pedidoFromDb.StatusPagamento = pedidoServicoDto.StatusPagamento;
            pedidoFromDb.TotalPedido = pedidoServicoDto.TotalPedido;
            pedidoFromDb.ID_Usuario = pedidoServicoDto.ID_Usuario;

            await _interfacePedidoServico.Update(pedidoFromDb);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarPedidoServico(long id)
        {
            var pedidoFromDb = await _interfacePedidoServico.GetEntityById(id);
            if (pedidoFromDb == null)
            {
                return NotFound();
            }

            await _interfacePedidoServico.Delete(pedidoFromDb);

            return NoContent();
        }

     

        [HttpGet("/api/GetPedidoServicoById/{Id}")]
        [Produces("application/json")]
        public async Task<ActionResult<PedidoServicos>> GetPedidoServicoById(int Id)
        {
            var pedidoFromDb = await _interfacePedidoServico.GetEntityById(Id);
            if (pedidoFromDb == null)
            {
                return NotFound();
            }
            return Ok(pedidoFromDb);
        }


    }
}
