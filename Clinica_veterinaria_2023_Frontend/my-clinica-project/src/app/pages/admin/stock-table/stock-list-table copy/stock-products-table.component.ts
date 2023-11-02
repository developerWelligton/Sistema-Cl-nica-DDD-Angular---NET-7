import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ItemProductStockService } from 'src/app/services/itemProductStock.service';

@Component({
  selector: 'app-stock-products-table',
  templateUrl: './stock-products-table.component.html',
  styleUrls: ['./stock-products-table.component.scss']
})
export class StockProductsTableComponent implements OnInit {
  containerPadding: string;
  paddingSubscription: Subscription;
  productList: any[] = [];

  // Mock data - this should eventually come from a backend API
  // You might want to create a Product model/interface to type your products
  mockProducts = [
    {
      idProduto: '001',
      codigoSfcm: '12345678',
      nome: 'Produto Exemplo 1',
      descricao: 'Descrição do produto 1',
      precoCompra: 'R$ 10,00',
      precoVenda: 'R$ 15,00',
      status: 'Disponível'
    },
    // Add more mock product objects here
  ];

  constructor(private itemProductStockService : ItemProductStockService) {
    // For now, we'll use the mock data
    this.productList = this.mockProducts;
  }

  ngOnInit() {
    // Here you would subscribe to a service that provides padding value
    // For mockup purposes, we'll set a static value
    this.containerPadding = '15px';
    this.itemProductStockService.getAllProductListByStock(40002).subscribe(
      data => {
        console.log(data);
        this.productList = data;
      },
      error => {
        console.error("Error:", error);
      }
    );
  }

  ngOnDestroy() {
    // Remember to unsubscribe from any subscriptions to avoid memory leaks
    if (this.paddingSubscription) {
      this.paddingSubscription.unsubscribe();
    }
  }

  // Implement or mock the edit, view, and delete methods as required for UI purposes
}
