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
using Domain.Interfaces.IiTemCompraProduto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemProdutoCompraController : ControllerBase
    {
        private readonly InterfaceItemCompraProduto _interfaceItemCompraProduto;
        private readonly IitemProdutoCompraServico _iItemProdutoCompraServico;
        public ItemProdutoCompraController(InterfaceItemCompraProduto interfaceItemCompraProduto, IitemProdutoCompraServico iItemProdutoCompraServico)
        {
            _interfaceItemCompraProduto = interfaceItemCompraProduto;
            _iItemProdutoCompraServico = iItemProdutoCompraServico;
        }


        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<ItemProdutoCompra>>> ListarProdutoCompra()
        {
            return Ok(await _interfaceItemCompraProduto.List());
        }


        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarProdutoCompra([FromBody] ItemProdutoCompraDto itemProdutoCompraDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Converte o ItemProdutoCompraDto para a entidade ItemProdutoCompra
            var itemProdutoCompra = new ItemProdutoCompra
            {
                IdCompra = itemProdutoCompraDto.IdCompra,
                IdProduto = itemProdutoCompraDto.IdProduto,
                DataEntrada = itemProdutoCompraDto.DataEntrada,
                QuantidadeTotal = itemProdutoCompraDto.QuantidadeTotal,
                Lote = itemProdutoCompraDto.Lote
            };

            // Aqui estou assumindo que você tem um serviço ou repositório para adicionar o item à compra
            // O nome deste serviço é apenas um palpite; substitua pelo correto em seu código
            await _interfaceItemCompraProduto.Add(itemProdutoCompra);

            return CreatedAtAction(nameof(CriarProdutoCompra), new { id = itemProdutoCompra.IdProduto }, itemProdutoCompra);
        }





    }
}
