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
using Domain.Interfaces.IVenda;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemProdutoVendaController : ControllerBase
    {
        private readonly InterfaceItemProdutoVenda _interfaceItemProdutoVendas;
        private readonly IitemProdutoVendaServico _itemProdutoVendaServico;
        public ItemProdutoVendaController(InterfaceItemProdutoVenda interfaceItemProdutoVendas, IitemProdutoVendaServico iitemProdutoVendaServico)
        {
            _interfaceItemProdutoVendas = interfaceItemProdutoVendas;
            _itemProdutoVendaServico = iitemProdutoVendaServico;
        }


        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<ItemProdutoVenda>>> ListarProdutoVenda()
        {
            return Ok(await _interfaceItemProdutoVendas.List());
        }


        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarProdutosVenda([FromBody] List<ProdutoVendaDto> produtosVendaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Convert the list of ProdutoVendaDto to a list of ItemProdutoVenda entities
            var itemsProdutoVenda = produtosVendaDto.Select(p => new ItemProdutoVenda
            {
                IdProduto = p.IdProduto,
                IdVenda = p.IdVenda,
                Observacao = p.Observacao,
                Quantidade = p.Quantidade
                // Add other properties here
            }).ToList();

            // Now, you can save each item to the database
            foreach (var item in itemsProdutoVenda)
            {
                await _interfaceItemProdutoVendas.Add(item);
            }

            // Return a successful response (modify as needed)
            return Ok(new { Message = "Produtos added successfully!" });
        }



    }
}
