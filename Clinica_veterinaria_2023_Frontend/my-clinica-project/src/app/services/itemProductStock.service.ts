import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';


export interface StockItem {
  idProduto: number;
  iD_Usuario: number;
  idEstoque: number;
  dataEntrada: string;
  dataSaida: string;
  status: string;
}

@Injectable({
  providedIn: 'root'
})
export class ItemProductStockService {

  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }

  getAllProductListByStock(idEstoque: number): Observable<any> {
    const endpoint = `${this.baseUrl}/ItemProdutoEstoque/produtos-por-estoque?idEstoque=${idEstoque}`;

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

    createOrUpdateStockItem(stockItem: StockItem): Observable<StockItem> {
      const endpoint = `${this.baseUrl}/ItemProdutoEstoque`;
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        // Include authorization header if needed
        // 'Authorization': `Bearer ${this.authService.getToken()}`
      });

      return this.http.post<StockItem>(endpoint, stockItem, { headers })
        .pipe(
          catchError(this.handleError)
        );
    }


      GetEstoqueId(produto: any): Observable<any> {
      const endpoint = `${this.baseUrl}/ItemProdutoEstoque/estoques-por-produto?idProduto=${produto }`;

      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
      });

      return this.http.get(endpoint, { headers })
        .pipe(
          catchError(this.handleError)
        );
    }

    getEstoqueByProductId(idProduto: number): Observable<StockItem[]> {
      const endpoint = `${this.baseUrl}/ItemProdutoEstoque/itens-por-produto?idProduto=${idProduto}`;
      return this.http.get<StockItem[]>(endpoint)
        .pipe(
          catchError(this.handleError)
        );
    }
}
