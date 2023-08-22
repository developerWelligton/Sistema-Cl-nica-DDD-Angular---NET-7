using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly InterfaceAnimal _InterfaceAnimal;
        private readonly IAnimalServico _IAnimalServico;

        public AnimalController(InterfaceAnimal interfaceAnimal, IAnimalServico animalServico)
        {
            _InterfaceAnimal = interfaceAnimal;
            _IAnimalServico = animalServico;
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AnimalDto>> AdicionarAnimal([FromBody] AnimalDto animalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animal = new Animal
            {
                Nome = animalDto.Nome, 
               // ID_Cliente = animalDto.ID_Cliente
            };

            await _InterfaceAnimal.Add(animal);

            return CreatedAtAction(nameof(AdicionarAnimal), new { id = animal.ID_Animal }, animalDto);
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Animal>>> ListarAnimais()
        {
            return Ok(await _InterfaceAnimal.List());
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Animal>> ObterAnimalPorId(int id)
        {
            var animal = await _InterfaceAnimal.GetEntityById(id);
            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarAnimal(int id, [FromBody] AnimalDto animalDto)
        {
            var animal = await _InterfaceAnimal.GetEntityById(id);
            if (animal == null)
            {
                return NotFound();
            }

            animal.Nome = animalDto.Nome; 
            //animal.ID_Cliente = animalDto.ID_Cliente;

            await _InterfaceAnimal.Update(animal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> ExcluirAnimal(int id)
        {
            var animal = await _InterfaceAnimal.GetEntityById(id);
            if (animal == null)
            {
                return NotFound();
            }

            await _InterfaceAnimal.Delete(animal);

            return NoContent();
        }

        // Within AnimalController.cs

        [HttpGet("search/{term}")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Animal>>> SearchAnimals(string term)
        {
            var animals = await _InterfaceAnimal.SearchByName(term);
            if (animals == null)
            {
                return NotFound();
            }

            return Ok(animals);
        }
    }
}
