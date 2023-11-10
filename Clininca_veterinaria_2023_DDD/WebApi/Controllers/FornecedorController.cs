    using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IVeterinario;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.IClasse;
using Infra.Configuracao;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly InterfaceFornecedor _InterfaceFornecedor;
        private readonly IFornecedorServico _IFornecedorServico;
        public FornecedorController(InterfaceFornecedor interfaceFornecedor, IFornecedorServico iFornecedorServico)
        {
            _InterfaceFornecedor = interfaceFornecedor;
            _IFornecedorServico = iFornecedorServico;
        }

        [HttpGet("/api/Fornecedores")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> ListarFornecedor()
        {
            return Ok(await _InterfaceFornecedor.List());
        }


        [HttpPost("/api/Fornecedor")]
        [Produces("application/json")]
        public async Task<ActionResult<FornecedorDto>> AdicionarFornecedor([FromBody] FornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crie um novo objeto Fornecedor usando os dados do DTO
            var fornecedor = new Fornecedor
            {
                Nome = fornecedorDto.Nome,
                Email = fornecedorDto.Email,
                Endereco = fornecedorDto.Endereco,
                CNPJ = fornecedorDto.CNPJ,
                ID_Usuario = fornecedorDto.ID_Usuario
            };

            // Insira o novo fornecedor no banco de dados
            await _InterfaceFornecedor.Add(fornecedor);

            // Retorna o novo objeto criado junto com seu ID
            return CreatedAtAction(nameof(AdicionarFornecedor), new { id = fornecedor.IdFornecedor }, fornecedorDto);
        }




        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarFornecedor(long id, [FromBody] FornecedorDto fornecedorDto)
        {
            var fornecedorFromDb = await _InterfaceFornecedor.GetEntityById(id);
            if (fornecedorFromDb == null)
            {
                return NotFound();
            }

            fornecedorFromDb.Nome = fornecedorDto.Nome;
            fornecedorFromDb.Email = fornecedorDto.Email;
            fornecedorFromDb.Endereco = fornecedorDto.Endereco;
            fornecedorFromDb.CNPJ = fornecedorDto.CNPJ;
            fornecedorFromDb.ID_Usuario = fornecedorDto.ID_Usuario;

            await _InterfaceFornecedor.Update(fornecedorFromDb);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarFornecedor(long id)
        {
            var fornecedorFromDb = await _InterfaceFornecedor.GetEntityById(id);
            if (fornecedorFromDb == null)
            {
                return NotFound();
            }

            await _InterfaceFornecedor.Delete(fornecedorFromDb);

            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Fornecedor>> ObterFornecedorPorId(long id)
        {
            var classe = await _InterfaceFornecedor.GetEntityById(id);
            if (classe == null)
            {
                return NotFound();
            }

            return Ok(classe);
        }


    }
}
