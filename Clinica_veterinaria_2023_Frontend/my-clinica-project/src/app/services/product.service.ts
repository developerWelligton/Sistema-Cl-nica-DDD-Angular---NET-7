import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';
import { Product } from '../pages/admin/panel-pdv/panel-pdv.component';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl = `${environment.apiUrl}/api`;

  private productUpdateSubject = new BehaviorSubject<void>(null);

  // Observable to which components can subscribe
  productUpdate$ = this.productUpdateSubject.asObservable();
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
      quantidade: 0,
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

  //buscar produto por id
  getProductByCode(productCode: any): Observable<any> {
    return this.http.get(`${this.baseUrl}/Produto/${productCode}`)
        .pipe(
            catchError(this.handleError)
        );
  }


    removeProductFromInventory(productsPaidOut: any) {
    // Aqui iria a lógica para comunicar-se com o backend e remover o produto do inventário
    console.log(`Produto com ID ${JSON.stringify(productsPaidOut)} foi removido do inventário.`);
    // Implementação mockada para simulação:
    return true;
  }

  createOrUpdateStockItem(stockItem: any): Observable<any> {
    // Corrigindo/Validando o formato do item de estoque aqui
    debugger
    const payload = {
      idProduto: stockItem.products || 0,
      iD_Usuario: 1,
      idEstoque: stockItem.idEstoque || 0,
      dataEntrada: stockItem.dataEntrada || new Date().toISOString(),
      dataSaida: stockItem.dataSaida || new Date().toISOString(),
      status: stockItem.status || "Disponível"
    };

    return this.http.post(`${this.baseUrl}/ItemProdutoEstoque`, payload)
      .pipe(
        catchError(this.handleError)
      );
  }

 // Method to call when products need to be updated
 notifyProductUpdate() {
  this.productUpdateSubject.next();
}

}
