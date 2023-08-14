// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service


export enum UserGroup {
  Cliente = 'Cliente',
  Veterinario = 'Veterinário',
  Secretaria = 'Secretaria'
}

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.scss']
})
export class CreateUserComponent {
  createUserForm: FormGroup;

  listUserGroup: { id: string, name: string }[] = [];

  constructor(
    private fb: FormBuilder,
  ) {}

  ngOnInit() {
    this.createUserForm = this.fb.group({
      user_nome: [''],
      user_cpf: [''],
      user_email: ['']
    });
    this.populateUserGroups();
  }
  private populateUserGroups(): void {
    this.listUserGroup = Object.values(UserGroup).map(group => ({
      id: group,
      name: group
    }));
  }

  submitForm(){
    const formData = this.createUserForm.value;
    if (this.createUserForm.valid) {
      // process form values here
      console.log(formData)
  } else {
      // handle form invalid case
      console.log(formData)
  }


  }
}
