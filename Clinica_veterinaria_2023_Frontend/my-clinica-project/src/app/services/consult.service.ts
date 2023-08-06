  import { HttpClient } from '@angular/common/http';
  import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Consulta } from '../models/consulta.model';
import { ConsultaResponse } from '../models/consulta-response.model';
  //FAZER environment

  @Injectable({
    providedIn: 'root'
  })
  export class ConsultService {

    private baseUrl = 'https://localhost:7131/api';  // Assuming you have apiUrl in your environment settings

    constructor(private http: HttpClient) { }

    createConsulta(data: any) {
      return this.http.post(`${this.baseUrl}/Consulta`, data);
    }


      // List Consultas
     // Dentro do seu ConsultService no Angular
     listDetailedQueries(pageIndex: number = 0, pageSize: number = 10): Observable<ConsultaResponse> {
      return this.http.get<ConsultaResponse>(`${this.baseUrl}/Consultas/Detalhadas?pageIndex=${pageIndex}&pageSize=${pageSize}`);
    }
  }
