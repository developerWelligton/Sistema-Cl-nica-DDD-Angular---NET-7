
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListStockComponent } from './list-stock.component';
import { CreateEstoqueComponent } from '../create-estoque/create-estoque.component';
import { StockProductsTableComponent } from './stock-list-table copy/stock-products-table.component';



const routes: Routes = [
  {
    path:'',
    component:ListStockComponent
  },
  {
    path: 'create-estoque',
    component: CreateEstoqueComponent
  },

  {
    path: 'detail-stock-product/:id',
    component: StockProductsTableComponent
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
