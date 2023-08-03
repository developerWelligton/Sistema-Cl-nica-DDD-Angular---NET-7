import { Component } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-veterinario',
  templateUrl: './veterinario.component.html',
  styleUrls: ['./veterinario.component.scss']
})
export class VeterinarioComponent {
  constructor(public menuService:MenuService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 3;
  }
}
