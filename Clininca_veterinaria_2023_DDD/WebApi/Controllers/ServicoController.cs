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
using Domain.Interfaces.IServico;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly InterfaceServico _interfaceServicos;
        private readonly IServicoServico _servicoServico;
        public ServicoController(InterfaceServico interfaceServicos, IServicoServico servicoServico)
        {
            _interfaceServicos = interfaceServicos;
            _servicoServico = servicoServico;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Servico>>> ListarServicos()
        {
            return Ok(await _interfaceServicos.List());
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarServico([FromBody] ServicoDto servicoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Criar uma nova instância de Servico a partir do DTO recebido
            var servico = new Servico
            {
                Nome = servicoDto.Nome,
                Descricao = servicoDto.Descricao,
                Preco = servicoDto.Preco,
                ID_Usuario = servicoDto.ID_Usuario,
                IdUnspsc = servicoDto.IdUnspsc
            };

            // Adicionar a entidade ao banco de dados através do serviço/interface relevante
            await _interfaceServicos.Add(servico);

            // Retornar uma resposta de sucesso
            return CreatedAtAction(nameof(CriarServico), new { id = servico.IdServico }, servico);
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> ExcluirServico(long id)
        {
            var servico = await _interfaceServicos.GetEntityById(id);

            if (servico == null)
            {
                return NotFound();
            }

            await _interfaceServicos.Delete(servico);

            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Servico>> ObterServicoPorId(long id)
        {
            var servico = await _interfaceServicos.GetEntityById(id);
            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }



    }
}
