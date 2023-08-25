import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { TokenService } from 'src/app/core/token/token.service';
import { UserService } from 'src/app/core/user/user.service';
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
    private tokenService: TokenService,
    private userService: UserService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 3;
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });


    //teste
      // Usar o método getCurrentUser() para obter o usuário atual
      const currentUser = this.userService.getCurrentUser();

      if (currentUser) {
        console.log('User ID:', currentUser)
      } else {
        console.log('User not logged in');
      }

  }



}
