import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ItemProductSaleService {
  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }

  sendProductList(productList: any[]): Observable<any> {
    debugger
    const endpoint = `${this.baseUrl}/ItemProdutoVenda`;

    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    const payloads = productList.map(product => ({
        idProduto: product.idProduto || 0,
        idVenda: product.idVenda || 0,
        totalProdutosVendas: product.totalProdutosVendas || 0,
        observacao: product.observacao || "string",
        quantidade: product.quantidade || 0
    }));

    return this.http.post(endpoint, payloads, { headers: headers }) // Passando headers explicitamente
      .pipe(
        catchError(this.handleError)
      );
  }


  getAllProductListByBuy(idCompra: any): Observable<any> {
    const endpoint = `${this.baseUrl}/ItemProdutoCompra/produtos-por-compra?idCompra=${idCompra}`;

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    return this.http.get(endpoint, { headers })
      .pipe(
        catchError(this.handleError)
      );
  }


  private handleError(error: any): Observable<never> {
    console.error('Something went wrong:', error);
    return throwError(error);
  }
}
