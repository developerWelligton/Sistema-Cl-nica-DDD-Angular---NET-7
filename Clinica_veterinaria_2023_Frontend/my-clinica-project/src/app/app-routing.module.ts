import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './pages/guard/auth.guard';

const routes: Routes = [
  {
    path:'',
    pathMatch:'full',
    redirectTo:'login'
  },
  {
    path:'login', component:LoginComponent
  },
  {
    path:'', component:LoginComponent
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./pages/dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [AuthGuard],
    data: { roles: ['admin', 'veterinario','cliente','secretaria'] } // Mudar 'expectedRoles' para 'roles' para corresponder com a chave de dados na função canActivate
  },
  {
    path:'secretaria',
    loadChildren:() => import('./pages/secretaria/secretaria.module').then(m=>m.SecretariaModule),
    canActivate:[AuthGuard],
    data: { roles: ['admin', 'user'] }
  },
  {
    path:'veterinario',
    loadChildren:() => import('./pages/veterinario/veterinario.module').then(m=>m.VeterinarioModule),
    canActivate:[AuthGuard]
  },
  {
    path:'cliente',
    loadChildren:() => import('./pages/cliente/cliente.module').then(m=>m.ClienteModule),
    canActivate:[AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
