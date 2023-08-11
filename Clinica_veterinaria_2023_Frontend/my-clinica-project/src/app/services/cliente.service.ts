import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { Cliente } from '../models/cliente-model';
import { environment } from 'src/environments/environment';
//FAZER environment

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private baseUrl = environment.apiUrl;
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
