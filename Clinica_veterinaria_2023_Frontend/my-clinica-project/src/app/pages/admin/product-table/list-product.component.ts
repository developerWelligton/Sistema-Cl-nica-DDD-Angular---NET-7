import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/core/user/user.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { AdminService } from 'src/app/services/admin.service';
import { ProductService } from 'src/app/services/product.service';
import { userServiceAPI } from 'src/app/services/userAPI.service';
import Swal from 'sweetalert2';

export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.scss']
})
export class ListProductComponent {
  constructor(
    private adminService: AdminService,
    private paddingService: PaddingService,
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router) { }

    productList: any[] = [];
    listUserGroup: { id: string, name: string }[] = [];

    unspscId:any

    public containerPadding: string;
    //padding
    private paddingSubscription: Subscription;



  ngOnInit() {
    //PEGAR CÓDIGO UNSPSC
    this.unspscId = this.route.snapshot.paramMap.get('idUnspsc');

    this.populateUserGroups();
    //PEGAR CÓDIGO UNSPSC

    //CARREGAR PRODUTOS
    if(!this.unspscId){
      this.loadProducts();
    }else{
      this.loadProductsByUnspsc(this.unspscId)
    }



  }

  loadProducts() {
    this.productService.getAllProductWithUnspsc().subscribe((data: any[]) => {
      console.log(data);
      this.productList = data;
    });
  }
//carregar produto por id unspsc
  loadProductsByUnspsc(idUnspsc:any) {
    this.productService.getAllProductFromUnspsc(idUnspsc).subscribe(data => {
      console.log(JSON.stringify(data))
      this.productList = data;
    })
  }



  private populateUserGroups(): void {
    this.listUserGroup = Object.values(UserGroup).map(group => ({
      id: group,
      name: group
    }));
    console.log(this.listUserGroup);
  }

  // Mock data for demonstration
  private MOCK_DATA = [
    { iD_Usuario: 1, nome: 'John Doe', email: 'john@example.com', role: 'admin' },
    { iD_Usuario: 2, nome: 'Jane Smith', email: 'jane@example.com', role: 'cliente' },
    // ... other mock data ...
  ];

  applyFilter(name: string, email: string, role: string): void {
    const nameFilterValue = name.trim().toLowerCase();
    const emailFilterValue = email.trim().toLowerCase();
    const roleFilterValue = role.trim().toLowerCase();

    this.productList = this.productList.filter(user =>
      user.nome.toLowerCase().includes(nameFilterValue) &&
      user.email.toLowerCase().includes(emailFilterValue) &&
      user.role.toLowerCase().includes(roleFilterValue)
    );
  }



  onDeleteRequest(idProduct: number) {
    // Exibe um alerta de confirmação antes de deletar
    Swal.fire({
      title: 'Tem certeza?',
      text: "Você não poderá reverter isso!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, deletar!',
      cancelButtonText: 'Não, cancelar!',
      reverseButtons: true
    }).then((result) => {
      if (result.isConfirmed) {
        // Se o usuário confirmou, então deletamos o produto
        this.productService.deleteProductCode(idProduct).subscribe(
          response => {
            // Produto deletado com sucesso. Podemos informar o usuário e atualizar a lista de produtos.
            Swal.fire(
              'Deletado!',
              'O produto foi deletado.',
              'success'
            );
             // Chame loadProducts para atualizar a lista após a deleção bem-sucedida
             this.loadProducts();
          },
          error => {
            // Erro ao deletar o produto. Informamos o usuário.
            Swal.fire(
              'Erro!',
              'Ocorreu um erro ao deletar o produto.',
              'error'
            );
          }
        );
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        // Se o usuário cancelou, podemos informá-lo também.
        Swal.fire(
          'Cancelado',
          'O produto está seguro :)',
          'error'
        );
      }
    });
  }

  AddProductByUnspsc() {
    this.router.navigate([`/admin/create-product/${this.unspscId}`]);
  }

}
