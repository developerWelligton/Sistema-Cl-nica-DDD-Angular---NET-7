import { Component, OnInit } from '@angular/core'; // Importando OnInit
import { FormBuilder, FormGroup } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { PaddingService } from 'src/app/services/Padding.service';
import { AnimalService } from 'src/app/services/animal.service';
import { ClienteService } from 'src/app/services/cliente.service';
import Swal from 'sweetalert2';



@Component({
  selector: 'app-create-animal',
  templateUrl: './create-animal.component.html',
  styleUrls: ['./create-animal.component.scss']
})
export class CreateAnimalComponent implements OnInit {  // Implemente OnInit

  createAnimalForm: FormGroup;
  clientes: Cliente[] = [];
  public containerPadding: string;

  constructor(
    private fb: FormBuilder,
    private paddingService: PaddingService,
    private clienteService: ClienteService,
    private animalService: AnimalService
  ) {}

  ngOnInit() {
    // Padding sidebar
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });

    this.loadClientes();

    this.createAnimalForm = this.fb.group({
      nome: [''],
      cliente: [''],
    });
  }

  loadClientes(): void {
    this.clienteService.getAllCliente().subscribe(
      (data: Cliente[]) => {
        console.log('Data received:', data);
        this.clientes = data;  // Atualiza a lista de clientes
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  submitForm() {
    const formData = this.createAnimalForm.value;
    const payload = {
      nome: formData.nome,
      iD_Cliente: formData.cliente.iD_Cliente
    };

    Swal.fire({
      title: 'Tem certeza?',
      text: "Você quer criar este animal?",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sim, criar!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.animalService.createAnimalByCliente(payload).subscribe(
          response => {
            Swal.fire(
              'Criado!',
              'O animal foi criado com sucesso.',
              'success'
            );
          },
          error => {
            Swal.fire(
              'Erro!',
              'Houve um erro ao criar o animal.',
              'error'
            );
          }
        );
      }
    });
  }
}
