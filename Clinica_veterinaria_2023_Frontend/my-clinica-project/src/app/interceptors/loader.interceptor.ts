
// import { Injectable } from "@angular/core";
// import {
//     HttpEvent,
//     HttpHandler,
//     HttpInterceptor,
//     HttpRequest,
//     HttpHeaders,
// } from "@angular/common/http";
// import { Router } from "@angular/router";
// import { BehaviorSubject, Observable, throwError } from "rxjs";
// import { catchError, finalize, map } from "rxjs/operators";

// import { NgxSpinnerService } from "ngx-spinner";
// import { AuthService } from "../services/auth.service";
// import jwt_decode from 'jwt-decode';



// //CORAÇÃO DA SEGURANÇA DO PROJETO
// @Injectable()
// export class HTTPStatus {
//     private requestInFlight$: BehaviorSubject<boolean>;
//     constructor() {
//         this.requestInFlight$ = new BehaviorSubject<boolean>(false);
//     }

//     setHttpStatus(inFlight: boolean) {
//         this.requestInFlight$.next(inFlight);
//     }
//     getHttpStatus(): Observable<boolean> {
//         return this.requestInFlight$.asObservable();
//     }
// }


// @Injectable()
// export class LoaderInterceptor implements HttpInterceptor {
//     private _requests = 0;
//     private token:string;
//     constructor(
//         private spinner: NgxSpinnerService,
//         private status: HTTPStatus,
//         private authService: AuthService,
//         private router: Router,
//     ) { }
//     // Método para fazer o decode do token e obter a "role"
//     public getRoleFromToken(): string {
//       if (this.token) {
//         try {
//           const decodedToken: any = jwt_decode(this.token);
//           const roleClaim = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
//           const userRole = roleClaim || "";

//           // Store the user's role in the Local Storage
//           localStorage.setItem('userRole', userRole);

//           return userRole;
//         } catch (error) {
//           console.error("Erro ao decodificar o token:", error);
//           return "";
//         }
//       }
//       return "";
//     }

//     intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<unknown>> {
//         ++this._requests;
//         let headers;
//         if (req.url.includes('api.ipify.org')) {
//             headers: new HttpHeaders({
//                 contentType: "false",
//                 processData: "false",
//             });
//         }
//         else if (req.body instanceof FormData) {

//             headers: new HttpHeaders({
//                 contentType: "false",
//                 processData: "false",
//                 Authorization: "Bearer " + this.authService.getToken
//             });

//         } else {

//             headers = new HttpHeaders()
//                 .append("accept", "application/json")
//                 .append("Content-Type", "application/json")
//                 //INJETA O TOKEN EM TODAS SUAS API
//                 .append("Authorization", "Bearer " + this.authService.getToken);
//         }
//         this.token=this.authService.getToken;
//         let request = req.clone({ headers });
//         this.status.setHttpStatus(true);
//         this.getRoleFromToken()
//         this.spinner.show();

//         return next.handle(request).pipe(
//             map((event) => {
//                 return event;
//             }),
//             catchError((error: Response) => {
//                 if (error.status === 401) {
//                     this.router.navigate(["/ROTA-A-DEFINIR- 401 Unauthorized"]);
//                 }
//                 return throwError(error);
//             }),
//             finalize(() => {
//                 --this._requests;
//                 this.status.setHttpStatus(this._requests > 0);
//                 this.status.getHttpStatus().subscribe((status: boolean) => {
//                     if (!status)
//                         this.spinner.hide();
//                 });
//             })
//         );
//     }


// }
