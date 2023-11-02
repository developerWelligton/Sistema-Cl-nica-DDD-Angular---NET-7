import { UserService } from '../../../core/user/user.service';
// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';   // Replace with the actual path to your service
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';
import { UnspscService } from 'src/app/services/unspsc.service';
import { Unspsc } from 'src/app/models/unspsc.model';
import { ProductService } from 'src/app/services/product.service';
import { StockService } from 'src/app/services/stock.service';


export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

@Component({
  selector: 'app-create-estoque',
  templateUrl: './create-estoque.component.html',
  styleUrls: ['./create-estoque.component.scss']
})
export class CreateEstoqueComponent {
  listUserGroup: { id: string, name: string }[] = [];
  userRole: any;
  //padding
  private paddingSubscription: Subscription;
  public containerPadding: string;


  createEstoqueForm: FormGroup;


  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService,
    private stockService: StockService
  ) {}

  ngOnInit() {

    this.createEstoqueForm = this.fb.group({
      productName: ['', Validators.required],
      productDescription: ['', Validators.required],
    });
    //padding
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
    //ROLE
    this.userRole = this.userService.getCurrentUser()
    //alert(this.userRole)


  }








  submitForm(event?: Event): void {
    debugger
    event?.preventDefault();

      if (this.createEstoqueForm.valid) {
        console.log('Formulário Enviado', this.createEstoqueForm.value);

          this.stockService.createStock(this.createEstoqueForm.value).subscribe(res=> {
            console.log(res)
          })

      }
  }


}
