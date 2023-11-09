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
import { ProviderService } from 'src/app/services/provider.service';


export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

@Component({
  selector: 'app-create-provider',
  templateUrl: './create-provider.component.html',
  styleUrls: ['./create-provider.component.scss']
})
export class CreateProviderComponent {
  listUserGroup: { id: string, name: string }[] = [];
  userRole: any;
  //padding
  private paddingSubscription: Subscription;
  public containerPadding: string;


  createProviderForm: FormGroup;


  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService,
    private stockService: StockService,
    private providerService: ProviderService
  ) {}

  ngOnInit() {
    this.createProviderForm = this.fb.group({
      nome: ['', Validators.required], // assuming name is required
      email: ['', [Validators.required, Validators.email]], // assuming email is required and should be valid
      endereco: ['', Validators.required], // assuming address is required
      cnpj: ['', [Validators.required]], // assuming CNPJ is required and should have 14 digits
      iD_Usuario: ['1'] // assuming user ID is required and the default value is 0
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

      if (this.createProviderForm.valid) {
        console.log('Formulário Enviado', this.createProviderForm.value);
        this.providerService.createProvider(this.createProviderForm.value).subscribe(res=>{
          console.log(res)
        })


      }
  }


}
