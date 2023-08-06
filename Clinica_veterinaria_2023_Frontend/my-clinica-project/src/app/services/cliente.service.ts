import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { Cliente } from '../models/cliente-model';
//FAZER environment

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private baseUrl = 'https://localhost:7131/api';  // Assuming you have apiUrl in your environment settings
  private useMock = false;  // Change this to false to use real API

  constructor(private http: HttpClient) { }

  getAllCliente() {
    return this.http.get(`${this.baseUrl}/Clientes`);
  }

  searchClientes(term: string): Observable<any> {
    debugger
        return this.http.get<Cliente[]>(`${this.baseUrl}/Cliente/search/${term}`);
  }

}
