import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, UrlTree, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/core/auth/auth.service'; // Replace 'path-to-your-loader-interceptor' with the actual path to your LoaderInterceptor and HTTPStatus
import { UserService } from '../user/user.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard2 implements CanActivate{
  constructor(
    private userService: UserService,
    private router: Router,
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
  //debugger
    //console.log('ativou guarda de rota');

    const currentUser = this.userService.getCurrentUser();
    //console.log('Pegou currentUser', currentUser);


    const expectedRoles = route.data['roles'];
    // Check if user is logged in
    if (!this.userService.isLogged()) {
      this.router.navigate(['/login']); // Redirect to login if not logged in
      return false;
    }

    if (Array.isArray(currentUser)) {
        if (currentUser.some(role => expectedRoles.includes(role))) {
            return true;  // Grant access
        }
    } else if (expectedRoles.includes(currentUser)) {
        return true;  // Grant access
    }


    // Optionally: Redirect to another page if user role doesn't match
    this.router.navigate(['/login']);
    return false;
  }

}

