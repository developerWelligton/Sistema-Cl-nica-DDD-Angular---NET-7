
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs';



const KEY = 'authToken';

@Injectable({
    providedIn: 'root'
})

export class TokenService {

 hasToken(){
    return !!this.getToken()
 }

 setToken(token){
  window.localStorage.setItem(KEY,token)
 }

 getToken(){
    return window.localStorage.getItem(KEY)
 }

 removeToken(){
  window.localStorage.removeItem(KEY);
 }

}
