import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) {
  }

  private readonly baseUrl = environment.apiUrl; // Usando a propriedade correta

  login(Email: string, Password: string) {
    debugger
    return this.httpClient.post<any>(`${this.baseUrl}/api/CreateToken`, { email: Email, password: Password });
  }
}
