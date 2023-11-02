import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';

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
}
