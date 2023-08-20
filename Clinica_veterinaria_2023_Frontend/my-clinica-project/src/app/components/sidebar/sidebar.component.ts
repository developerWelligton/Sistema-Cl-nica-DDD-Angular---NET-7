import { UserService } from './../../core/user/user.service';
import { AuthService } from 'src/app/core/auth/auth.service';
import { MenuService } from './../../services/menu.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PaddingService } from 'src/app/services/Padding.service';
import { GlobalSidebarService } from 'src/app/services/globalSidebar.service';
import { User } from 'src/app/core/user/user';

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
    debugger
    //this.userService.getRole();
    //alert(this.userRole)
    this.isExpanded = this.globalSidebarService.getState(); // Get the current state on initialization
  }



  toggleSidebar() {
    const expanded = this.globalSidebarService.toggle();
    this.isExpanded = expanded; // Update the local value

    if (expanded) {
      this.paddingService.setGlobalPadding('88px 16px 0px 70px');
    } else {
      this.paddingService.setGlobalPadding('88px 16px 0px 124px');
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
}
