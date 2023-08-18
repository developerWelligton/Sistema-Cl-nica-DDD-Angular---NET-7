import { AuthService } from 'src/app/services/auth.service';
import { MenuService } from './../../services/menu.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PaddingService } from 'src/app/services/Padding.service';

@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  userRole: string;

  constructor(
    private router: Router,
    public menuService:MenuService,
    private authService: AuthService,
    private paddingService: PaddingService
  ) {}

  ngOnInit(): void {
    this.userRole = this.authService.getRole();
    //alert(this.userRole)
  }
  isExpanded = false;  // by default, the sidebar is collapsed

   toggleSidebar() {
    this.isExpanded = !this.isExpanded;

    if (this.isExpanded) {
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
}
