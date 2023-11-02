
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListStockComponent } from './list-stock.component';
import { CreateEstoqueComponent } from '../create-estoque/create-estoque.component';



const routes: Routes = [
  {
    path:'',
    component:ListStockComponent
  },
  {
    path: 'create-estoque',
    component: CreateEstoqueComponent
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
export class StockRoutingModule { }
