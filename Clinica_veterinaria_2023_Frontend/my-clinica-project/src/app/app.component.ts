import { UserService } from './core/user/user.service';
import {MediaMatcher} from '@angular/cdk/layout';
import {ChangeDetectorRef, Component, OnDestroy} from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './core/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'my-clinica-project';


  showFiller = false;
  mobileQuery: MediaQueryList;

  user:any
  private _mobileQueryListener: () => void;

  constructor(
    changeDetectorRef: ChangeDetectorRef, media: MediaMatcher,
    private userService:UserService,
    private authService:AuthService,
    private router:Router) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);


    this.user= this.userService.getCurrentUser();
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  shouldRun = [/(^|\.)plnkr\.co$/, /(^|\.)stackblitz\.io$/].some(h => h.test(window.location.host));

  logout() {
    this.authService.logout();
    this.router.navigate(['']);
  }
}
