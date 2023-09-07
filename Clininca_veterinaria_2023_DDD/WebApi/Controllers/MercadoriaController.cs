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
using Domain.Interfaces.IMercadoria;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoriaController : ControllerBase
    {
        private readonly InterfaceMercadoria _interfaceMercadorias;
        private readonly IMercadoriaServico _mercadoriaServico;
        public MercadoriaController(InterfaceMercadoria interfaceMercadoria, IMercadoriaServico mercadoriaServico)
        {
            _interfaceMercadorias = interfaceMercadoria;
            _mercadoriaServico = mercadoriaServico;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Mercadoria>>> ListarMercadoria()
        {
            return Ok(await _interfaceMercadorias.List());
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriaMercadoria([FromBody] MercadoriaDto mercadoriaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mercadoria = new Mercadoria
            {
                Codigo = mercadoriaDto.Codigo,
                Descricao = mercadoriaDto.Descricao,
                ID_Usuario = mercadoriaDto.ID_Usuario
            };

            await _interfaceMercadorias.Add(mercadoria);

            return CreatedAtAction(nameof(CriaMercadoria), new { id = mercadoria.IdMercadoria }, mercadoria);
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> ExcluirMercadoria(int id)
        {
            var mercadoria = await _interfaceMercadorias.GetEntityById(id);

            if (mercadoria == null)
            {
                return NotFound();
            }

            await _interfaceMercadorias.Delete(mercadoria);

            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Mercadoria>> ObterMercadoriaPorId(long id)
        {
            var mercadoria = await _interfaceMercadorias.GetEntityById(id);
            if (mercadoria == null)
            {
                return NotFound();
            }

            return Ok(mercadoria);
        }
         

    }
}
