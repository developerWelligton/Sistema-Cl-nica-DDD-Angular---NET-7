import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/assets/environment';
//FAZER environment


@Injectable({
  providedIn: 'root'
})
export class VeterinarioService {
  private baseUrl = environment.apiUrl;
  //private baseUrl = 'https://localhost:7131/api';  // Assuming you have apiUrl in your environment settings
  private useMock = false;  // Change this to false to use real API

  constructor(private http: HttpClient) { }

  private VETERINARIOS_MOCK: Veterinario[] = [
    { ID_Veterinario: 1, nome: 'Dr. Smith', especializacao: 'Cirurgia', email: 'drsmith@example.com', telefone: '+1234567890', ID_Usuario: 10 },
    { ID_Veterinario: 2, nome: 'Dr. Alice', especializacao: 'Ortopedia', email: 'dralice@example.com', telefone: '+1234567891', ID_Usuario: 11 },
    // ... Adicione outros veterinários mock conforme necessário
  ];

  getAllVets() {
    return this.http.get(`${this.baseUrl}/Veterinarios`);
  }

  searchVeterinarios(term: string): Observable<Veterinario[]> {
    debugger
    if (this.useMock) {
        const filteredVets = this.VETERINARIOS_MOCK.filter(v => v.nome.toLowerCase().includes(term.toLowerCase()));
        return of(filteredVets).pipe(delay(500));
    } else {
        return this.http.get<Veterinario[]>(`${this.baseUrl}/Veterinario/search/${term}`);
    }
}

}
