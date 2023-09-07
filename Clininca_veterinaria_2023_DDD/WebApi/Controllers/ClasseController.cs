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
using Domain.Interfaces.IClasse;
using Infra.Configuracao;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly InterfaceClasse _interfaceClasses;
        private readonly IClasseServico _classeServico;
        public ClasseController(InterfaceClasse interfaceClasses, IClasseServico classeServico)
        {
            _interfaceClasses = interfaceClasses;
            _classeServico = classeServico;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Segmento>>> ListarClasses()
        {
            return Ok(await _interfaceClasses.List());
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarClasse([FromBody] ClasseDto classeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classe = new Classe
            {
                Codigo = classeDto.Codigo,
                Descricao = classeDto.Descricao,
                ID_Usuario = classeDto.ID_Usuario
            };

            await _interfaceClasses.Add(classe);

            return CreatedAtAction(nameof(CriarClasse), new { id = classe.IdClasse }, classe);
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> ExcluirClasse(int id)
        {
            var classe = await _interfaceClasses.GetEntityById(id);

            if (classe == null)
            {
                return NotFound();
            }

            await _interfaceClasses.Delete(classe);

            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Classe>> ObterClassePorId(long id)
        {
            var classe = await _interfaceClasses.GetEntityById(id);
            if (classe == null)
            {
                return NotFound();
            }

            return Ok(classe);
        }



    }
}
