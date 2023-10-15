import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }

 getAllProductWithUnspsc(): Observable<any> {
  debugger
    return this.http.get(`${this.baseUrl}/Produto/WithInspsc`)
      .pipe(
        catchError(this.handleError)
      );
  }

  createProduct(product: any): Observable<any> {
    // Corrigindo/Validando o formato do produto aqui
    debugger
    const payload = {
      nome: product.productName || "string",
      descricao: product.productDescription || "string",
      precoCompra: product.purchasePrice || 0,
      precoVenda: product.sellingPrice || 0,
      dataValidade: product.dataValidade || new Date().toISOString(),
      quantidade: product.quantidade || 0,
      status: product.status || "ativo",
      iD_Usuario: product.iD_Usuario || 1,
      idUnspsc: product.unspsc || 0,
      ImagemBase64: product.file || null
    };

    return this.http.post(`${this.baseUrl}/Produto`, payload)
      .pipe(
        catchError(this.handleError)
      );
  }
  deleteProductCode(idProduct: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/Produto/${idProduct}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: any): Observable<never> {
    console.error('Something went wrong:', error);
    return throwError(error);
  }




}
