import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';

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
    path:'dashboard',
    loadChildren:() => import('./pages/dashboard/dashboard.module').then(m=>m.DashboardModule)
  },
  {
    path:'secretaria',
    loadChildren:() => import('./pages/secretaria/secretaria.module').then(m=>m.SecretariaModule)
  },
  {
    path:'veterinario',
    loadChildren:() => import('./pages/veterinario/veterinario.module').then(m=>m.VeterinarioModule)
  },
  {
    path:'cliente',
    loadChildren:() => import('./pages/cliente/cliente.module').then(m=>m.ClienteModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
