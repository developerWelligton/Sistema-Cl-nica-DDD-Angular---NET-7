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

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly InterfaceProduto _interfaceProdutos;
        private readonly IProdutoServico _produtoServico;
        public ProdutoController(InterfaceProduto interfaceProduto, IProdutoServico produtoServico)
        {
            _interfaceProdutos = interfaceProduto;
            _produtoServico = produtoServico;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Produto>>> ListarProdutos()
        {
            return Ok(await _interfaceProdutos.List());
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CriarProduto([FromBody] ProdutoDto produtoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Converte o ProdutoDto para a entidade Produto
            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                PrecoCompra = produtoDto.PrecoCompra,
                PrecoVenda = produtoDto.PrecoVenda,
                DataValidade = produtoDto.DataValidade,
                Quantidade = produtoDto.Quantidade,
                Status = produtoDto.Status,
                ID_Usuario = produtoDto.ID_Usuario,
                IdUnspsc = produtoDto.IdUnspsc
            };

            // Aqui eu estou assumindo que você tem um serviço ou repositório para adicionar o produto
            // O nome deste serviço é apenas um palpite, substitua pelo correto em seu código
            await _interfaceProdutos.Add(produto);

            return CreatedAtAction(nameof(CriarProduto), new { id = produto.IdProduto }, produto);
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> ExcluirProduto(long id) // Observe que o tipo do id deve ser o mesmo da sua entidade Produto. Neste caso, usei long.
        {
            var produto = await _interfaceProdutos.GetEntityById(id); // Substitua _interfaceProdutos pelo nome real do seu serviço ou repositório para Produtos

            if (produto == null)
            {
                return NotFound();
            }

            await _interfaceProdutos.Delete(produto); // Substitua _interfaceProdutos pelo nome real do seu serviço ou repositório para Produtos

            return NoContent();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<Produto>> ObterProdutoPorId(long id) // O tipo de retorno agora é Produto, em vez de Familia
        {
            var produto = await _interfaceProdutos.GetEntityById(id); // Substitua _interfaceProdutos pelo nome real do seu serviço ou repositório para Produtos

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpGet("WithInspsc")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Produto>>> ListarProdutosWithInspsc()
        {
            try
            {
                // Replace "_produtoServico" with the actual service or repository where "GetAllProductWithInspsc" is implemented.
                var produtos = await _interfaceProdutos.GetAllProductWithInspsc();

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                // Log the exception message to your logger here.
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
