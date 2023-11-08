import { FormControl, FormGroup } from '@angular/forms';
import { ProductService } from './../../../../services/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  products: any[] =[];
  stokeId: any;

 //
  public showModal: boolean = false;
  public selectedProduct: any = null; // This will hold the selected product
  public productQuantity: number = 1; // Default quantity
 //

 form: FormGroup;

 //
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

  constructor(
    private itemProductStockService : ItemProductStockService,
    private route: ActivatedRoute,
    private productService : ProductService
    ) {
    // For now, we'll use the mock data
    this.productList = this.mockProducts;
  }

  ngOnInit() {
    // Usar 'snapshot' é OK para o valor inicial, mas se o id pode mudar sem recriar o componente, você deve se inscrever às mudanças
    this.stokeId = +this.route.snapshot.paramMap.get('id');
    // Here you would subscribe to a service that provides padding value
    // For mockup purposes, we'll set a static value
    this.containerPadding = '15px';

    if ( this.stokeId) {
        this.itemProductStockService.getAllProductListByStock( this.stokeId).subscribe(
          data => {
            console.log(data);
            this.productList = data;
          },
          error => {
            console.error("Error:", error);
          }
        );
      } else {
        // Lidar com o caso de não haver 'id' ou ser inválido
        console.error('Invalid or missing stock ID!');
      }

      this.loadProducts();


      this.form = new FormGroup({
        products: new FormControl(), // default value can be an empty string or a specific id
        iD_Usuario: new FormControl(1), // Assuming a default user ID of 1
        idEstoque: new FormControl( this.stokeId), // default value can be an empty string or a specific id
        dataEntrada: new FormControl(new Date().toISOString()), // Set to current date-time by default
        dataSaida: new FormControl(new Date().toISOString()), // Set to current date-time by default
        status: new FormControl('Disponível') // Assuming 'Disponível' as a default status
      });

  }

  ngOnDestroy() {
    // Remember to unsubscribe from any subscriptions to avoid memory leaks
    if (this.paddingSubscription) {
      this.paddingSubscription.unsubscribe();
    }
  }


  openModal(): void {
    this.showModal = true;
    // Additional logic to prepare the modal if necessary
  }

  onCloseModal(): void {
    this.showModal = false;
  }

  loadProducts(): void {
    this.productService.getAllProductWithUnspsc().subscribe((data: any[]) => {
      this.products = data;
      // You might need to log the structure of 'data' to ensure it's an array of objects with 'nome' and 'idProduto' properties.
    }, error => {
      console.error('Error loading UNSPSC codes:', error);
    });
  }

  onProductSelected(product: any): void {
    this.selectedProduct = product;
  }
  onSubmit() {
    console.log(this.form.value); // Logs the form's values
    this.onCloseModal();

    this.productService.createOrUpdateStockItem(this.form.value).subscribe({
      next: (data) => {
        console.log(data);
        // Assuming you want to refresh the list of products associated with a particular stock
        const stockId = this.form.get('idEstoque').value; // Retrieve the stock ID from the form
        if (stockId) {
          // Only attempt to load the products if we have a valid stock ID
          this.itemProductStockService.getAllProductListByStock(stockId).subscribe({
            next: (productData) => {
              this.productList = productData; // Updates the productList with the new data
            },
            error: (error) => {
              console.error("Error loading product list by stock:", error);
            }
          });
        }
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  deleteProductFromStock(idProduto:any){
    console.log(idProduto)
    console.log( this.stokeId)
    //this.itemProductStockService.deleteProductFromStoke()
  }

}
