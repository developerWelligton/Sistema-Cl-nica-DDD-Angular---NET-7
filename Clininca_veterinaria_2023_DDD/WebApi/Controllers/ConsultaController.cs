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
using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IVeterinario;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly InterfaceConsulta _interfaceConsulta;
        private readonly IConsultaServico _iConsultaServico;
        //
        private readonly InterfaceClientes _interfaceCliente;
        private readonly InterfaceAnimal _interfaceAnimal;
        private readonly InterfaceVeterinario _interfaceVeterinario;
        public ConsultaController(
     InterfaceConsulta interfaceConsulta,
     IConsultaServico iConsultaServico,
     InterfaceClientes interfaceCliente,
     InterfaceAnimal interfaceAnimal,
     InterfaceVeterinario interfaceVeterinario)
        {
            _interfaceConsulta = interfaceConsulta;
            _iConsultaServico = iConsultaServico;
            _interfaceCliente = interfaceCliente;
            _interfaceAnimal = interfaceAnimal;
            _interfaceVeterinario = interfaceVeterinario;
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
                DataMarcacao = DateTime.Now, // Ou você poderia adicionar este campo ao DTO e pegar de consultaDto.DataMarcacao
                InicioConsulta = consultaDto.InicioConsulta,
                FimConsulta = consultaDto.FimConsulta,
                Descricao = consultaDto.Descricao,
                ID_Veterinario = consultaDto.ID_Veterinario,
                ID_Animal = consultaDto.ID_Animal,
                Status = 0  
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

        /*
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
        */

        /*
        [HttpGet("/api/Consultas/Detalhadas")]
        [Produces("application/json")]
        public async Task<ActionResult<object>> ListarConsultasDetalhadas(
           [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? clienteNome = null,
            [FromQuery] string? animalNome = null,
            [FromQuery] string? veterinarioNome = null,
            [FromQuery] DateTime? dataConsulta = null)  // Adicionado parâmetro para filtro por data
        {
            // Use o método ListWithFilters para obter as consultas filtradas.
            IList<Consulta> consultas = await _interfaceConsulta.ListWithFilters(clienteNome, animalNome, veterinarioNome);

            // Aplicar filtro por data:
            if (dataConsulta.HasValue)
            {
                consultas = consultas.Where(c => c.DataConsulta.Date == dataConsulta.Value.Date).ToList();
            }

            var totalConsultas = consultas.Count;  // Total após aplicar o filtro

            // Paginação:
            consultas = consultas.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            var consultaDetalhada = new List<object>();
            foreach (var consulta in consultas)
            {
                var animal = await _interfaceAnimal.GetEntityById(consulta.ID_Animal);
                var cliente = await _interfaceCliente.GetEntityById(animal.ID_Cliente);
                var veterinario = await _interfaceVeterinario.GetEntityById(consulta.ID_Veterinario);

                consultaDetalhada.Add(new
                {
                    IdConsulta = consulta.ID_Consulta,
                    Data = consulta.DataConsulta,
                    Descricao = consulta.Descricao,
                    Cliente = cliente.Nome,
                    Animal = animal.Nome,
                    Veterinario = veterinario.Nome
                });
            }

            return Ok(new
            {
                Total = totalConsultas,
                Consultas = consultaDetalhada
            });
        }*/

         
    }
}
