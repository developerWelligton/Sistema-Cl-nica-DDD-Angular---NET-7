import { Component } from '@angular/core';
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
    private paddingService: PaddingService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 3;
    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
  }

}
