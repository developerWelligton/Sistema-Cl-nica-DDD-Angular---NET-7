import { ItemProductSaleService } from './../../../services/itemProductSale.service';
import { UserService } from '../../../core/user/user.service';
// ... previous imports ...

import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { Subscription } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import Swal from 'sweetalert2';
import { SaleProductService } from 'src/app/services/saleProduto.service';
import { DataService } from 'src/app/services/data.service';
import { Classe } from 'src/app/models/classe.model';
import { Unspsc } from 'src/app/models/unspsc.model';
import { UnspscService } from 'src/app/services/unspsc.service';
import { SUPPLIERS } from 'src/app/mocks/supplier.mock';
import { ProviderService } from 'src/app/services/provider.service';
import { BuyService } from 'src/app/services/buy.service';
import { ItemProductBuyService } from 'src/app/services/itemProductBuy.service';


export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

//OBJETO PRODUTO
export class Product {
  code:string
  quantity: number;
  description: string;
  price: number;
  unit: string;
  image: string;
  priceBuy: number;
}




@Component({
  selector: 'app-panel-buy',
  templateUrl: './panel-buy.component.html',
  styleUrls: ['./panel-buy.component.scss']
})
export class PanelBuyComponent {
  createSaleForm: FormGroup;

  listUserGroup: { id: string, name: string }[] = [];
  userRole: any;
  //buscar

  public product: Product = new Product();
  public productCode: number;


  productsList = [];
  allProducts: Product[] = [];
  subtotal = 0;
  saleId: number;  // To store the sale's ID



  //padding
  private paddingSubscription: Subscription;
  public containerPadding: string;

  isEditing: boolean = false;
  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService,
    private productService: ProductService,
    private saleProductService: SaleProductService,
    private itemProductSaleService:ItemProductSaleService,
    private cdr: ChangeDetectorRef,
    private unspscService: UnspscService,
    private providerService: ProviderService,
    private buyService: BuyService,
    private itemProductBuyService: ItemProductBuyService
  ) {}

  ngOnInit() {
    //padding
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
  //ROLE
  this.userRole = this.userService.getCurrentUser()
  //alert(this.userRole)
debugger
    this.createSaleForm = this.fb.group({
    });
    this.populateUserGroups();

    this.loadProviders()
  }

  private populateUserGroups(): void {
    let groupsToInclude = [];

    switch (this.userRole) {
      case 'secretaria':
        groupsToInclude = [UserGroup.Cliente];
        break;
      case 'admin':
        groupsToInclude = [
          UserGroup.Cliente,
          UserGroup.Veterinario,
          UserGroup.Secretaria,
          UserGroup.Admin
        ];
        break;
      // You can add more cases as needed
    }

    this.listUserGroup = groupsToInclude.map(group => ({
      id: group,
      name: group
    }));

    console.log(this.listUserGroup); // Check the output
  }

  submitForm() {
    const formData = this.createSaleForm.value;

  }

  //
  searchProduct() {
    this.productService.getProductByCode(this.productCode)
        .subscribe(
            response => {
                console.log(response);

                // Mapeando os dados retornados para o objeto 'Product'
                this.product = {
                    quantity: 1,
                    description: response.descricao,
                    price: response.precoVenda,
                    unit: '', // Como mencionado antes, você pode ajustar conforme necessário
                    image: 'data:image/jpeg;base64,' + response.imagemBase64,
                    code:response.idProduto,
                    priceBuy: response.precoCompra
                };
            },
            error => {
                console.error("Error fetching product:", error);

                // Adicionado o SweetAlert2 para exibir uma notificação de erro
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Produto não encontrado!',
                    footer: 'Tente novamente com outro código'
                });
            }
        );
    }

    addItem() {

        // If saleId is already set, just add the product to the list
        this.productsList.push({ ...this.product });

        // Clear the product object
        this.product = {
          code: '',
          description: '',
          price: 0,
          unit: '',
          quantity: 0,
          image: '',
          priceBuy:0
        };

        // Call the calculateSubtotal method
        this.calculateSubtotal();
      }

    // Calculate subtotal
  calculateSubtotal() {
    this.subtotal = this.productsList.reduce((acc, item) => acc + (item.precoVenda * item.quantity), 0);
  }

  addFecharVenda(){
    // COMPRA
    this.buyService.createBuy(JSON.stringify(this.providerControl)).subscribe(res=>{
      const returnIdCompra = res.idCompra

      // ITEM PRODUTO COMPRA
      debugger
      console.log(this.productsList);
      const productListToSend = this.productsList.map(product => ({
        dataEntrada: new Date().toISOString(), // Use the date from the product, or set the current date as needed
        quantidadeTotal: product.quantity, // Use the quantity from the product
        lote: product.lote || "", // Use the lot from the product
        idCompra: returnIdCompra, // assuming you have a purchaseId, otherwise adjust as necessary
        idProduto: product.code // assuming the product has a 'code' that corresponds to idProduto
      }));

      this.itemProductBuyService.createItemProductsBuy(productListToSend).subscribe(res=>{
        alert(JSON.stringify(res))
      })
    })




    // Convertendo os produtos para o formato desejado antes de enviar
    const productListToSend = this.productsList.map(product => ({
      dataEntrada: product.dataEntrada, // Use the date from the product, or set the current date as needed
      quantidadeTotal: product.quantity, // Use the quantity from the product
      lote: product.lote, // Use the lot from the product
      idCompra: '', // assuming you have a purchaseId, otherwise adjust as necessary
      idProduto: product.code // assuming the product has a 'code' that corresponds to idProduto
    }));


    console.log(JSON.stringify(productListToSend))
    // this.itemProductSaleService.sendProductList(productListToSend).subscribe(
    //   response => {
    //     console.log('Lista de produtos enviada com sucesso:', response);

    //     // Aqui você pode colocar qualquer lógica posterior que desejar.
    //     Swal.fire({
    //       icon: 'success',
    //       title: 'Sucesso!',
    //       text: 'Lista de produtos enviada com sucesso!'
    //     }).then(() => {
    //       this.router.navigate(['/admin/panel-pdv/payment'], {
    //         state: {
    //           saleId: this.saleId,
    //           total: this.subtotal
    //         }
    //       });

    //     });
    //   },
    //   error => {
    //     console.error("Error sending product list:", error);
    //     Swal.fire({
    //       icon: 'error',
    //       title: 'Oops...',
    //       text: 'Erro ao enviar a lista de produtos!',
    //       footer: 'Por favor, tente novamente mais tarde.'
    //     });
    //   }
    // );
  }


  deleteItemProdutoPorVenda(index: number) {
    Swal.fire({
      title: 'Você tem certeza?',
      text: "Você não poderá reverter isso!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sim, exclua!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.productsList.splice(index, 1);
        this.calculateSubtotal();
        this.cdr.detectChanges(); // Atualiza a visualização manualmente

        Swal.fire(
          'Excluído!',
          'O item do produto foi excluído.',
          'success'
        );
      }
    });
  }

  editingProduct: Product | null = null;


  index: any
  EditarItemProdutoPorVenda(index: any) {
    this.startEdit();
    const product = this.productsList[index];
this.index =index;
    this.product = {
      quantity: product.quantity,
      description: product.description,
      price: product.price,
      unit: '', // Como mencionado antes, você pode ajustar conforme necessário
      image: 'data:image/jpeg;base64,' + product.image,
      code:product.code,
      priceBuy:product.precoVenda
  };

  }


  Editar( newQuantity: number ) {
    // Find the product in the products list
    const productIndex = this.productsList[this.index];

    // Check if the product exists
    if (productIndex !== -1) {
      // Update the product's quantity
      this.productsList[this.index].quantity = newQuantity;
      this.isEditing = false;
      this.resetProductForm();
      // Notify the user that the quantity has been updated
      Swal.fire({
        title: 'Success!',
        text: 'The quantity has been updated.',
        icon: 'success',
        confirmButtonText: 'OK'
      });

    } else {
      // Notify the user that the product was not found
      Swal.fire({
        title: 'Error!',
        text: 'Product not found.',
        icon: 'error',
        confirmButtonText: 'OK'
      });
    }
  }



  startEdit() {
    this.isEditing = true;
  }

  stopEdit() {
    this.isEditing = false;
  }

  resetProductForm() {
    // Reset the product model to its default state
    this.product = {
      quantity: null, // or the default quantity value
      description: '',
      price: null,
      unit: '',
      image: '',
      code: '',
      priceBuy:0
    };

    // If you have a form reference, you might also want to reset the form directly
    // this.yourFormReference.reset();
  }

  providers: any;
  providerControl: any;
  onValueChange(): void {

  }

  loadProviders(): void {
    this.providerService.getAllProviders().subscribe((data: any[]) => {
      this.providers = data
        console.log(data)
    }, error => {
        console.error('Error loading FORNECEDORES :', error);
        // Handle error as needed
    })
  }
}


