
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { tap, Subject } from 'rxjs';
import { TokenService } from '../token/token.service';
import { User } from './user';
import jwt_decode from 'jwt-decode';
import { userServiceAPI } from 'src/app/services/userAPI.service';
import { UserCorrent } from './userCorrent';


const KEY = 'authToken';

interface DecodedToken {
  [key: string]: any;  // Allowing any property of any type
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role': string;
  // Add other known properties here
}

@Injectable({
    providedIn: 'root'
})

export class UserService {

  private baseUrl = `${environment.apiUrl}/api`;

  private userSubject = new Subject<User>();
  private currentUser: User;  // Assuming 'User' has a 'role' property
  private currentUserConsult: UserCorrent;
  constructor(private tokenService: TokenService, private http: HttpClient){
    this.tokenService.hasToken() && this.decodeAndNotify();
  }

  setToken(token:string){
    debugger
    this.tokenService.setToken(token);
    this.decodeAndNotify();
  }

  getUser(){
    return this.userSubject.asObservable();
  }

  private decodeAndNotify() {
    const token = this.tokenService.getToken();
    const decodedToken: any = jwt_decode(token); // Explicitly type it as 'any' for now


    this.getCurrentUserConsult(token)


    // Extract the role
    const userRole = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

    // Assign the role directly to the decodedToken object
    decodedToken.role = userRole;

    this.currentUser = userRole;
    const user = decodedToken as User; // Cast to User type
    console.log("decoded user:", user);
    console.log(" this.currentUser:",  this.currentUser);
    this.userSubject.next(user);
  }

  getCurrentUser(): User {
    return this.currentUser;
  }


  logout(){
    this.tokenService.removeToken();
    this.userSubject.next(null);
  }

  isLogged(){
    return this.tokenService.hasToken();
  }


   // Método para obter dados do usuário atual
   getCurrentUserConsult(token: string) {
    debugger
    this.http.get(`${this.baseUrl}/GetCurrentUser?token=${token}`)
      .subscribe(
        (data: any) => {
          debugger
          this.currentUserConsult = new UserCorrent(data.userId, data.iD_Usuario);
        },
        error => {
          console.error('Error fetching current user:', error);
        }
      );
  }


   // Método Getter para acessar currentUserConsult de qualquer parte da aplicação
   public getUserId(): number {
    return this.currentUserConsult ? this.currentUserConsult.iD_Usuario : null;
  }


}
