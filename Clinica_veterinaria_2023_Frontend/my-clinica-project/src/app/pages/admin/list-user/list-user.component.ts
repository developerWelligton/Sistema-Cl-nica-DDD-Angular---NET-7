// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';


export enum UserGroup {
  Cliente = 'cliente',
  Veterinario = 'veterinario',
  Secretaria = 'secretaria',
  Admin = 'admin'
}

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.scss']
})
export class ListUserComponent {
  createUserForm: FormGroup;

  listUserGroup: { id: string, name: string }[] = [];

  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router
  ) {}

  ngOnInit() {
    this.createUserForm = this.fb.group({
      user_nome: [''],
      user_email: [''],
      user_senha: [''],
      user_group:['']
    });
    this.populateUserGroups();
  }

  private populateUserGroups(): void {
    this.listUserGroup = Object.values(UserGroup).map(group => ({
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
