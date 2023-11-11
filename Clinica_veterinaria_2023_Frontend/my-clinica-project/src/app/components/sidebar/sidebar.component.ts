import { UserService } from './../../core/user/user.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { MenuService } from './../../services/menu.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PaddingService } from 'src/app/services/Padding.service';
import { GlobalSidebarService } from 'src/app/services/globalSidebar.service';
import { User } from 'src/app/core/user/user';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  userRole: string;
  user:any;
  isExpanded: boolean;  // Declare a member variable for expanded state

  constructor(
    private router: Router,
    public menuService:MenuService,
    private userService: UserService,
    private paddingService: PaddingService,
     private globalSidebarService: GlobalSidebarService
  ) {}

  ngOnInit(): void {
    this.user=this.userService.getCurrentUser()
    this.userRole = this.user
    //debugger
    //this.userService.getRole();
    //alert(this.userRole)
    this.isExpanded = this.globalSidebarService.getState(); // Get the current state on initialization
  }



  toggleSidebar() {
    const expanded = this.globalSidebarService.toggle();
    this.isExpanded = expanded; // Update the local value

    if (expanded) {
      this.paddingService.setGlobalPadding('88px 16px 0px 0px');
    } else {
      this.paddingService.setGlobalPadding('88px 16px 0px 57px');
    }
  }

  selectMenu(menu:number) {
    switch(menu){
      case 1:
        this.router.navigate(['/dashboard'])
        break;

      case 2:
        this.router.navigate(['/secretaria'])
        break;

      case 3:
        this.router.navigate(['/veterinario'])
        break;

      case 4:
        this.router.navigate(['/cliente'])
        break;

      case 5:
        this.router.navigate(['/admin'])
        break;

      default:
        break;
    }
    this.menuService.menuSelecionado = menu;
  }

  navigateToDashboard() {
    this.router.navigate(['/dashboard']);
  }
  navigateToSecretaria() {
    this.router.navigate(['/secretaria'])
  }
  navigateToVeterinario() {
    this.router.navigate(['/veterinario'])
  }
  navigateToCliente() {
    this.router.navigate(['/cliente'])
  }
  navigateToAdmin() {
    this.router.navigate(['/admin'])
  }

  shouldRun = [/(^|\.)plnkr\.co$/, /(^|\.)stackblitz\.io$/].some(h => h.test(window.location.host));
  showFiller = false;
  // Defina as larguras de tela em que o modo muda
  modesByWidth = new Map<number, 'over' | 'side'>([
    [0, 'over'],    // Modo "over" para telas menores ou iguais a 0px
    [600, 'over'],  // Modo "over" para telas menores ou iguais a 600px
    [1000, 'side'], // Modo "side" para telas maiores que 1000px
  ]);

  get mode(): 'over' | 'side' {
    const width = window.innerWidth;
    const entries = Array.from(this.modesByWidth.entries());

    for (const [minWidth, mode] of entries) {
      if (width <= minWidth) {
        return mode;
      }
    }

    return 'side'; // Modo padrão
  }
}
