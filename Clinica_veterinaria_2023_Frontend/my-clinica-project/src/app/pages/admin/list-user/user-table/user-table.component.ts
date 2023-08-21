import { userServiceAPI } from 'src/app/services/userAPI.service';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.scss']
})
export class UserTableComponent {

  @Input() usersList: any[] = [];
  @Output() userDeleted: EventEmitter<void> = new EventEmitter<void>();

  constructor(
    private adminService: AdminService,
    private userServiceAPI: userServiceAPI,
    private router:Router) { }

  editUser(user: any) {
    // Implemente a lógica para editar o usuário aqui
    console.log('Editar usuário:', user);
  }

  viewUser(user: any) {
    // Implemente a lógica para visualizar o usuário aqui
    console.log('Visualizar usuário:', user);
  }

  deleteUser(id: any) {
    Swal.fire({
      title: 'Confirmação',
      text: 'Você tem certeza que deseja excluir este usuário?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, excluir!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.userServiceAPI.deleteUser(id).subscribe({
          next: () => {
            console.log('Usuário excluído:', id);
            Swal.fire('Excluído!', 'O usuário foi excluído.', 'success');
            this.router.navigate(['/admin/list-user']);

            this.userDeleted.emit();
          },
          error: (error) => {
            console.error('Erro ao excluir o usuário:', error);
            Swal.fire('Erro!', 'Houve um erro ao excluir o usuário.', 'error');
          }
        });
      }
    });
  }
}
