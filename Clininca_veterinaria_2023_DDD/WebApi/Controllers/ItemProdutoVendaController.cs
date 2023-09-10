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
        public async Task<ActionResult> CriarProdutoVenda([FromBody] ProdutoVendaDto produtoVendaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Converte o ProdutoVendaDto para a entidade ItemProdutoVenda
            var itemProdutoVenda = new ItemProdutoVenda
            {
                IdProduto = produtoVendaDto.IdProduto,
                IdVenda = produtoVendaDto.IdVenda, 
                Observacao = produtoVendaDto.Observacao, 
            };

            // Aqui estou assumindo que você tem um serviço ou repositório para adicionar o item de produto à venda
            // O nome deste serviço é apenas um palpite; substitua pelo correto em seu código
            await _interfaceItemProdutoVendas.Add(itemProdutoVenda);

            // Aqui você pode adicionar lógica adicional, se necessário

            return CreatedAtAction(nameof(CriarProdutoVenda), new { id = itemProdutoVenda.IdVenda }, itemProdutoVenda);
        }



    }
}
