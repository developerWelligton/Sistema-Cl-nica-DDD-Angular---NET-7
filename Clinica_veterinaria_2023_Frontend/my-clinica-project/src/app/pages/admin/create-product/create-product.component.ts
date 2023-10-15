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

  unspscCodes: Unspsc[] = [];

  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService,
    private unspscService : UnspscService
  ) {}

  ngOnInit() {
    this.createProductForm = this.fb.group({
      file: ['', Validators.required],
      productName: ['', Validators.required],
      purchasePrice: ['', [Validators.required, Validators.min(0)]],
      sellingPrice: ['', [Validators.required, Validators.min(0.01)]],
      productDescription: ['', Validators.required],
      unspsc:['',Validators.required]
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

    this.loadUnspsc();
  }


  handleFile(event: any): void {
    console.log(event);
    this.file = event.target.files[0] ?? null;

    const reader = new FileReader();
    reader.onload = (e: any) => {
        this.preview = e.target.result;
        const base64File = e.target.result.split(',')[1];

        // Adding a log to check the base64 string.
        console.log('Base64 File: ', base64File);

        this.createProductForm.patchValue({file: base64File});

        // Logging the form value to check if the file data is being set.
        console.log('Form Value after File Select: ', this.createProductForm.value);
    };
    reader.readAsDataURL(this.file);
  }


  loadUnspsc(): void {
    this.unspscService.getAllUnspscCodeDetails().subscribe((data: Unspsc[]) => {
        console.log(data)
        this.unspscCodes = data;
    }, error => {
        console.error('Error loading UNSPSC codes:', error);
        // Handle error as needed
    })
}



  submitForm(event?: Event): void {
    const unspscControl = this.createProductForm.get('unspsc');
    console.log("TESTE"+unspscControl)
    event?.preventDefault();
    //console.log('File Control Value: ', fileControl?.value);
    console.log('Form Value on Submit: ', this.createProductForm.value);
    if (this.createProductForm.valid) {
      console.log('Formulário Enviado', this.createProductForm.value);
      console.log(this.file)
    } else {
      console.log('Formulário inválido');
    }
  }


}
