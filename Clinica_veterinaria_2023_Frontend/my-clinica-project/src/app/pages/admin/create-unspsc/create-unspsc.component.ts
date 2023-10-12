import { UserService } from '../../../core/user/user.service';
// ... previous imports ...

import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';   // Replace with the actual path to your service
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { Subscription } from 'rxjs';
import { Cliente } from 'src/app/models/cliente.model';
import { ClienteService } from 'src/app/services/cliente.service';
import Swal from 'sweetalert2';
import { AnimalService } from 'src/app/services/animal.service';
import { DataService } from 'src/app/services/data.service';
import { Segmento } from 'src/app/models/segmento.model';
import { Familia } from 'src/app/models/familia.model';
import { Classe } from 'src/app/models/classe.model';
import { Mercadoria } from 'src/app/models/mercadoria.model';


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

  createUnspscForm: FormGroup;

  //fazer os tipos
  segmentos: Segmento[] = [];
  familias: Familia[] = [];
  classes: Classe[] = [];
  mercadorias: Mercadoria[] = [];


  public containerPadding: string;

  constructor(
    private fb: FormBuilder,
    private paddingService: PaddingService,
    private dataService: DataService
  ) {}

  ngOnInit() {
    // Padding sidebar
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });

    this.loadSegmentos();
    this.loadFamilias();
    this.loadClasses();
    this.loadMercadorias();

    this.createUnspscForm = this.fb.group({
      segmento: [''],
      familia: [''],
      classe: [''],
      mercadoria: [''],
    });
  }




  loadSegmentos(): void {
    this.dataService.getSegmentos().subscribe(
      (data: Segmento[]) => {
        console.log('Data received:', data);
        this.segmentos = data;  // Atualiza a lista de clientes
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  loadFamilias(): void {
    this.dataService.getFamilias().subscribe(
      (data: Familia[]) => {
        console.log('Data received:', data);
        this.familias = data;  // Atualiza a lista de clientes
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  loadClasses(): void {
    this.dataService.getClasses().subscribe(
      (data: Classe[]) => {
        console.log('Data received:', data);
        this.classes = data;  // Atualiza a lista de clientes
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  loadMercadorias(): void {
    this.dataService.getMercadorias().subscribe(
      (data: Mercadoria[]) => {
        console.log('Data received:', data);
        this.mercadorias = data;  // Atualiza a lista de clientes
      },
      error => {
        console.error('Error:', error);
      }
    );
  }
  submitForm() {
    const formData = this.createUnspscForm.value;
    console.log(formData)
  }

}