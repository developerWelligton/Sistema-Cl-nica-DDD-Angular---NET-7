import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PaymentComponent } from './payment/payment.component';
import { PanelPdvComponent } from '../panel-pdv/panel-pdv.component';
import { PanelBuyComponent } from './panel-buy.component';

const routes: Routes = [
  {
    path:'',
    component:PanelBuyComponent
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
export class PanelBuyRoutingModule { }
