 import { Component, OnInit } from '@angular/core';
import { ConsultService } from 'src/app/services/consult.service';
import { Consulta } from 'src/app/models/consulta.model';  // Ajuste o caminho conforme necessário
import { ConsultaResponse } from 'src/app/models/consulta-response.model';
import { FormBuilder, FormGroup } from '@angular/forms';

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

  consultaForm: FormGroup;
  listVeterinarios = [];
  constructor(private consultService: ConsultService,private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.loadPage(this.currentPage);
    this.consultaForm = this.formBuilder.group({
      clienteNome: [''],
      animalNome: [''],
      veterinarioNome: [''],
      dataConsulta: [''],
      pageIndex: [0],
      pageSize: [10]
  });
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
