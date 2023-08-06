import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SecretariaComponent } from './secretaria.component';
import { NotfoundConsultComponent } from './notfound-consult/notfound-consult.component';
import { CreateConsultComponent } from './create-consult/create-consult.component';
import { SearchConsultComponent } from './search-consult/search-consult.component';

const routes: Routes = [
  {
    path:'',
    component:SecretariaComponent
  },
  {
    path:'create-consult',
    component:CreateConsultComponent
  },
  {
    path:'notfound',
    component: NotfoundConsultComponent
  },
  {
    path:'search',
    component: SearchConsultComponent
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
