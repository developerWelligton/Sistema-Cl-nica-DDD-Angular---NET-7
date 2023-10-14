import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { environment } from 'src/environments/environment';
//FAZER environment

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private baseUrl = `${environment.apiUrl}/api`;
  constructor(private http: HttpClient) { }

  upload(file: File) {

    const formData = new FormData();
    formData.append('imageFile', file);

    return this.http.post('/photos/upload', formData);
}


}
