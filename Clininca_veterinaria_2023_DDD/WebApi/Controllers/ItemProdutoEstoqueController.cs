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
                Status = produtoEstoqueDto.Status
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





    }
}
