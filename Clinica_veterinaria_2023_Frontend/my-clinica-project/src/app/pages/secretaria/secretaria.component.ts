import { Component } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-secretaria',
  templateUrl: './secretaria.component.html',
  styleUrls: ['./secretaria.component.scss']
})
export class SecretariaComponent {
  constructor(public menuService:MenuService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 2;
  }
}
