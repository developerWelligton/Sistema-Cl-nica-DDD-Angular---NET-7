import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { Cliente } from '../models/cliente.model';
import { environment } from 'src/environments/environment';
//FAZER environment

@Injectable({
  providedIn: 'root'
})
export class SaleServicePaymentService {

  private baseUrl = `${environment.apiUrl}/api`;

  constructor(private http: HttpClient) { }

   // Método para enviar pagamento
   sendPayment(paymentData: any): Observable<any> {
    debugger
      return this.http.post(`${this.baseUrl}/VendaServicoPagamento`, paymentData);
  }

   // Método para recuperar todos os pagamentos
  getAllPayments(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Pagamentos`);
  }
}
