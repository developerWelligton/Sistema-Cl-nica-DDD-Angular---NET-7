using Domain.Interfaces.IAnimal;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IVeterinario;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.IVendaServicoPagamento;
using System.Text.Json;
using System.Text;
using Domain.Interfaces.IVenda;
using Domain.Interfaces.IFamilia;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaServicoPagamentoController : ControllerBase
    {
        private readonly InterfaceVendaServicoPagamento _InterfaceVendaServicoPagamento;
        private readonly IVendaServicoPagamentoServico _IVeterinarioServico;
        private readonly InterfaceItemProdutoVenda _InterfaceItemProdutoVenda;
        private readonly InterfaceItemProdutoEstoque _InterfaceItemProdutoEstoque;
        public VendaServicoPagamentoController(InterfaceVendaServicoPagamento interfaceVendaServicoPagamento,
            IVendaServicoPagamentoServico iVeterinarioServico, InterfaceItemProdutoVenda interfaceItemProdutoVenda,
            InterfaceItemProdutoEstoque interfaceItemProdutoEstoque)
        {
            _InterfaceVendaServicoPagamento = interfaceVendaServicoPagamento;
            _IVeterinarioServico = iVeterinarioServico;
            _InterfaceItemProdutoVenda = interfaceItemProdutoVenda;
            _InterfaceItemProdutoEstoque = interfaceItemProdutoEstoque;
        }


        [HttpPost("/api/VendaServicoPagamento")]
        [Produces("application/json")]
        public async Task<ActionResult<VendaServicoPagamentoDto>> AdicionarPagamento([FromBody] VendaServicoPagamentoDto vendaServicoPagamentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendaServicoPagamento = new VendaServicoPagamento
            {
                DataPagamento = vendaServicoPagamentoDto.DataPagamento,
                Total = vendaServicoPagamentoDto.Total,
                Status = vendaServicoPagamentoDto.Status,
                FormaPagamento = vendaServicoPagamentoDto.FormaPagamento,
                ID_Usuario = vendaServicoPagamentoDto.ID_Usuario,
                IdPedidoServicos = vendaServicoPagamentoDto.IdPedidoServicos,
                IdVenda = vendaServicoPagamentoDto.IdVenda
            };

            await _InterfaceVendaServicoPagamento.Add(vendaServicoPagamento);

            return CreatedAtAction(nameof(AdicionarPagamento), new { id = vendaServicoPagamento.IdVendaServicoPagamento }, vendaServicoPagamento);
        }

        [HttpGet("/api/Pagamentos")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Veterinario>>> ListarPagamentos()
        {
            return Ok(await _InterfaceVendaServicoPagamento.List());
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarPagamento(long id, [FromBody] VendaServicoPagamentoDto vendaServicoPagamentoDto)
        {
            var pagamentoFromDb = await _InterfaceVendaServicoPagamento.GetEntityById(id);
            if (pagamentoFromDb == null)
            {
                return NotFound();
            }

            pagamentoFromDb.DataPagamento = vendaServicoPagamentoDto.DataPagamento;
            pagamentoFromDb.Total = vendaServicoPagamentoDto.Total;
            pagamentoFromDb.Status = vendaServicoPagamentoDto.Status;
            pagamentoFromDb.FormaPagamento = vendaServicoPagamentoDto.FormaPagamento;
            pagamentoFromDb.ID_Usuario = vendaServicoPagamentoDto.ID_Usuario;
            pagamentoFromDb.IdPedidoServicos = vendaServicoPagamentoDto.IdPedidoServicos;
            pagamentoFromDb.IdVenda = vendaServicoPagamentoDto.IdVenda;

            await _InterfaceVendaServicoPagamento.Update(pagamentoFromDb);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarPagamento(long id)
        {
            var pagamentoFromDb = await _InterfaceVendaServicoPagamento.GetEntityById(id);
            if (pagamentoFromDb == null)
            {
                return NotFound();
            }

            await _InterfaceVendaServicoPagamento.Delete(pagamentoFromDb);

            return NoContent();
        }

      

        [HttpGet("/api/GetPagamentoById/{Id}")]
        [Produces("application/json")]
        public async Task<ActionResult<VendaServicoPagamento>> GetPagamentoById(int id)
        {
            // Validate the user ID
            if (id <= 0)
            {
                return BadRequest("User ID must be greater than zero.");
            }

            var pagamento = await _InterfaceVendaServicoPagamento.GetEntityById(id);

            // Check for null
            if (pagamento == null)
            {
                return NotFound($"No veterinarian found for user ID {pagamento}.");
            }

            return Ok(pagamento);
        }


         

            [HttpPost("/api/CreatePaymentLink")]
            [Produces("application/json")]
            public async Task<ActionResult> CreatePaymentLink([FromBody] SaleCreateLinkPaymentDTO saleCreateLinkPaymentDTO)
            {
                var httpClient = new HttpClient();

                // Adding headers
                httpClient.DefaultRequestHeaders.Add("access_token", "$aact_YTU5YTE0M2M2N2I4MTliNzk0YTI5N2U5MzdjNWZmNDQ6OjAwMDAwMDAwMDAwMDAzMjU0NDM6OiRhYWNoX2ZhZDVmN2JjLTI1ODYtNDg2NS1hYzIxLWExNjNhNmUyYTA0Yg==");
                httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                httpClient.DefaultRequestHeaders.Add("Accept", "*/*");

                var payload = new
                { 
                    saleId = saleCreateLinkPaymentDTO.SaleId,
                    billingType = saleCreateLinkPaymentDTO.BillingType,
                    chargeType = saleCreateLinkPaymentDTO.ChargeType,
                    name = saleCreateLinkPaymentDTO.Name,
                    description = saleCreateLinkPaymentDTO.Description,
                    endDate = saleCreateLinkPaymentDTO.EndDate,
                    value = saleCreateLinkPaymentDTO.Value,
                    dueDateLimitDays = saleCreateLinkPaymentDTO.DueDateLimitDays,
                    subscriptionCycle = saleCreateLinkPaymentDTO.SubscriptionCycle,
                    maxInstallmentCount = saleCreateLinkPaymentDTO.MaxInstallmentCount,
                    notificationEnabled = saleCreateLinkPaymentDTO.NotificationEnabled, 
                    /*
                    callback = new
                    {
                        successUrl = saleCreateLinkPaymentDTO.Callback.SuccessUrl,
                        autoRedirect = saleCreateLinkPaymentDTO.Callback.AutoRedirect
                    }*/
                };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.asaas.com/v3/paymentLinks", content);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle the error
                    return BadRequest("Failed to create the payment link.");
                }

                // Fetch the Venda product details
                var vendaProductDetails = await _InterfaceItemProdutoVenda.GetVendaDetailsAsync(payload.saleId);

                // Store products in a stack
                Stack<ItemProdutoVenda> productStack = new Stack<ItemProdutoVenda>();
                foreach (var product in vendaProductDetails)
                {
                    productStack.Push(product);
                }

                // Empty the product stack and process each product
                while (productStack.Count > 0)
                {
                    var currentProduct = productStack.Pop();
                    var stockDetails = await _InterfaceItemProdutoEstoque.GetEstoqueByProduto((int)currentProduct.IdProduto);
                
                    

                    var stockUpdateObject = new StockUpdateObject
                    {
                        idEstoque = stockDetails,
                        idProduto = (int)currentProduct.IdProduto,
                        novaQuantidade = (int)currentProduct.Quantidade
                    };
                
                    // Now call your API or method to update the stock using stockUpdateObject
                   await _InterfaceItemProdutoEstoque.UpdateQuantidadeEstoque(stockUpdateObject.idEstoque, stockUpdateObject.idProduto, stockUpdateObject.novaQuantidade);
                }

            var responseString = await response.Content.ReadAsStringAsync();



            var responseObject = JsonSerializer.Deserialize<PaymentResponse>(responseString);
            return Ok(new { url = responseObject.url });    
        } 

    }
}
