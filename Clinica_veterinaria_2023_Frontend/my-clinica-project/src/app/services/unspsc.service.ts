import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class UnspscService {
  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }

                 // Método para obter detalhes do UnspscCode

  getAllUnspscCodeDetails() {
    debugger
    return this.http.get(`${this.baseUrl}/UnspscCode/ListarComDescricao`);
  }

  createUnspscCode(payload: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/UnspscCode`, payload)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: any): Observable<never> {
    console.error('API error:', error);
    return throwError(error);
  }

   // Método para verificar se um UnspscCode existe
   checkIfUnspscCodeExists(codigoSfcm: string): Observable<boolean> {
    return this.http.get<boolean>(`${this.baseUrl}/UnspscCode/Exists/${codigoSfcm}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteUnspscCode(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/UnspscCode/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  getUnspscCodeById(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/UnspscCode/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  listWithDescription(): Observable<any> {
    return this.http.get(`${this.baseUrl}/UnspscCode/ListarComDescricao`);
  }

}
