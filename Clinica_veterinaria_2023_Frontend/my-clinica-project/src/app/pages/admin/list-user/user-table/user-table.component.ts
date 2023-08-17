import { Component, Input } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.scss']
})
export class UserTableComponent {
  @Input() usersList: any[] = [];

  constructor(private adminService: AdminService) { }

  editUser(user: any) {
    // Implemente a lógica para editar o usuário aqui
    console.log('Editar usuário:', user);
  }

  viewUser(user: any) {
    // Implemente a lógica para visualizar o usuário aqui
    console.log('Visualizar usuário:', user);
  }

  deleteUser(id: any) {
    const confirmation = confirm('Você tem certeza que deseja excluir este usuário?');
    if (confirmation) {
      this.adminService.deleteUser(id).subscribe(
        () => {
          // Após a exclusão bem-sucedida, você pode remover o usuário da lista (se desejar)

          console.log('Usuário excluído:', id);
        },
        error => {
          console.error('Erro ao excluir o usuário:', error);
        }
      );
    }
  }
}
