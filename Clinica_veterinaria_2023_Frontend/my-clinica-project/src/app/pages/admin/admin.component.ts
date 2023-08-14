import { Component } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {
  constructor(public menuService:MenuService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 5;
  }
}
