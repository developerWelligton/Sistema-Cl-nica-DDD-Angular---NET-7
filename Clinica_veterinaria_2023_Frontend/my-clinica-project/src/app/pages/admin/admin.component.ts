import { Component } from '@angular/core';
import { PaddingService } from 'src/app/services/Padding.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {

  public containerPadding: string;
  constructor(public menuService:MenuService,private paddingService: PaddingService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 5;
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
  }
}
