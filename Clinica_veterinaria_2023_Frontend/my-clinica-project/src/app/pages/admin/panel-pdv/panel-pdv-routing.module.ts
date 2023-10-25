import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PanelPdvComponent } from './panel-pdv.component';
import { PaymentComponent } from './payment/payment.component';

const routes: Routes = [
  {
    path:'',
    component:PanelPdvComponent
  },
  {
    path:'payment',
    component:PaymentComponent
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
export class PanelPdvRoutingModule { }
