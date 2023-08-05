import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SecretariaComponent } from './secretaria.component';
import { NotfoundConsultComponent } from './notfound-consult/notfound-consult.component';

const routes: Routes = [
  {
    path:'',
    component:SecretariaComponent
  },
  {
    path:'notfound',
    component: NotfoundConsultComponent
  },
  // Rota coringa - Redireciona para NotfoundConsultComponent quando a rota não é encontrada
  {
    path: '**',
    redirectTo: 'notfound'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecretariaRoutingModule { }
