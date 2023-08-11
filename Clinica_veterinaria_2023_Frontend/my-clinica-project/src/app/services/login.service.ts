import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/assets/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) {
  }

  private readonly baseUrl = environment.apiUrl; // Usando a propriedade correta

  login(Email: string, Password: string) {
    // Usando HTTP aqui
    return this.httpClient.post<any>(`http://104.215.126.210:5272/api/CreateToken`, { email: Email, password: Password });
  }
}
