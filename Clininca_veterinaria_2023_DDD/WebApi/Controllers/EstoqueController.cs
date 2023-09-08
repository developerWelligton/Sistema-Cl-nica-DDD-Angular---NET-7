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
using Domain.Interfaces.IEstoque;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly InterfaceEstoque _interfaceEstoques;
        private readonly IEstoqueServico _estoqueServico;
        public EstoqueController(InterfaceEstoque interfaceEstoque, IEstoqueServico estoqueServico)
        {
            _interfaceEstoques = interfaceEstoque;
            _estoqueServico = estoqueServico;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Estoque>>> ListarEstoques()
        {
            return Ok(await _interfaceEstoques.List());
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarEstoque([FromBody] EstoqueDto estoqueDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estoque = new Estoque
            {
                Sala = estoqueDto.Sala,
                Prateleira = estoqueDto.Prateleira,
                Quantidade = estoqueDto.Quantidade,
                ID_Usuario = estoqueDto.ID_Usuario
            };

            await _interfaceEstoques.Add(estoque);

            return CreatedAtAction(nameof(CriarEstoque), new { id = estoque.IdEstoque }, estoque);
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> ExcluirEstoque(long id)
        {
            var estoque = await _interfaceEstoques.GetEntityById(id);

            if (estoque == null)
            {
                return NotFound();
            }

            await _interfaceEstoques.Delete(estoque);

            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Estoque>> ObterEstoquePorId(long id)
        {
            var estoque = await _interfaceEstoques.GetEntityById(id);
            if (estoque == null)
            {
                return NotFound();
            }

            return Ok(estoque);
        } 

    }
}
