import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';
import { Product } from '../pages/admin/panel-pdv/panel-pdv.component';
import { Provider } from '../pages/admin/unspsc-table copy/provider-table/provider-table.component';

@Injectable({
  providedIn: 'root'
})
export class ProviderService {

  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }


  createProvider(provider: any): Observable<any> {
  // Assuming the argument 'provider' contains the form data
  const payload = {
    nome: provider.nome,
    email: provider.email,
    endereco: provider.endereco,
    cnpj: provider.cnpj,
    iD_Usuario: provider.iD_Usuario // This is assuming iD_Usuario comes from the form
  };

  return this.http.post(`${this.baseUrl}/Fornecedor`, payload)
    .pipe(
      catchError(this.handleError)
    );
}

getAllProviders(): Observable<Provider[]> {
  return this.http.get<Provider[]>(`${this.baseUrl}/Fornecedores`);
}

deleteProvider(providerId: number): Observable<any> {
  return this.http.delete(`${this.baseUrl}/provider/${providerId}`);
}


  private handleError(error: any): Observable<never> {
    console.error('Something went wrong:', error);
    return throwError(error);
  }

}
