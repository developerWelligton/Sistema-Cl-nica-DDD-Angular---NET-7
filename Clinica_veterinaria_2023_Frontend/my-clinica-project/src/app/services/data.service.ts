import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  getSegmentos(): Observable<any[]> {
    // Simulando a obtenção de segmentos de uma API ou outra fonte de dados
    const segmentos = [
      { id: 1, nome: 'Segmento 1' },
      { id: 2, nome: 'Segmento 2' },
      { id: 3, nome: 'Segmento 3' },
    ];
    return of(segmentos);
  }

  getFamilias(): Observable<any[]> {
    // Simulando a obtenção de famílias de uma API ou outra fonte de dados
    const familias = [
      { id: 1, nome: 'Família 1' },
      { id: 2, nome: 'Família 2' },
      { id: 3, nome: 'Família 3' },
    ];
    return of(familias);
  }

  getClasses(): Observable<any[]> {
    // Simulando a obtenção de classes de uma API ou outra fonte de dados
    const classes = [
      { id: 1, nome: 'Classe 1' },
      { id: 2, nome: 'Classe 2' },
      { id: 3, nome: 'Classe 3' },
    ];
    return of(classes);
  }

  getMercadorias(): Observable<any[]> {
    // Simulando a obtenção de mercadorias de uma API ou outra fonte de dados
    const mercadorias = [
      { id: 1, nome: 'Mercadoria 1' },
      { id: 2, nome: 'Mercadoria 2' },
      { id: 3, nome: 'Mercadoria 3' },
    ];
    return of(mercadorias);
  }
}
