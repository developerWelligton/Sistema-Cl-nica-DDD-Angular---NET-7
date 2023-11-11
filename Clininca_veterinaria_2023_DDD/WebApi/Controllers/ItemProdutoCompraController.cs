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


        [HttpPost("CriarProdutosVenda")]
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
                await _interfaceItemCompraProduto.Add(item);
            }

            // Return a successful response (modify as needed)
            return Ok(new { Message = "Produtos de compra adicionados com sucesso!" });
        }

        [HttpPost("FinalizarProdutoCompraAsync")]
        [Produces("application/json")]
        public async Task<ActionResult> FinalizarProdutoCompraAsync([FromBody] List<ItemProdutoCompraDto> itensProdutoCompraDto)
        {
            try
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

                // Save each item to the database
                foreach (var item in itensProdutoCompra)
                {
                    var produtoId = (int)item.IdProduto;
                    var novaQuantidade = item.QuantidadeTotal;

                    var estoqueIdTask = await _interfaceItemProdutoEstoque.GetEstoqueByProduto(produtoId);
                    int idEstoque = estoqueIdTask;

                    // If estoqueId is not null, safely cast it to int and call UpdateQuantidadeEstoqueCompra
                    await _interfaceItemProdutoEstoque.UpdateQuantidadeEstoqueCompra(((int)idEstoque), produtoId, (int)novaQuantidade);
                }


                return Ok(new { Message = "Produtos de compra adicionados com sucesso!" });
            }
            catch (Exception ex)
            { 

                // Return a generic error message
                return StatusCode(500, "Internal Server Error");
            }
        }
         

        [HttpGet("produtos-por-compra")] // Ensure this route matches your Angular service call
        public async Task<ActionResult<IEnumerable<ItemProdutoCompra>>> ListarProdutoCompra([FromQuery] int idCompra)
        {
            try
            {
                var produtos = await _interfaceItemCompraProduto.GetAllProdutoByBuy(idCompra);

                if (produtos == null || !produtos.Any())
                {
                    return NotFound($"Nenhum produto encontrado para a compra com ID: {idCompra}");
                }

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }





    }
}
