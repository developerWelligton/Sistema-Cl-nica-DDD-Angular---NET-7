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
        private readonly InterfaceItemProdutoEstoque _interfaceItemProdutoEstoque;
        private readonly IitemProdutoCompraServico _iItemProdutoCompraServico;
        public ItemProdutoCompraController(InterfaceItemProdutoEstoque interfaceItemProdutoEstoque, InterfaceItemCompraProduto interfaceItemCompraProduto, IitemProdutoCompraServico iItemProdutoCompraServico)
        {
            _interfaceItemProdutoEstoque = interfaceItemProdutoEstoque;
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
        public async Task<ActionResult> CriarProdutoCompra([FromBody] List<ItemProdutoCompraDto> itensProdutoCompraDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Convert the list of ItemProdutoCompraDto to a list of ItemProdutoCompra entities
            var itensProdutoCompra = itensProdutoCompraDto.Select(dto => new ItemProdutoCompra
            {
                IdCompra = dto.IdCompra,
                IdProduto = dto.IdProduto,
                DataEntrada = dto.DataEntrada,
                QuantidadeTotal = dto.QuantidadeTotal,
                Lote = dto.Lote
                // Add other properties here if needed
            }).ToList();

            // Now, you can save each item to the database
            foreach (var item in itensProdutoCompra)
            {
                //await _interfaceItemCompraProduto.Add(item);
                var produtoId = (int)item.IdProduto;
                var novaQuantidade = 10;
                var estoqueId = await _interfaceItemProdutoEstoque.GetEstoqueByProduto((int)item.IdProduto);

                await _interfaceItemProdutoEstoque.UpdateQuantidadeEstoqueCompra(estoqueId, produtoId, novaQuantidade);
            }

            // Return a successful response (modify as needed)
            return Ok(new { Message = "Produtos de compra adicionados com sucesso!" });
        }

   





    }
}
