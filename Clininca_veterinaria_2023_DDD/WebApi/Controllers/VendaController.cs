using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IVeterinario;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.IVenda;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly InterfaceVenda _InterfaceVenda;
        private readonly IVendaServico _IVendaServico;
        public VendaController(InterfaceVenda interfaceVenda, IVendaServico iVendaServico)
        {
            _InterfaceVenda = interfaceVenda;
            _IVendaServico = iVendaServico;
        }


        [HttpPost("/api/Venda")]
        [Produces("application/json")]
        public async Task<ActionResult<VendaDto>> AdicionarVenda([FromBody] VendaDto vendaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Criar uma nova entidade Venda a partir do VendaDto
            var venda = new Venda
            {
                DataVenda = vendaDto.DataVenda,
                Status = vendaDto.Status,
                ID_Usuario = vendaDto.ID_Usuario
            };

            // Supondo que _InterfaceVenda seja o seu serviço ou repositório para adicionar uma Venda
            await _InterfaceVenda.Add(venda);

            // Atualizar o ID da venda no DTO para refletir o valor gerado pelo banco de dados
            vendaDto.IdVenda = venda.IdVenda;
                
            return CreatedAtAction(nameof(AdicionarVenda), new { id = venda.IdVenda }, vendaDto);
        }


        [HttpGet("/api/Vendas")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Venda>>> ListarVenda()
        {
            return Ok(await _InterfaceVenda.List());
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarVenda(int id, [FromBody] VendaDto vendaDto)
        {
            // Buscar a venda pelo ID
            var vendaFromDb = await _InterfaceVenda.GetEntityById(id);
            if (vendaFromDb == null)
            {
                return NotFound();
            }

            // Atualizar as propriedades da venda
            vendaFromDb.DataVenda = vendaDto.DataVenda;
            vendaFromDb.Status = vendaDto.Status;
            vendaFromDb.ID_Usuario = vendaDto.ID_Usuario;

            // Atualizar a venda no banco de dados
            await _InterfaceVenda.Update(vendaFromDb);

            return NoContent();
        }

       



        [HttpGet("/api/VendaById/{Id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Venda>> GetVendaById(int Id)
        {
            // Buscar a venda pelo ID
            var venda = await _InterfaceVenda.GetEntityById(Id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }
         
    }
}
