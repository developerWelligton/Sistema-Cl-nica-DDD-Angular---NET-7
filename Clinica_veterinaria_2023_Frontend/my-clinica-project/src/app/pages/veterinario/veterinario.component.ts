import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { TokenService } from 'src/app/core/token/token.service';
import { PaddingService } from 'src/app/services/Padding.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-veterinario',
  templateUrl: './veterinario.component.html',
  styleUrls: ['./veterinario.component.scss']
})
export class VeterinarioComponent {

  public containerPadding: string;
  constructor(public menuService:MenuService,
    private paddingService: PaddingService,
    private http: HttpClient,
    private tokenService: TokenService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 3;
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });

    this.getCurrentUser();
  }


  getCurrentUser() {
    debugger
    const token = this.tokenService.getToken(); // Replace this with however you are storing your token
    this.http.get(`https://localhost:7131/api/GetCurrentUser?token=${token}`)
      .subscribe(
        data => {
          console.log('Current user:', data);
        },
        error => {
          console.error('Error fetching current user:', error);
        }
      );
  }

}
