import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/core/user/user.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { AdminService } from 'src/app/services/admin.service';
import { ProductService } from 'src/app/services/product.service';
import { userServiceAPI } from 'src/app/services/userAPI.service';

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
    private productService: ProductService ) { }

    productList: any[] = [];
    listUserGroup: { id: string, name: string }[] = [];

    public containerPadding: string;
    //padding
    private paddingSubscription: Subscription;



  ngOnInit() {
     //padding
     this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });

    this.populateUserGroups();
    this.productService.getAllProductWithUnspsc().subscribe((data: any[]) => {
      console.log(data)
      this.productList = data;
    });
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

  public fetchUsersFromServiceOrUseMockParent(): void {
  }
}
