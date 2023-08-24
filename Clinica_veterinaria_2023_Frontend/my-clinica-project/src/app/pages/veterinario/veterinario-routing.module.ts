import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VeterinarioComponent } from './veterinario.component';
import { ListConsultComponent } from './list-consult/list-consult.component';

const routes: Routes = [
  {
    path:'',
    component:VeterinarioComponent
  },
  {
    path:'list-consult',
    component:ListConsultComponent
  }
,
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
export class VeterinarioRoutingModule { }
