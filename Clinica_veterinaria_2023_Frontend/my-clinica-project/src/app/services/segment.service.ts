import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { Cliente } from '../models/cliente.model';
import { environment } from 'src/environments/environment';
//FAZER environment

@Injectable({
  providedIn: 'root'
})
export class SegmentService {


  private baseUrl = `${environment.apiUrl}/api`;

  constructor(private http: HttpClient) { }

  // Method to add a new segment
  addSegment(data:any): Observable<any> {
    debugger
    const url = `${this.baseUrl}/Segmento`;
    // The payload should match the expected structure of your API
    const payload = {
      codigo: String(data.codigo),
      descricao: data.description,
      iD_Usuario: 1 // Assuming this will be handled on the backend or you will add logic to include it
    };
    return this.http.post(url, payload);
  }


  getAllSegment() : Observable<any>{
    const url = `${this.baseUrl}/Segmento`;
    return this.http.get(url);
  }

}
