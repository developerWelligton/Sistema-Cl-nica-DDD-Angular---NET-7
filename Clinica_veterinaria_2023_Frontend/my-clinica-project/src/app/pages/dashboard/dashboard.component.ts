import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { PaddingService } from 'src/app/services/Padding.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  public containerPadding: string;
  private paddingSubscription: Subscription;
  
  constructor(public menuService:MenuService,private paddingService: PaddingService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 1;

    this.paddingSubscription = this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
  }

   // Não se esqueça de cancelar a inscrição para evitar vazamentos de memória
   ngOnDestroy() {
    if (this.paddingSubscription) {
      this.paddingSubscription.unsubscribe();
    }
  }

}
