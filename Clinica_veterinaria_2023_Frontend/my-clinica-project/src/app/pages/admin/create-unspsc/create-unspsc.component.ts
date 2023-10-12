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
  selector: 'app-create-user',
  templateUrl: './create-unspsc.component.html',
  styleUrls: ['./create-unspsc.component.scss']
})
export class CreateUnspscComponent {
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


}
