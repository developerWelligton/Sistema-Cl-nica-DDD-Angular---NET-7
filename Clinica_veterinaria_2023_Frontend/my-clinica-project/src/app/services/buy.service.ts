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
export class BuyService {

  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }


  createBuy(buy: any): Observable<any> {
    // Assuming `stock` contains `total`, `dataCompra`, `status`, and `idFornecedor`
    // Corrigindo/Validando o formato do produto aqui
    debugger
    const payload = {
      total: 0, // assuming stock has a 'total' property
      dataCompra: "2023-11-10T03:58:11.872Z", // assuming stock has a 'dataCompra' property
      status: "Encomendado", // assuming stock has a 'status' property
      iD_Usuario: 1, // This is hardcoded to 1, as in your example
      idFornecedor: Number(buy) // assuming stock has a 'idFornecedor' property
    };

    return this.http.post(`${this.baseUrl}/Compra`, payload)
      .pipe(
        catchError(this.handleError)
      );
  }


  getAllStock(): Observable<any>  {
    return this.http.get(`${this.baseUrl}/Estoque`)
    .pipe(
      catchError(this.handleError)
    );
  }



  private handleError(error: any): Observable<never> {
    console.error('Something went wrong:', error);
    return throwError(error);
  }

}
