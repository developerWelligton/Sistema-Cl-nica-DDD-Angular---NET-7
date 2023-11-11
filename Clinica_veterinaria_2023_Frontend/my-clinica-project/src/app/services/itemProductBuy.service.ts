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

  createItemProductsBuy(ListProductsBuy: any[]): Observable<any> {
  debugger

  // Assuming that ListProductsBuy is an array of products to be bought,
  // and each product item in the list has the properties dataEntrada, quantidadeTotal, lote, idCompra, and idProduto
  // Here we create the payload array by mapping each product to the expected structure
  const payload = ListProductsBuy.map(product => ({
    dataEntrada: product.dataEntrada || new Date().toISOString(), // Use the provided dataEntrada or set the current timestamp
    quantidadeTotal: product.quantidadeTotal, // Use the provided quantidadeTotal
    lote: product.lote || "", // Use the provided lote
    idCompra: product.idCompra, // Use the provided idCompra
    idProduto: product.idProduto // Use the provided idProduto
  }));

  // The API endpoint should be for creating a purchase item, not a sale
  // Change the URL to match your API's endpoint for creating purchase items
  return this.http.post(`${this.baseUrl}/ItemProdutoCompra/CriarProdutosVenda`, payload)
    .pipe(
      catchError(this.handleError<any>('createItemProductsBuy'))
    );
}



  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

}
