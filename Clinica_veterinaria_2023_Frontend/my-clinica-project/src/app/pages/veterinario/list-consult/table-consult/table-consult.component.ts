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

  constructor(
    private adminService: AdminService,
    private userServiceAPI: userServiceAPI,
    private router:Router) { }


}
