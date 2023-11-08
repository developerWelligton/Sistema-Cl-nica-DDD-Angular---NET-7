import { ItemProductSaleService } from './../../../services/itemProductSale.service';
import { UserService } from '../../../core/user/user.service';
// ... previous imports ...

import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { Subscription } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import Swal from 'sweetalert2';
import { SaleProductService } from 'src/app/services/saleProduto.service';


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
}




@Component({
  selector: 'app-panel-pdv',
  templateUrl: './panel-pdv.component.html',
  styleUrls: ['./panel-pdv.component.scss']
})
export class PanelPdvComponent {
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


  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService,
    private productService: ProductService,
    private saleProductService: SaleProductService,
    private itemProductSaleService:ItemProductSaleService,
    private cdr: ChangeDetectorRef
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
                    code:response.idProduto
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
      // If saleId is not set, initiate a new sale
      if (!this.saleId) {
        const saleData = {
          dataVenda: new Date().toISOString(),
          status: 'Pendente',
          iD_Usuario: 1
        };

        this.saleProductService.createSale(saleData).subscribe(response => {
          this.saleId = response.idVenda;  // Assuming the response contains an 'id' field with the sale's ID
          console.log(this.saleId)
          // Add the product to the list only after getting the saleId
          this.productsList.push({ ...this.product });

          // Clear the product object
          this.product = {
            code: '',
            description: '',
            price: 0,
            unit: '',
            quantity: 0,
            image: ''
          };

          // Call the calculateSubtotal method
          this.calculateSubtotal();

          // Show SweetAlert2 notification
          Swal.fire({
            icon: 'success',
            title: 'Venda Iniciada!',
            text: 'A venda foi iniciada com sucesso.',
            timer: 2000,
            showConfirmButton: false
          });

        }, error => {
          console.error("Error initiating sale:", error);
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Houve um erro ao iniciar a venda. Tente novamente.',
            footer: 'Se o problema persistir, contate o suporte.'
          });
        });
      } else {
        // If saleId is already set, just add the product to the list
        this.productsList.push({ ...this.product });

        // Clear the product object
        this.product = {
          code: '',
          description: '',
          price: 0,
          unit: '',
          quantity: 0,
          image: ''
        };

        // Call the calculateSubtotal method
        this.calculateSubtotal();
      }
    }

    // Calculate subtotal
  calculateSubtotal() {
    this.subtotal = this.productsList.reduce((acc, item) => acc + (item.price * item.quantity), 0);
  }

  addFecharVenda(){
    debugger
    console.log(this.productsList);

    // Convertendo os produtos para o formato desejado antes de enviar
    const productListToSend = this.productsList.map(product => ({
      idProduto: product.code,
      idVenda: this.saleId, // supondo que você tem uma saleId, senão, ajuste conforme necessário
      totalProdutosVendas: product.price * product.quantity,
      observacao: '', // preencha conforme necessário
      quantidade: product.quantity
    }));

    this.itemProductSaleService.sendProductList(productListToSend).subscribe(
      response => {
        console.log('Lista de produtos enviada com sucesso:', response);

        // Aqui você pode colocar qualquer lógica posterior que desejar.
        Swal.fire({
          icon: 'success',
          title: 'Sucesso!',
          text: 'Lista de produtos enviada com sucesso!'
        }).then(() => {
          this.router.navigate(['/admin/panel-pdv/payment'], {
            state: {
              saleId: this.saleId,
              total: this.subtotal
            }
          });

        });
      },
      error => {
        console.error("Error sending product list:", error);
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Erro ao enviar a lista de produtos!',
          footer: 'Por favor, tente novamente mais tarde.'
        });
      }
    );
  }


  deleteItemProdutoPorVenda(code: string) {
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
        this.productsList = this.productsList.filter(product => product.code !== code);
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
}



