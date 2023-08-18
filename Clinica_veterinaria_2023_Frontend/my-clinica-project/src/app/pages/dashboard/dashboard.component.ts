import { Component } from '@angular/core';
import { PaddingService } from 'src/app/services/Padding.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  public containerPadding: string;
  constructor(public menuService:MenuService,private paddingService: PaddingService){

  }
  ngOnInit(){
    this.menuService.menuSelecionado = 1;

    this.paddingService.globalPadding$.subscribe(padding => {
      this.containerPadding = padding;
    });
  }
  isExpanded = false;

  toggleSidebar() {
    this.isExpanded = !this.isExpanded;

    if (this.isExpanded) {
      this.paddingService.setGlobalPadding('88px 16px 0px 70px');
    } else {
      this.paddingService.setGlobalPadding('88px 16px 0px 124px');
    }
  }
}
