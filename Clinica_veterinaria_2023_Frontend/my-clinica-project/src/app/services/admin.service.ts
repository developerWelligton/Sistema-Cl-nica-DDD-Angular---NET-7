import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';
//FAZER environment


@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }

              createAdmin(data: any) {
                const transformedData = {
                    nome: data.user_nome,
                    email: data.user_email,
                    senha: data.user_senha,
                    role: data.user_group
                };

                const headers = new HttpHeaders({
                    'Authorization': `Bearer ${this.authService.getToken}`
                });
debugger
                return this.http.post(`${this.baseUrl}/UsuarioClinica`, transformedData, { headers: headers }).pipe(
                    tap(() => {
                        console.log('Success');
                    }),
                    catchError(error => {
                        if (error.status === 0) {
                            console.error('API Connection Error:', error);
                        } else if (error.status >= 500) {
                            console.error('Backend Bug/Error:', error);
                        } else {
                            console.error('General Error:', error);
                        }
                        return throwError(error);
                    })
                );
            }

}
