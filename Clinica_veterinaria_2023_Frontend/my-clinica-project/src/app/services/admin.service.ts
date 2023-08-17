import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, delay, of, tap, throwError } from 'rxjs';
import { Veterinario } from '../models/veterinario-model';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private authService: AuthService
              ) { }

              getAllUsers(): Observable<any[]> {
                const headers = new HttpHeaders({
                    'Authorization': `Bearer ${this.authService.getToken}`
                });

                return this.http.get<any[]>(`${this.baseUrl}/UsuariosClinica`, { headers: headers }).pipe(
                  tap(() => {
                      console.log('Fetched users successfully');
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
                //debugger
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



            deleteUser(id: number): Observable<any> {

              const headers = new HttpHeaders({
                'Authorization': `Bearer ${this.authService.getToken}`
              });
              debugger
              return this.http.delete(`${this.baseUrl}/UsuarioSistema/${id}`).pipe(
                tap(() => {
                  console.log('User deleted successfully');
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
