import { AuthService } from 'src/app/services/auth.service';
import { MenuService } from './../../services/menu.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.userRole = this.authService.getRole();
    alert(this.userRole)
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

      default:
        break;
    }
    this.menuService.menuSelecionado = menu;
  }
}
