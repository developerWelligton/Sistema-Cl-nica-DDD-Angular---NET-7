import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthService } from '../core/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AsaasService {

  private baseUrl = environment.apiUrl; // assuming your environment has apiUrl pointing to your backend

  constructor(private http: HttpClient, private authService: AuthService) { }

  createAsaasPaymentLink(data: any): Observable<any> {

    // Call your own backend API instead of Asaas directly
    return this.http.post(`${this.baseUrl}/api/CreatePaymentLink`, data)
      .pipe(
        catchError(this.handleError<any>('createAsaasPaymentLink'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(`Failed operation ${operation}:`, error.message);
      console.error('Error details:', error);
      return of(result as T);
    };
  }


}
