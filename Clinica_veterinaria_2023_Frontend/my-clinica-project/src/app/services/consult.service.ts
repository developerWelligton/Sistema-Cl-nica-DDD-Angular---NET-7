  import { HttpClient, HttpParams } from '@angular/common/http';
  import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Consulta } from '../models/consulta.model';
import { ConsultaResponse } from '../models/consulta-response.model';
import { environment } from 'src/assets/environment';
  //FAZER environment

  @Injectable({
    providedIn: 'root'
  })
  export class ConsultService {

    private baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    createConsulta(data: any) {
      return this.http.post(`${this.baseUrl}/Consulta`, data);
    }

      // List Consultas
     // Dentro do seu ConsultService no Angular
     listDetailedQueries(pageIndex: number = 0, pageSize: number = 10): Observable<ConsultaResponse> {
      return this.http.get<ConsultaResponse>(`${this.baseUrl}/Consultas/Detalhadas?pageIndex=${pageIndex}&pageSize=${pageSize}`);
    }

    listDetailedQueriesMultiple(
      pageIndex: number = 0,
      pageSize: number = 10,
      clienteNome: string = '',
      animalNome: string = '',
      veterinarioNome: string = '',
      dataConsulta: string =''
    ): Observable<ConsultaResponse> {

      // Usando HttpParams para construir os parâmetros do URL
      let params = new HttpParams()
        .set('pageIndex', pageIndex.toString())
        .set('pageSize', pageSize.toString())
        .set('clienteNome', clienteNome)
        .set('animalNome', animalNome)
        .set('veterinarioNome', veterinarioNome)
        .set('dataConsulta', dataConsulta);

      return this.http.get<ConsultaResponse>(`${this.baseUrl}/Consultas/Detalhadas`, { params: params });
    }


  }
