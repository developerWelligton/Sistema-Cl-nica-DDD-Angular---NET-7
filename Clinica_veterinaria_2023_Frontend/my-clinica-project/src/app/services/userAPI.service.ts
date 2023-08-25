import { UserService } from 'src/app/core/user/user.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError,  tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TokenService } from '../core/token/token.service';

@Injectable({
  providedIn: 'root'
})
export class userServiceAPI {
  private baseUrl = `${environment.apiUrl}/api`;

  constructor(
    private http: HttpClient,
    private tokenService: TokenService
              ) { }


              getAllUsers(): Observable<any[]> {
                const headers = new HttpHeaders({
                  'Authorization': `Bearer ${this.tokenService.getToken()}`
                });
                return this.http.get<any[]>(`${this.baseUrl}/ListarUsuarios`, { headers: headers } ).pipe(
                  catchError(this.handleError<any[]>('getAllUsers', []))
                );
              }

              private handleError<T>(operation = 'operation', result?: T) {
                return (error: any): Observable<T> => {
                  console.error(error); // log to console for now
                  // You can also send the error to your logging infrastructure

                  // Let the app keep running by returning an empty result or a default one.
                  return throwError(() => new Error(`${operation} failed: ${error.message}`));
                };
              }


              createAdmin(data: any) {
                const transformedData = {
                  email: data.user_email,
                  senha: data.user_senha,
                  cpf:"XXXXX",
                  role: data.user_group,
                  nome: data.user_nome,

                };
                const headers = new HttpHeaders({
                    'Authorization': `Bearer ${this.tokenService.getToken}`
                });
                //debugger
                return this.http.post(`${this.baseUrl}/AdicionaUsuario`, transformedData, { headers: headers }).pipe(
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



            deleteUser(id: string): Observable<any> {
              const headers = new HttpHeaders({
                'Authorization': `Bearer ${this.tokenService.getToken()}`
              });

              const body = {
                id: id
              };

              return this.http.post<any>(`${this.baseUrl}/ExcluirUsuarioId`, body, { headers: headers })
                .pipe(
                  tap(data => console.log('Data received:', data)),
                  catchError(this.handleError<any>('deleteUser', {}))
                );
            }




}
