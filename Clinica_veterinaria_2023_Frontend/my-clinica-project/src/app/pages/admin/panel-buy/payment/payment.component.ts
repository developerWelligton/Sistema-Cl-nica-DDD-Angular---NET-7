import { ItemProductStockService } from './../../../../services/itemProductStock.service';
import { ItemProductBuyService } from './../../../../services/itemProductBuy.service';
import { ProductService } from './../../../../services/product.service';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { PaddingService } from 'src/app/services/Padding.service';
import { AsaasService } from 'src/app/services/asaas.service';
import { DataService } from 'src/app/services/data.service';
import { SaleServicePaymentService } from 'src/app/services/saleServicePayment.service';
import Swal from 'sweetalert2';


import { MatDialog } from '@angular/material/dialog';
import { ModalStockComponent } from '../modal-stock/modal-stock.component';
import { ItemProductSaleService } from 'src/app/services/itemProductSale.service';


@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent {
  public containerPadding: string;
  private paddingSubscription: Subscription;

  isPaymentCardVisible: boolean = false;
  isCashPaymentCardVisible: boolean = false; // você pode modificar isso conforme a lógica da sua aplicação

  paymentForm: FormGroup;
  cashPaymentForm: FormGroup;

  saleIdPayment:any
  totalPayment:any

  constructor(
    private paddingService: PaddingService,
    private dataService: DataService,
    private asaasService: AsaasService,
    private saleServicePaymentService:SaleServicePaymentService,
    private router: Router,
    private routerActivate: ActivatedRoute,
    private productService: ProductService,
    public dialog: MatDialog,
    private itemProductSaleService: ItemProductSaleService,
    private itemProductBuyService:ItemProductBuyService,
    private itemProductStockService: ItemProductStockService
  ) {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation.extras.state as {saleId: number, total: number};

    if (state) {
      this.saleIdPayment = state.saleId;
      this.totalPayment = state.total;
    }
   }

   buyId:any

  ngOnInit() {

    this.buyId = this.routerActivate.snapshot.paramMap.get('id');
    //alert( this.buyId)
    this.itemProductSaleService.getAllProductListByBuy(this.buyId).subscribe(data => {
      // Aqui está assumindo que data é um array de objetos com a estrutura desejada
      // Transforma os dados recebidos para a nova estrutura e adiciona à lista de produtos
      const newProducts = data.map(item => ({
        dataEntrada: item.dataEntrada || "", // Use a data de entrada fornecida
        quantidadeTotal: item.quantidadeTotal || "", // Use a quantidade total fornecida
        lote: item.lote || "", // Use o lote fornecido
        idCompra: item.idCompra  , // Use o ID de compra fornecido
        idProduto: item.idProduto,  // Use o ID do produto fornecido
        idEstoque: ""
      }));

      //alert(JSON.stringify(newProducts))
      // Aqui você pode concatenar a nova lista de produtos com a lista existente
      // ou substituir a lista antiga pela nova, dependendo do comportamento desejado
      this.productsList = [...this.productsList, ...newProducts];

      for(let product of this.productsList){
        debugger
        this.itemProductStockService.GetEstoqueId(product.idProduto).subscribe(data => {
          for(let product of data){
            //console.log(product)
            this.productsList2.push(product)
          }

        })
      }


    });





  }

//----------------------------------TIME LINE
events = [
  {
    timestamp: new Date(2023, 10, 1),
    title: 'Pedido da Compra Foi Realizado',
    content: 'O pedido foi recebido e está aguardando processamento.'
  },
  {
    timestamp: new Date(2023, 10, 10),
    title: 'Em Trânsito',
    content: 'O produto está em trânsito.'
  },
  {
    timestamp: new Date(2023, 10, 20),
    title: 'Confirme a Chegada',
    content: 'Confirme a chegada do produto.',
  },
];

updateProductsListWithSelected(productsList: any[], selectedProducts: { [key: string]: string }): any[] {
  debugger
  return productsList.map(product => {
    if (selectedProducts[product.idProduto]) {
      // Se o produto está em selectedProducts, atualize idEstoque
      return { ...product, idEstoque: selectedProducts[product.idProduto] };
    }
    // Se o produto não está em selectedProducts, mantenha-o como está
    return product;
  });
}
productsList = [];// produtos para serem finalizandos
productsList2 = [];// produtos para serem finalizandos

openEstoqueModal() {
  debugger
  console.log(JSON.stringify(this.selectedProducts));


  const dialogRef = this.dialog.open(ModalStockComponent, {
    width: '250px',
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result === 'confirmar') {
      // Se a confirmação for feita no modal, execute a ação

      const updatedProductsList = this.updateProductsListWithSelected(this.productsList, this.selectedProducts);
      console.log(this.productsList)
      this.itemProductBuyService.finalizarProdutoCompraAsync(updatedProductsList).subscribe(
        data => {
          // Navegar para o painel de administração após a atualização do estoque
          this.router.navigate(['admin', 'panel-buy']);

          // Exibir Swal confirmando a atualização do estoque
          Swal.fire({
            title: 'Produto Recebido!',
            text: 'O estoque foi atualizado com sucesso.',
            icon: 'success',
            confirmButtonText: 'Ok'
          });
        },
        error => {
          // Tratar erros aqui, se necessário
          console.error('Erro ao atualizar o estoque:', error);
          Swal.fire({
            title: 'Erro!',
            text: 'Houve um problema ao atualizar o estoque.',
            icon: 'error',
            confirmButtonText: 'Ok'
          });
        }
      );
    }
  });
}





atualizaEstoque(){

}
selectedProducts: { [key: string]: string } = {};
// Função para atualizar o estoque
updateStock(product: any, event: Event) {
  debugger
  const checkbox = event.target as HTMLInputElement;
  const isChecked = checkbox.checked;

  if (isChecked) {
    this.selectedProducts[product.idProduto] = product.idEstoque;
  } else if (this.selectedProducts[product.idProduto] === product.idEstoque) {
    delete this.selectedProducts[product.idProduto];
  }
  console.log(this.selectedProducts)
}

}
