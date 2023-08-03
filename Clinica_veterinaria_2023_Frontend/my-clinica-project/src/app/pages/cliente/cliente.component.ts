import { Component } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent {
  constructor(public menuService:MenuService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 4;
  }
}
