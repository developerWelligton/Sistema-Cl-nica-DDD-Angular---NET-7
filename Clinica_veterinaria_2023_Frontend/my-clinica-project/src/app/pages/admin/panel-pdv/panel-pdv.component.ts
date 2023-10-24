import { UserService } from '../../../core/user/user.service';
// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { Subscription } from 'rxjs';


export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

@Component({
  selector: 'app-panel-pdv',
  templateUrl: './panel-pdv.component.html',
  styleUrls: ['./panel-pdv.component.scss']
})
export class PanelPdvComponent {
  createUserForm: FormGroup;
  listUserGroup: { id: string, name: string }[] = [];
  userRole: any;
  //padding
  private paddingSubscription: Subscription;
  public containerPadding: string;

  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private userService: UserService,
    private paddingService: PaddingService
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
    this.createUserForm = this.fb.group({
      user_nome: [''],
      user_cpf:[''],
      user_email: [''],
      user_senha: [''],
      user_group:['']
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
    const formData = this.createUserForm.value;

    if (this.createUserForm.valid) {
        this.adminService.createAdmin(formData).subscribe(
            res => {
                console.log('API Success UsuarioClinica POST:', res);
                this.router.navigate(['/admin']);
            },
            error => {
                console.error('Error:', error.error.message);
            }
        );
    } else {
        // Handle form invalid case
        console.error('Form is invalid.');
        // TODO: Show a user-friendly message to the user or highlight the invalid fields
    }
  }
}
