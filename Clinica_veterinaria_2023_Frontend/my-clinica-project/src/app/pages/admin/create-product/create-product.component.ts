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


export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

@Component({
  selector: 'app-create-user',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss']
})
export class CreateProductComponent {
  listUserGroup: { id: string, name: string }[] = [];
  userRole: any;
  //padding
  private paddingSubscription: Subscription;
  public containerPadding: string;


  createProductForm: FormGroup;
  file: File;
  preview: string;

  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService
  ) {}

  ngOnInit() {
    this.createProductForm = this.fb.group({
      file: ['', Validators.required],
      productName: ['', Validators.required],
      productBarcode: ['', Validators.required],
      purchasePrice: ['', [Validators.required, Validators.min(0)]],
      sellingPrice: ['', [Validators.required, Validators.min(0.01)]],
      model: ['', Validators.required],
      itemType: ['', Validators.required],
      productDescription: ['', Validators.required]
      // Add similar form controls for all other form fields
      // ...
    });
    //padding
    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
    //ROLE
    this.userRole = this.userService.getCurrentUser()
    //alert(this.userRole)
  }


  handleFile(event: any): void {
    console.log(event);  // Verifique se este log aparece no console quando um arquivo é selecionado.
    this.file = event.target.files[0] ?? null;

    const reader = new FileReader();
    reader.onload = (e: any) => this.preview = e.target.result;
    reader.readAsDataURL(this.file);
  }



  submitForm(event?: Event): void {
    const fileControl = this.createProductForm.get('file');
    event?.preventDefault();
    console.log(fileControl)
    if (this.createProductForm.valid) {
      console.log('Formulário Enviado', this.createProductForm.value);
    } else {
      console.log('Formulário inválido');
    }
  }


}
