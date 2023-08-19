
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})

export class AuthService {
    private usuarioAutenticadoPortal: boolean = false;
    private token: any;
    private user: any;
    private role: any;

    constructor(private httpClient: HttpClient) {
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
}
