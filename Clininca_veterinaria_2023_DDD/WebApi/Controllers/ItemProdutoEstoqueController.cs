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
using Domain.Interfaces.IEstoque;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemProdutoEstoqueController : ControllerBase
    {
        private readonly InterfaceItemProdutoEstoque _interfaceItemProdutoEstoques;
        private readonly IitemProdutoEstoqueServico _iitemProdutoEstoqueServico;
        private readonly InterfaceEstoque _interfaceEstoque;
        public ItemProdutoEstoqueController(InterfaceItemProdutoEstoque interfaceItemProdutoEstoques, 
            IitemProdutoEstoqueServico iitemProdutoEstoqueServico,
             InterfaceEstoque interfaceEstoque
            )
        {
            _interfaceItemProdutoEstoques = interfaceItemProdutoEstoques;
            _iitemProdutoEstoqueServico = iitemProdutoEstoqueServico;
            _interfaceEstoque = interfaceEstoque;
        }


        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<ItemProdutoEstoque>>> ListarProdutoEstoque()
        {
            return Ok(await _interfaceItemProdutoEstoques.List());
        }


        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarProdutoEstoque([FromBody] ProdutoEstoqueDto produtoEstoqueDto)
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Converte o ProdutoEstoqueDto para a entidade ItemProdutoEstoque
            var itemProdutoEstoque = new ItemProdutoEstoque
            {
                IdProduto = produtoEstoqueDto.IdProduto,
                ID_Usuario = produtoEstoqueDto.ID_Usuario,
                IdEstoque = produtoEstoqueDto.IdEstoque,
                DataEntrada = produtoEstoqueDto.DataEntrada,
                DataSaida = produtoEstoqueDto.DataSaida,
                Status = produtoEstoqueDto.Status,
                Quantidade_Estoque = 0
            };

            // Aqui estou assumindo que você tem um serviço ou repositório para adicionar o item ao estoque
            // O nome deste serviço é apenas um palpite; substitua pelo correto em seu código
            await _interfaceItemProdutoEstoques.Add(itemProdutoEstoque);

            return CreatedAtAction(nameof(CriarProdutoEstoque), new { id = itemProdutoEstoque.IdProduto }, itemProdutoEstoque);
        }

        [HttpPatch("atualizar-quantidade-estoque")] // Usando HTTP PATCH pois é uma atualização parcial 
        public async Task<ActionResult> AtualizarQuantidadeEstoque(int idEstoque, int idProduto, int novaQuantidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _interfaceItemProdutoEstoques.UpdateQuantidadeEstoque(idEstoque, idProduto, novaQuantidade);
                return NoContent(); // Retorna um 204 No Content como resposta de sucesso.
            }
            catch (Exception ex)
            {
                // Maneira adequada de lidar com exceções e retornar uma mensagem de erro.
                return StatusCode(500, $"Erro interno do servidor ao tentar atualizar a quantidade em estoque: {ex.Message}");
            }
        }

        [HttpGet("buscar-estoque")]
        [Produces("application/json")]
        public async Task<ActionResult<int>> BuscarEstoquePorProduto(int idProduto)
        {
            if (idProduto <= 0)
            {
                return BadRequest("IdProduto deve ser maior que zero.");
            }

            var itemProdutoEstoque =  _interfaceItemProdutoEstoques.GetEstoqueByProduto(idProduto);

            if (itemProdutoEstoque == null)
            {
                return NotFound($"Não foi encontrado um estoque para o produto com ID = {idProduto}.");
            }

            /*
            // Assumindo que você tenha a entidade Estoque e o relacionamento entre ItemProdutoEstoque e Estoque,
            // você precisará buscar o estoque relacionado.
            var estoque = await _interfaceEstoque.GetById(itemProdutoEstoque.IdEstoque);
            if (estoque == null)
            {
                return NotFound($"Estoque com ID = {itemProdutoEstoque.IdEstoque} não encontrado.");
            }
            */

            return await itemProdutoEstoque;
        }

        [HttpGet("produtos-por-estoque")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<ItemProdutoEstoque>>> GetProdutosByEstoqueId(int idEstoque)
        {
            if (idEstoque <= 0)
            {
                return BadRequest("IdEstoque deve ser maior que zero.");
            }

            try
            {
                var produtosEstoque = await _interfaceItemProdutoEstoques.GetAllProdutoByStock(idEstoque);

                if (produtosEstoque == null || !produtosEstoque.Any())
                {
                    return NotFound($"Nenhum produto encontrado para o estoque com ID = {idEstoque}.");
                }

                // Se você quiser, pode converter para um DTO antes de retornar. Por enquanto, retornarei a lista diretamente.
                return Ok(produtosEstoque);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor ao tentar buscar produtos: {ex.Message}");
            }
        }


        [HttpGet("itens-por-produto")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<ItemProdutoEstoque>>> GetItensByProdutoId(int idProduto)
        {
            if (idProduto <= 0)
            {
                return BadRequest("IdProduto deve ser maior que zero.");
            }

            try
            {
                var itens = await _interfaceItemProdutoEstoques.GetByProdutoId(idProduto);

                if (itens == null || !itens.Any())
                {
                    return NotFound($"Nenhum item de estoque encontrado para o produto com ID = {idProduto}.");
                }

                return Ok(itens);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor ao tentar buscar itens de estoque: {ex.Message}");
            }
        }


        [HttpPatch("atualizar-status-produto")]
        public async Task<ActionResult> AtualizarStatusProduto([FromBody] StatusUpdateDto statusUpdate)
        {
            try
            {
                await _interfaceItemProdutoEstoques.UpdateStatusByProdutoId(statusUpdate.IdProduto, statusUpdate.IdEstoque);
                return NoContent(); // Retorna um 204 No Content como resposta de sucesso.
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }


    }
    public class StatusUpdateDto
    {
        public int IdEstoque { get; set; }
        public int IdProduto { get; set; }
    }
}
