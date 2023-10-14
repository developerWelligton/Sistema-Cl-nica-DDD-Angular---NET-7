import { userServiceAPI } from 'src/app/services/userAPI.service';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-product',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.scss']
})
export class UserProductComponent {

  @Input() productList: any[] = [];
  @Output() userDeleted: EventEmitter<void> = new EventEmitter<void>();

  constructor(
    private adminService: AdminService,
    private router:Router) { }

  editUser(user: any) {
    // Implemente a lógica para editar o usuário aqui
    console.log('Editar usuário:', user);
  }

  viewUser(user: any) {
    // Implemente a lógica para visualizar o usuário aqui
    console.log('Visualizar usuário:', user);
  }


}
