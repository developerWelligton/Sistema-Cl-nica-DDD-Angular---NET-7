import { Veterinario } from './../../../models/veterinario-model';
import { VeterinarioService } from 'src/app/services/veterinario.service';
 import { Component, OnInit } from '@angular/core';
import { ConsultService } from 'src/app/services/consult.service';
import { Consulta } from 'src/app/models/consulta.model';  // Ajuste o caminho conforme necessário
import { ConsultaResponse } from 'src/app/models/consulta-response.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subject, debounceTime, switchMap } from 'rxjs';
import { AnimalService } from 'src/app/services/animal.service';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-search-consult',
  templateUrl: './search-consult.component.html',
  styleUrls: ['./search-consult.component.scss']
})
export class SearchConsultComponent implements OnInit {
  consultas: Consulta[] = [];
  currentPage: number = 0; // Página atual, começando de 0
  pageSize: number = 10;  // Número de registros por página
  totalPages: number = 0; // Você deve calcular isso baseado na quantidade total de registros
  searchTerm$ = new Subject<string>();
  consultaForm: FormGroup;


  listAnimals = [
    { id: 1, name: 'Buddy' },
    { id: 2, name: 'Milo' },
    { id: 3, name: 'Tiger' }
    // ... add as many as you want
  ];

  listVeterinarios = [
    { id: 1, name: 'Dr. Smith' },
    { id: 2, name: 'Dr. Jane' },
    { id: 3, name: 'Dr. Doe' }
    // ... add as many as you want
  ];
  listClientes=[]
  constructor(private consultService: ConsultService,
    private formBuilder: FormBuilder,
    private animalService: AnimalService,
    private vetService: VeterinarioService,
    private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.loadPage(this.currentPage);
    this.consultaForm = this.formBuilder.group({
      cliente: [''],
      animal: [''],
      veterinario: [''],
      dataConsulta: [''],
      pageIndex: [0],
      pageSize: [10]
  }
  ),

  this.animalService.getAllAnimals().subscribe(
    (animals: any[]) => {
      this.listAnimals = animals.map(animal => ({
        id: animal.iD_Animal,
        name: animal.nome
      }));
    },
    error => {
      console.error('Error fetching animals:', error);
    });


    // Fetch list of veterinarians
    this.vetService.getAllVets().subscribe(
      (vets: any[]) => {
        this.listVeterinarios = vets.map(vet => ({
          id: vet.iD_Veterinario,
          name: vet.nome
        }));
      },
      error => {
        console.error('Error fetching veterinarians:', error);
      }
    );

      this.clienteService.getAllCliente().subscribe(
        (clientes: any[]) => {
          this.listClientes = clientes.map(cliente => ({
            id: cliente.iD_Cliente,
            name: cliente.nome


          }));
        },
        error => {
          console.error('Error fetching clientes:', error);
        }
      );
      console.log( this.listClientes)
  }

//SELECT ANIMAL
onSearchAni(term: string) {
  if (term) {
      this.animalService.searchAnimals(term).subscribe(
          (animals: any[]) => {
              this.listAnimals = animals.map(animal => ({
                  id: animal.iD_Animal,
                  name: animal.nome
              }));
          },
          error => {
              console.error('Error fetching animals:', error);
          }
      );
  }
}


//SELECT VETERINÁRIO
onSearchVet(term: string) {
  if (term) {
      this.clienteService.searchClientes(term).subscribe(
          (clientes: any[]) => {
              this.listClientes = clientes.map(cliente => ({
                  id: cliente.iD_Cliente,
                  name: cliente.nome
              }));
          },
          error => {
              console.error('Error fetching vetz:', error);
          }
      );
  }
}

//SELECT CLIENTE
onSearchCli(term: string) {
  if (term) {
      this.clienteService.searchClientes(term).subscribe(
          (clientes: any[]) => {
              this.listClientes = clientes.map(cliente => ({
                  id: cliente.iD_Cliente,
                  name: cliente.nome
              }));
          },
          error => {
              console.error('Error fetching vetz:', error);
          }
      );
  }
}

searchConsultas(): void {
  const formData = this.consultaForm.value;

  // Extraia os valores necessários do formData
  const clienteNome = formData.cliente.name || '';
  const animalNome = formData.animal.name || '';
  const veterinarioNome = formData.veterinario.name || '';
  const pageIndex = formData.pageIndex || 0;
  const pageSize = formData.pageSize || 10;

  // Use os valores extraídos para chamar o serviço e buscar as consultas
  this.consultService.listDetailedQueriesMultiple(
    pageIndex,
    pageSize,
    clienteNome,
    animalNome,
    veterinarioNome
  ).subscribe(
    (data: ConsultaResponse) => {
      this.consultas = data.consultas;  // Ajuste aqui, usando data.consultas
    },
    error => {
      console.error("Erro ao buscar consultas: ", error);
    }
  );
}

  loadPage(page: number): void {
    this.consultService.listDetailedQueries(page, this.pageSize).subscribe((data: ConsultaResponse) => {
      this.consultas = data.consultas;
      this.totalPages = Math.ceil(data.total / this.pageSize);
    });
  }

prevPage(): void {
    if (this.currentPage > 0) {
        this.currentPage--;
        this.loadPage(this.currentPage);
    }
}

nextPage(): void {
    if (this.currentPage < this.totalPages - 1) {
        this.currentPage++;
        this.loadPage(this.currentPage);
    }
}
}
