import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ItemProductBuyService {

  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }

  createItemProductsBuy(sale: any): Observable<any> {
    debugger

    // Construct the payload for the sale
    const payload = {
      dataVenda: sale.dataVenda || new Date().toISOString(),
      status: sale.status || "Pendente",
      iD_Usuario: sale.iD_Usuario || 1
    };

    return this.http.post(`${this.baseUrl}/Venda`, payload )
      .pipe(
        catchError(this.handleError<any>('createSale'))
      );
  }



  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

}
