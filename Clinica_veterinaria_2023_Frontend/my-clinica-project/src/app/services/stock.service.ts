import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';
import { Product } from '../pages/admin/panel-pdv/panel-pdv.component';

@Injectable({
  providedIn: 'root'
})
export class StockService {
  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }


  createStock(stock: any): Observable<any> {
    // Corrigindo/Validando o formato do produto aqui
    debugger
    const payload = {
      sala: stock.sala || "string",
      prateleira: stock.prateleira|| "string",
      quantidade: 0,
      iD_Usuario: 1
    };

    return this.http.post(`${this.baseUrl}/Estoque`, payload)
      .pipe(
        catchError(this.handleError)
      );
  }


  private handleError(error: any): Observable<never> {
    console.error('Something went wrong:', error);
    return throwError(error);
  }

}
