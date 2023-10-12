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
using Domain.Interfaces.IUnspscCode;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnspscCodeController : ControllerBase
    {
        private readonly InterfaceUnspscCode _interfaceUnspscCodes;
        private readonly IUnspscCodeServico _unspscCodeServico;
        public UnspscCodeController(InterfaceUnspscCode interfaceUnspscCode, IUnspscCodeServico unspscCodeServico)
        {
            _interfaceUnspscCodes = interfaceUnspscCode;
            _unspscCodeServico = unspscCodeServico;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UnspscCode>>> ListarUnspscCode()
        {
            return Ok(await _interfaceUnspscCodes.List());
        }

        [HttpGet("ListarComDescricao")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UnspscCode>>> ListUnspscWithDescription()
        {
            return Ok(await _interfaceUnspscCodes.GetAllUnspscCodeDetails());
        }

         



        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarUnspscCode([FromBody] UnspscCodeDto unspscCodeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Assuming you have a corresponding service or repository to interact with the UnspscCode entity
            var unspscCode = new UnspscCode
            {
                CodigoSfcm = unspscCodeDto.CodigoSfcm,
                ID_Usuario = unspscCodeDto.ID_Usuario,
                IdSegmento = unspscCodeDto.IdSegmento,
                IdFamilia = unspscCodeDto.IdFamilia,
                IdClasse = unspscCodeDto.IdClasse,
                IdMercadoria = unspscCodeDto.IdMercadoria,
            };

            // Assuming _interfaceUnspscCodes is your service or repository for UnspscCode
            await _interfaceUnspscCodes.Add(unspscCode);

            // You'll need to change this to the actual name of the method that handles the creation of UnspscCode
            return CreatedAtAction(nameof(CriarUnspscCode), new { id = unspscCode.IdUnspsc }, unspscCode);
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> ExcluirUnspscCode(long id) // Note that the type is long to match your IdUnspsc
        {
            var unspscCode = await _interfaceUnspscCodes.GetEntityById(id); // Replace with your actual method name

            if (unspscCode == null)
            {
                return NotFound();
            }

            await _interfaceUnspscCodes.Delete(unspscCode); // Replace with your actual method name

            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<UnspscCode>> ObterUnspscCodePorId(long id)  // Change the return type to UnspscCode
        {
            var unspscCode = await _interfaceUnspscCodes.GetEntityById(id);  // Replace with your actual method name

            if (unspscCode == null)
            {
                return NotFound();
            }

            return Ok(unspscCode);
        }
          
    }
}
