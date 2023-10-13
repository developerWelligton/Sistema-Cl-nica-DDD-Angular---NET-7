import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';
import { Unspsc } from '../models/unspsc.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private baseUrl = `${environment.apiUrl}/api`;

  constructor(private http: HttpClient) { }

  getSegmentos(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Segmento`).pipe(
      catchError(this.handleError('getSegmentos', []))
    );
  }

  getFamilias(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Familia`).pipe(
      catchError(this.handleError('getFamilias', []))
    );
  }

  getClasses(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Classe`).pipe(
      catchError(this.handleError('getClasses', []))
    );
  }

  getMercadorias(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Mercadoria`).pipe(
      catchError(this.handleError('getMercadorias', []))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); // log to console instead
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }


  private unspscData: Unspsc[] = [
    {
      idUnspsc: 1,
      codigoSfcm: "50515457",
      iD_Usuario: 1,
      usuario: null,
      idSegmento: 1,
      segmento: null,
      idFamilia: 1,
      familia: null,
      idClasse: 1,
      classe: null,
      idMercadoria: 1,
      mercadoria: null
    },
    {
      idUnspsc: 2,
      codigoSfcm: "50515458",
      iD_Usuario: 1,
      usuario: null,
      idSegmento: 1,
      segmento: null,
      idFamilia: 1,
      familia: null,
      idClasse: 1,
      classe: null,
      idMercadoria: 2,
      mercadoria: null
    },
    // ... outros dados
  ];
  getUnspsc(): Observable<Unspsc[]> {
    return of(this.unspscData);
  }

}
