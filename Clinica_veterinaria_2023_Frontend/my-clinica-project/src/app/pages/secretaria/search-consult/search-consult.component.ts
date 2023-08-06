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
  listVeterinarios = [];

  listAnimals = [
    { id: 1, name: 'Buddy' },
    { id: 2, name: 'Milo' },
    { id: 3, name: 'Tiger' }
    // ... add as many as you want
  ];

  vetz = [
    { id: 1, name: 'Buddy' },
    { id: 2, name: 'Milo' },
    { id: 3, name: 'Tiger' }
    // ... add as many as you want
  ];
  constructor(private consultService: ConsultService,
    private formBuilder: FormBuilder,
    private veterinarioService: VeterinarioService,
    private animalService: AnimalService,) { }

  ngOnInit(): void {
    this.loadPage(this.currentPage);
    this.consultaForm = this.formBuilder.group({
      clienteNome: [''],
      animalNome: [''],
      veterinarioNome: [''],
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

    this.veterinarioService.getAllVets().subscribe(
      (vers: Veterinario[]) => {
        this.vetz = vers.map(vet => ({
          id: vet.ID_Veterinario,
          name: vet.nome
        }));
      },
      error => {
        console.error('Error fetching veterinarians:', error);
      }
    );

  this.searchTerm$.pipe(
    debounceTime(300),  // aguarda 300ms após a última mudança
    switchMap(term => this.veterinarioService.searchVeterinarios(term))
  ).subscribe(veterinarios => {
    this.listVeterinarios = veterinarios;
  }, error => {
    // handle error, for example:
    console.error('Error fetching veterinarians', error);
  });
  }

  onSearch(term: string) {
    if (term) {
        this.veterinarioService.searchVeterinarios(term).subscribe(veterinarios => {
          this.listVeterinarios = veterinarios;
        });
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
