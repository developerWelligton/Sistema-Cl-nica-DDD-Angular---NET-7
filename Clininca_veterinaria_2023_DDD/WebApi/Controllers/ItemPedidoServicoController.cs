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
using Domain.Interfaces.ISegmento;
using Domain.Interfaces.IFamilia;
using Domain.Interfaces.IVenda;
using Domain.Interfaces.IPedidoServico;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoServicoController : ControllerBase
    {
        private readonly InterfaceItemPedidoServico _interfaceItemPedidoServico;
        private readonly IitemPedidoServicoServico _itemPedidoServicoServico;
        public ItemPedidoServicoController(InterfaceItemPedidoServico interfaceItemPedidoServico,
            IitemPedidoServicoServico itemPedidoServicoServico)
        {
            _interfaceItemPedidoServico = interfaceItemPedidoServico;
            _itemPedidoServicoServico = itemPedidoServicoServico;
        }


        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<PedidoServicosRelacao>>> ListarPedidoServico()
        {
            return Ok(await _interfaceItemPedidoServico.List());
        }


        /// <summary>
        /// Creates a new service order item based on the provided DTO.
        /// </summary>
        /// <param name="itemPedidoServicoDto">The DTO containing the service order item details.</param>
        /// <returns>The created service order item.</returns>
        [HttpPost("/api/ItemPedidoServico")]
        [Produces("application/json")]
        public async Task<ActionResult> CriarItemPedidoServico([FromBody] ItemPedidoServicoDto itemPedidoServicoDto)
        {
            // Validate the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Convert the ItemPedidoServicoDto to the PedidoServicosRelacao entity
            var pedidoServicosRelacao = new PedidoServicosRelacao
            {
                IdPedidoServicos = itemPedidoServicoDto.IdPedidoServicos,
                IdServico = itemPedidoServicoDto.IdServico
            };

            // Assuming you have a service or repository to add the service order item
            // Replace with the correct one in your code
            await _interfaceItemPedidoServico.Add(pedidoServicosRelacao);

            // Here you can add additional logic if needed

            return CreatedAtAction(nameof(CriarItemPedidoServico), new { id = pedidoServicosRelacao.IdPedidoServicos }, pedidoServicosRelacao);
        }



    }
}
