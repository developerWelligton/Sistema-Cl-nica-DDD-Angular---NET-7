import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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

}
