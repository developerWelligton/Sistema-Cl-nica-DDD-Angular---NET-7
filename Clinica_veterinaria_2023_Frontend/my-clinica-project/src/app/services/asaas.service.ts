import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';

interface AsaasPaymentLinkResponse {
  id: string;
  name: string;
  value: number;
  active: boolean;
  chargeType: string;
  url: string;
  billingType: string;
  subscriptionCycle: any;
  description: string;
  endDate: string;
  deleted: boolean;
  viewCount: number;
  maxInstallmentCount: number;
  dueDateLimitDays: number;
  notificationEnabled: boolean;
}

interface AsaasPaymentLinkPayload {
  billingType: string;
  chargeType: string;
  name: string;
  description: string;
  endDate: string;
  value: number;
  dueDateLimitDays: number;
  subscriptionCycle: any;
  maxInstallmentCount: number;
  notificationEnabled: boolean;
}
@Injectable({
  providedIn: 'root'
})
export class AsaasService {
  constructor(
    private http: HttpClient,
    private authService: AuthService,

              ) { }

              createAsaasPaymentLink(data: any): Observable<any> {
                const headers = new HttpHeaders({
                  accept: 'application/json',
                  'content-type': 'application/json',
                  access_token: '$aact_YTU5YTE0M2M2N2I4MTliNzk0YTI5N2U5MzdjNWZmNDQ6OjAwMDAwMDAwMDAwMDAzNTkxNzY6OiRhYWNoX2Y4OTVkZjkxLTQyODktNGUyOC04M2IxLTI1ZDFhMzhlYzI1Mg=='
                });

                return this.http.post(`https://sandbox.asaas.com/api/v3/paymentLinks`, data, { headers: headers })
                  .pipe(
                    catchError(this.handleError<any>('createAsaasPaymentLink'))
                  );
              }



private handleError<T>(operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {
    console.error(`Falha na operação ${operation}:`, error.message);
    console.error('Detalhes do erro:', error);
    return of(result as T);
  };
}

}
