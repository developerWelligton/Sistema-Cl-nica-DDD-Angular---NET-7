import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/assets/environment';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor() {
   }

  menuSelecionado:number
}
