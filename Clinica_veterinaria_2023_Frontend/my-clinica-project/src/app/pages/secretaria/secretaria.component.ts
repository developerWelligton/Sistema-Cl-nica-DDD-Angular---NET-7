import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';
import { PaddingService } from 'src/app/services/Padding.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-secretaria',
  templateUrl: './secretaria.component.html',
  styleUrls: ['./secretaria.component.scss']
})
export class SecretariaComponent {
  public containerPadding: string;
  constructor(public menuService:MenuService,private paddingService: PaddingService, private route: Router){


  }
  ngOnInit(){
    this.menuService.menuSelecionado = 2;
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
  }

  navigateToSecretaria() {
    this.route.navigate(['/secretaria'])
  }
}
