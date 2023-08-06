import { Veterinario } from './../../../models/veterinario-model';
import { VeterinarioService } from 'src/app/services/veterinario.service';
 import { Component, OnInit } from '@angular/core';
import { ConsultService } from 'src/app/services/consult.service';
import { Consulta } from 'src/app/models/consulta.model';  // Ajuste o caminho conforme necessário
import { ConsultaResponse } from 'src/app/models/consulta-response.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subject, debounceTime, switchMap } from 'rxjs';
import { AnimalService } from 'src/app/services/animal.service';

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
  constructor(private consultService: ConsultService,
    private formBuilder: FormBuilder,
    private animalService: AnimalService,
    private vetService: VeterinarioService) { }

  ngOnInit(): void {
    this.loadPage(this.currentPage);
    this.consultaForm = this.formBuilder.group({
      clienteNome: [''],
      animalNome: [''],
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
      this.vetService.searchVeterinarios(term).subscribe(
          (vetz: any[]) => {
              this.listVeterinarios = vetz.map(vet => ({
                  id: vet.iD_Veterinario,
                  name: vet.nome
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
    alert(JSON.stringify(formData))
    // Aqui, você pode enviar os dados do formulário para o servidor ou usá-los para filtrar consultas no frontend
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
