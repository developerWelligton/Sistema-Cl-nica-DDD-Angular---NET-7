import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, UrlTree, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { HTTPStatus } from 'src/app/interceptors/loader.interceptor';
import { AuthService } from 'src/app/services/auth.service'; // Replace 'path-to-your-loader-interceptor' with the actual path to your LoaderInterceptor and HTTPStatus
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private httpStatus: HTTPStatus // Add the HTTPStatus service here
  ) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return new Promise((resolve) =>
      this.authService.checkToken().then((x) => {
        this.authService.UsuarioEstaAutenticado().then((status) => {
          let redirect: string = state.root.queryParams['redirect'];
          let blnUnAuthorize = false;
          let requiredRoles: string[] = next.data['roles'] || []; // Get the required roles from route data (you'll need to set this in your routing module)
          debugger
          // Get the user's role from Local Storage
          const userRole: string = localStorage.getItem('userRole');

          // Role validation
          if (status === false) {
            blnUnAuthorize = true;
          }

          // Redirect to login or unauthorized page
          if (blnUnAuthorize && redirect != null && redirect.length > 0) {
            this.router.navigate(['login', { redirect }]);
          } else if (blnUnAuthorize) {
            this.router.navigate(['unauthorized']); // Create an unauthorized page/route in your application
          }

          resolve(!blnUnAuthorize); // Return true if the user is authorized and false otherwise
        })
        .catch(() => {
          this.router.navigate(['login']);
          resolve(false);
        });
      })
    );
  }

  private isAuthorized(userRole: string, requiredRoles: string[]): boolean {
    // Implement your authorization logic here.
    // For example, you can check if the user's role is present in the requiredRoles array.
    return requiredRoles.includes(userRole);
  }
}
