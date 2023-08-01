using Domain.Interfaces.IClientes;
using Domain.Interfaces.IConsulta;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly InterfaceConsulta _interfaceConsulta;
        private readonly IConsultaServico _iConsultaServico;
        public ConsultaController(InterfaceConsulta interfaceConsulta, IConsultaServico iConsultaServico)
        {
            _interfaceConsulta = interfaceConsulta;
            _iConsultaServico = iConsultaServico;
        }

        [HttpPost("/api/Consulta")]
        [Produces("application/json")]
        public async Task<ActionResult<ConsultaDto>> AdicionarConsulta([FromBody] ConsultaDto consultaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consulta = new Consulta
            {
                DataConsulta = consultaDto.DataConsulta,
                Descricao = consultaDto.Descricao,
                ID_Veterinario = consultaDto.ID_Veterinario,
                ID_Animal = consultaDto.ID_Animal
            };

            await _interfaceConsulta.Add(consulta);

            return CreatedAtAction(nameof(AdicionarConsulta), new { id = consulta.ID_Consulta }, consultaDto);
        }

        [HttpGet("/api/Consultas")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Consulta>>> ListarConsultas()
        {
            return Ok(await _interfaceConsulta.List());
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarConsulta(int id, [FromBody] ConsultaDto consultaDto)
        {
            var consulta = await _interfaceConsulta.GetEntityById(id);
            if (consulta == null)
            {
                return NotFound();
            }

            consulta.DataConsulta = consultaDto.DataConsulta;
            consulta.Descricao = consultaDto.Descricao;
            consulta.ID_Veterinario = consultaDto.ID_Veterinario;
            consulta.ID_Animal = consultaDto.ID_Animal;

            await _interfaceConsulta.Update(consulta);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteConsulta(int id)
        {
            var consulta = await _interfaceConsulta.GetEntityById(id);
            if (consulta == null)
            {
                return NotFound();
            }

            await _interfaceConsulta.Delete(consulta);

            return NoContent();
        }
    }
}
