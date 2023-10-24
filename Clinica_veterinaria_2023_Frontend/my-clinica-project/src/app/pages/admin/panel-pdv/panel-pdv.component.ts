import { UserService } from '../../../core/user/user.service';
// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { Subscription } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import Swal from 'sweetalert2';


export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

//OBJETO PRODUTO
export class Product {
  quantity: number;
  description: string;
  price: string;
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



  //padding
  private paddingSubscription: Subscription;
  public containerPadding: string;


  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService,
    private productService: ProductService
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
                    quantity: response.quantidade,
                    description: response.descricao,
                    price: response.precoVenda,
                    unit: '', // Como mencionado antes, você pode ajustar conforme necessário
                    image: 'data:image/jpeg;base64,' + response.imagemBase64
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

}
