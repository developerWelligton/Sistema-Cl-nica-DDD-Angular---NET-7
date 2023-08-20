import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, UrlTree, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/core/auth/auth.service'; // Replace 'path-to-your-loader-interceptor' with the actual path to your LoaderInterceptor and HTTPStatus
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
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
          let requiredRoles: string[] = next.data['roles'] || [];
          const userRole: string = localStorage.getItem('userRole');

          if (status === false) {
            blnUnAuthorize = true;
          } else if (!this.isAuthorized(userRole, requiredRoles)) { // Usar a função isAuthorized para verificar se o usuário está autorizado
            blnUnAuthorize = true;
          }

          if (blnUnAuthorize && redirect != null && redirect.length > 0) {
            this.router.navigate(['login', { redirect }]);
          } else if (blnUnAuthorize) {
            this.router.navigate(['unauthorized']);
          }

          resolve(!blnUnAuthorize);
        })
        .catch(() => {
          this.router.navigate(['login']);
          resolve(false);
        });
      })
    );
  }

  private isAuthorized(userRole: string, requiredRoles: string[]): boolean {
    return requiredRoles.includes(userRole);
  }
}

