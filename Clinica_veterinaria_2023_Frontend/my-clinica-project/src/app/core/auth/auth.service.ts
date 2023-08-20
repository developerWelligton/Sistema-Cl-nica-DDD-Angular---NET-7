import { TokenService } from './../token/token.service';

import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs';
import { UserService } from '../user/user.service';

@Injectable({
    providedIn: 'root'
})

export class AuthService {

    private readonly baseUrl = environment.apiUrl; // Usando a propriedade correta

    private usuarioAutenticadoPortal: boolean = false;
    private token: any;
    private user: any;
    private role: any;

    constructor(
      private httpClient: HttpClient,
      private tokenService:TokenService,
      private userService: UserService
      ) {
    }

    checkToken() {
        return Promise.resolve(true);
    }

    UsuarioAutenticado(status: boolean) {
        localStorage.setItem('usuarioAutenticadoPortal', JSON.stringify(status));
        this.usuarioAutenticadoPortal = status;
    }

    UsuarioEstaAutenticado(): Promise<boolean> {
        this.usuarioAutenticadoPortal = localStorage.getItem('usuarioAutenticadoPortal') == 'true';
        return Promise.resolve(this.usuarioAutenticadoPortal);
    }
//SALVAR TOKEN
    setToken(token: string) {
        localStorage.setItem('token', token);
        this.token = token;
    }

    get getToken() {
        this.token = localStorage.getItem('token');
        return this.token;
    }
     getRole() {
      this.role = localStorage.getItem('userRole');
      return this.role;
    }

    limparToken() {
        this.token = null;
        this.user = null;
        this.role= null;

    }

    limparDadosUsuario() {
        this.UsuarioAutenticado(false);
        this.limparToken();
        localStorage.clear();
        sessionStorage.clear();
    }

    excluiToken() {
      localStorage.removeItem(this.token);
    }


    logout() {
      this.excluiToken() ;
      this.limparDadosUsuario();
      this.limparToken();
    }




    authenticate(Email: string, Password: string) {
      debugger
      return this.httpClient.post<any>(`${this.baseUrl}/api/CreateToken`, { email: Email, password: Password },
      { observe: 'response' })
      .pipe(
        tap(res => {
          console.log(res);
          const authToken = res.body;
          //console.log(authToken);

          debugger
          this.userService.setToken(authToken)
          //this.setToken(authToken)
          // You can store the token or perform additional operations here.
        })
      );
    }

}
