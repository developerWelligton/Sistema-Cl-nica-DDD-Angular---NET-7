import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { environment } from 'src/environments/environment';
//FAZER environment

@Injectable({
  providedIn: 'root'
})
export class AnimalService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAllAnimals() {
    return this.http.get(`${this.baseUrl}/Animal`);
  }

  searchAnimals(term: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Animal/search/${term}`);
}
  // Mock method for searching animals
  searchAnimalMock(term: string): Observable<any[]> {
    const mockAnimals = [
      { iD_Animal: 1, nome: 'Buddy' },
      { iD_Animal: 2, nome: 'Milo' },
      { iD_Animal: 3, nome: 'Tiger' },
      { iD_Animal: 4, nome: 'Lucky' }
      //... you can add more for the mockup
    ];

    // Mock filter based on the term
    const filteredAnimals = mockAnimals.filter(animal => animal.nome.toLowerCase().includes(term.toLowerCase()));

    // Return observable after a simulated delay
    return of(filteredAnimals).pipe(delay(500));
  }

}
