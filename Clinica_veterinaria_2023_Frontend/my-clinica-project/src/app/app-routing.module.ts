import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './pages/guard/auth.guard';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'login'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./pages/dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [AuthGuard],
    data: { roles: ['admin', 'veterinario', 'cliente', 'secretaria'] }
  },
  {
    path: 'secretaria',
    loadChildren: () => import('./pages/secretaria/secretaria.module').then(m => m.SecretariaModule),
    canActivate: [AuthGuard],
    data: { roles: ['admin', 'secretaria'] }
  },
  {
    path: 'veterinario',
    loadChildren: () => import('./pages/veterinario/veterinario.module').then(m => m.VeterinarioModule),
    canActivate: [AuthGuard],
    data: { roles: ['admin', 'veterinario'] }
  },
  {
    path: 'cliente',
    loadChildren: () => import('./pages/cliente/cliente.module').then(m => m.ClienteModule),
    canActivate: [AuthGuard],
    data: { roles: ['admin', 'cliente'] }
  },
  // Rota coringa - Redireciona para a rota 'dashboard' se a rota não for encontrada
  {
    path: '**',
    redirectTo: 'dashboard'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
