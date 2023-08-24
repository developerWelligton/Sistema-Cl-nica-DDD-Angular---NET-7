import { userServiceAPI } from 'src/app/services/userAPI.service';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-table-consult-veterinario',
  templateUrl: './table-consult.component.html',
  styleUrls: ['./table-consult.component.scss']
})
export class TableConsultComponent {

  @Input() consultList: any[] = [];
 // Lista Mockada
 mockConsultas = [
  {
    id: 1,
    cliente: 'João',
    animal: 'Fido',
    data: '2023-08-24',
    horaInicio: '10:00',
    horaFim: '11:00',
    status: 'Pendente'
  },
  {
    id: 2,
    cliente: 'Maria',
    animal: 'Buddy',
    data: '2023-08-25',
    horaInicio: '14:00',
    horaFim: '15:00',
    status: 'Concluído'
  },
  // ... outros registros
];
  constructor(
    private adminService: AdminService,
    private userServiceAPI: userServiceAPI,
    private router:Router) { }





}
