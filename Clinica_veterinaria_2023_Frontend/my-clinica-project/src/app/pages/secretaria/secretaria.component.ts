import { Component } from '@angular/core';
import { PaddingService } from 'src/app/services/Padding.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-secretaria',
  templateUrl: './secretaria.component.html',
  styleUrls: ['./secretaria.component.scss']
})
export class SecretariaComponent {
  public containerPadding: string;
  constructor(public menuService:MenuService,private paddingService: PaddingService){


  }
  ngOnInit(){
    this.menuService.menuSelecionado = 2;
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
  }
}
