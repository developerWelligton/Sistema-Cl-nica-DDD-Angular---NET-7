import { Component } from '@angular/core';
import { PaddingService } from 'src/app/services/Padding.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent {

  public containerPadding: string;
  constructor(public menuService:MenuService,
    private paddingService: PaddingService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 4;

    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
  }



}
