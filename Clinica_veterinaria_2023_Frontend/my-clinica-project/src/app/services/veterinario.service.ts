import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
//FAZER environment

@Injectable({
  providedIn: 'root'
})
export class VeterinarioService {

  private baseUrl = 'https://localhost:7131/api';  // Assuming you have apiUrl in your environment settings

  constructor(private http: HttpClient) { }

  getAllVets() {
    return this.http.get(`${this.baseUrl}/Veterinarios`);
  }

}
